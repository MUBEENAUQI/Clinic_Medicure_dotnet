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
        public ActionResult GuestMed()
        {
            return View("GuestMedicinePage");
        }
        public ActionResult GuestDoc()
        {
            return View("GuestDoctorPage");
        }
    }
}