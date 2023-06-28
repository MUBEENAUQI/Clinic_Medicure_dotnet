using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Doctor()
        {
            return View("DoctorPage");
        }
    }
}