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
        MedicareEntities db = new MedicareEntities();

        public ActionResult Supplier()
        {
           
                Supplier_Model model = new Supplier_Model();
                string username = User.Identity.Name;

                int loginId = GetMessage.GetLoginID(username);

                //int loginId = Convert.ToInt32(Session["LoginId"]);

                model.Login_id = loginId;

                var getdata = db.Get_SupplierDataByLoginID(loginId).FirstOrDefault();
                model.Supplier_id = getdata.Supplier_id;
                model.Supplier_name = getdata.Supplier_name;
                model.Supplier_Phone = getdata.Supplier_phone;
                model.Supplier_Email = getdata.Supplier_email;
                model.Supplier_Gender = getdata.Supplier_Gender;
                model.Supplier_Username = getdata.Username;
                model.Supplier_Password = getdata.Password;
                model.Login_id = getdata.Login_ID;

                return View("SupplierProfile", model);

            
        }
        public ActionResult ViewOrders()
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
            return RedirectToAction("ViewOrders");
        }
        public ActionResult Message()
        {
            string username = User.Identity.Name;
            Messaging msg_model = new Messaging();
            msg_model.Sender_List = GetMessage.GetSendersList(username);
            msg_model.Receiver_Id = GetMessage.GetLoginID(username);
            if (msg_model.Sender_List.Count>0)
            {
                msg_model.Selected_Name = msg_model.Sender_List[0].username;
                msg_model.conversation = GetMessage.GetCoversation(msg_model.Sender_List[0].SenderId, msg_model.Receiver_Id);
                msg_model.Selected_Id = msg_model.Sender_List[0].SenderId;
            }
            
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
            db.SendMessage(model.Receiver_Id, model.Selected_Id, currentTimestamp, model.sendMessageContent);
            return RedirectToAction("ViewMessage", "Supplier", new { sender_name = model.Selected_Name, sender_id = model.Selected_Id.ToString(), viewName = "Message" });
        }

        //[HttpPost]
        //public ActionResult NewMessage(Messaging model)
        //{
        //    List<SelectListItem> accList = new List<SelectListItem>();
        //    accList.Add(new SelectListItem { Text = "Doctor", Value = "2" });
        //    accList.Add(new SelectListItem { Text = "Salesman", Value = "4" });
        //    //lst.Add(new SelectListItem { Text = item.Account_name, Value = item.Account_ID.ToString() });

        //    DateTime currentTimestamp = DateTime.Now;
        //    db.SendMessage(model.Receiver_Id, model.Selected_Id, currentTimestamp, model.sendMessageContent);
        //    return RedirectToAction("ViewMessage", "Supplier", new { sender_name = model.Selected_Name, sender_id = model.Selected_Id.ToString(), viewName = "Message" });
        //}

        
    }


}