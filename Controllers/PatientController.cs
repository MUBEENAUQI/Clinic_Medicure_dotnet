﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Patient()
        {
            return View("PatientPage");
        }
    }
}