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
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Patient()
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                Patient1 model = new Patient1();

                int loginId = Convert.ToInt32(Session["LoginId"]);

                model.Login_id = loginId;

                var getdata = db.patientById_Login(loginId).FirstOrDefault();

                model.Patient_Id = getdata.Patient_Id;
                model.Patient_Name = getdata.Patient_Name;
                model.Patient_Email = getdata.Patient_Email;
                model.Patient_Birthday = getdata.Patient_Birthday;
                model.Patient_Phone = getdata.Patient_Phone;
                model.Patient_gender = getdata.Patient_gender;
                model.Patient_Bloodgrp = getdata.Patient_Bloodgrp;
                model.Patient_Address = getdata.Patient_Address;
                model.Patient_Weight = getdata.Patient_Weight;
                model.Patient_Height = getdata.Patient_Height;
                model.Patient_Prescription = getdata.Patient_Prescription;
                model.Patient_Username = getdata.Username;
                model.Patient_Password = getdata.Password;

                return View("PatientProfile", model);
            }
        }

        public ActionResult Patientadd()
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                Patient1 model = new Patient1();

                int loginId = Convert.ToInt32(Session["LoginId"]);

                model.Login_id = loginId;

                var getdata = db.patientById_Login(loginId).FirstOrDefault();

                model.Patient_Id = getdata.Patient_Id;
                model.Patient_Name = getdata.Patient_Name;
                model.Patient_Email = getdata.Patient_Email;
                model.Patient_Birthday = getdata.Patient_Birthday;
                model.Patient_Phone = getdata.Patient_Phone;
                model.Patient_gender = getdata.Patient_gender;
                model.Patient_Bloodgrp = getdata.Patient_Bloodgrp;
                model.Patient_Address = getdata.Patient_Address;
                model.Patient_Weight = getdata.Patient_Weight;
                model.Patient_Height = getdata.Patient_Height;
                model.Patient_Prescription = getdata.Patient_Prescription;
                model.Patient_Username = getdata.Username;
                model.Patient_Password = getdata.Password;
                return View("UpdatePatient", model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePatient(Patient1 model)
        {

            //if (ModelState.IsValid)
            //{
                if (model.Patient_Id > 0)
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {
                        if (model.Patient_Id.HasValue && model.Patient_Id > 0)
                            db.patient_details_update(model.Patient_Id, model.Patient_Name, model.Patient_Email, model.Patient_Birthday, model.Patient_Phone, model.Patient_gender, model.Patient_Bloodgrp, model.Patient_Address, model.Patient_Weight, model.Patient_Height, model.Patient_Prescription, model.Patient_Username, model.Patient_Password, model.Login_id);
                        ViewBag.Message = "Data Updated successfully";

                        return View("UpdatePatient");

                    }
                }
           // }
            
                return View("UpdatePatient", model);
            

        }

    }
}