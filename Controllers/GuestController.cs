using Clinic_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        MedicareEntities db = new MedicareEntities();

        public ActionResult GuestMed(String searching)
        {
            return View(db.Medicines.Where(x => x.Name.Contains(searching) || searching == null).ToList().OrderBy(x => x.Name));
        }
        public ActionResult GuestDoc()
        {
            return View("GuestDoctorPage");
        }
    }
}