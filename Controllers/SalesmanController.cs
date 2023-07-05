using Clinic_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Controllers
{

    [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
    [Authorize]
    public class SalesmanController : Controller
    {
        // GET: Salesman
        public ActionResult Salesman()
        {

            using (MedicareEntities db = new MedicareEntities())
            {
                Salesman_Model model = new Salesman_Model();

                int loginId = Convert.ToInt32(Session["LoginId"]);

                model.Login_id = loginId;

                var item = db.Salesman_View_byLoginID(loginId).FirstOrDefault();
                model.Salesman_id = item.SM_ID;
                model.Salesman_name = item.SM_Name;
                model.Salesman_Phone = item.SM_phone;
                model.Salesman_Email = item.SM_Email;
                model.Salesman_Gender = item.SM_Gender;
                model.Login_id = item.Login_ID;
                model.Salesman_Username = item.Username;
                model.Salesman_Password = item.Password;

                return View("SalesmanProfile", model);

            }

        }
        public ActionResult ViewPendingOrders()
        {
            List<OrderModel> model = new List<OrderModel>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.View_Pending_orders();
                foreach (var item in getdata)
                {
                    model.Add(new OrderModel
                    {
                        medicineID = item.MedicineID,
                        quantity = item.Quantity,
                        orderID = item.OrderID,
                        name=item.MedicineName,
                        date=item.OrderDate

                    }) ;
                }
            }

            return View(model);
        }
        public ActionResult Purchaseorder()
        {

            return View("SalemanPurchaseAdd");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult orderAdd(OrderModel model)
        {
            using (MedicareEntities db = new MedicareEntities())
            {

                db.Order_Medicine(model.medicineID,model.quantity);
                ViewBag.Message = "Medicine Ordered Successfully";

                return View("SalemanPurchaseAdd");

            }


           
        }
        public ActionResult OrderNewProduct()
        {
            return View("AddNewMedicine");
        }

        

        MedicareEntities db = new MedicareEntities();
        public ActionResult GuestMed(String searching)
        {

            return View("ViewMedicine", db.Medicines.Where(x => x.Name.Contains(searching) || searching == null).ToList().OrderBy(x => x.Quantity));
        }
    }
}
