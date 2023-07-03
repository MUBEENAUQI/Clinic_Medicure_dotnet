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
            
            return View("Message");
        }
    }
}





