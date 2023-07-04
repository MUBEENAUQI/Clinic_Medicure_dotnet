using Clinic_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Controllers
{

    [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
    [Authorize]
    public class SupplierController : Controller
    {
        // GET: Supplier
        MedicareEntities1 db = new MedicareEntities1();
        public ActionResult Supplier()
        {
            string mydata = TempData["Supplied"] as string;
            if (!string.IsNullOrEmpty(mydata) && mydata.Equals("yes"))
            {
                ViewBag.Message = "Order supplied successfully";
            }
            return View("SupplierPage", db.OrderLists.ToList().OrderBy(x => x.MedicineName));
        }

        public ActionResult PendingOrders()
        {
            return View("SupplierPage", db.OrderLists.Where(x => x.OrderStatus.Equals(false)).ToList().OrderBy(x => x.MedicineName));
        }

        public ActionResult Supply(int medid, int quantity, int orderid)
        {

            db.SupplyMedicine(medid, quantity, orderid);
            TempData["Supplied"] = "yes";
            return RedirectToAction("Supplier");
        }
        public ActionResult Message()
        {
            string username = User.Identity.Name;
            Messaging msg_model = new Messaging();
            msg_model.Sender_List = GetMessage.GetSendersList(username);
            msg_model.Selected_Name = msg_model.Sender_List[0].username;
            msg_model.Receiver_Id = GetMessage.GetLoginID(username);

            msg_model.conversation = GetMessage.GetCoversation(msg_model.Sender_List[0].SenderId, msg_model.Receiver_Id);
            msg_model.Selected_Id = msg_model.Sender_List[0].SenderId;
            return View("Message", msg_model);
        }

        public ActionResult ViewMessage(string sender_name, int sender_id)
        {
            string username = User.Identity.Name;
            Messaging msg_model = new Messaging();
            
            msg_model.Selected_Name = sender_name;
            msg_model.Selected_Id = sender_id;
            msg_model.Receiver_Id = GetMessage.GetLoginID(username);
            db.SetSeenStatus(msg_model.Selected_Id, msg_model.Receiver_Id);
            msg_model.Sender_List = GetMessage.GetSendersList(username);
            msg_model.conversation = GetMessage.GetCoversation(sender_id, msg_model.Receiver_Id);
            

            return View("Message", msg_model);
        }

        [HttpPost]
        public ActionResult SendMessage(Messaging model)
        {
            DateTime currentTimestamp = DateTime.Now;
            db.SendMessage(model.Receiver_Id,model.Selected_Id, currentTimestamp,model.sendMessageContent);
            return RedirectToAction("ViewMessage", "Supplier", new { sender_name = model.Selected_Name, sender_id = model.Selected_Id.ToString(),  viewName = "Message" });
        }
    }


}