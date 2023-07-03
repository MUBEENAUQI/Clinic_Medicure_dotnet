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
            
            return View("GuestMedicinePage", db.Medicines.Where(x => x.Name.Contains(searching) || searching == null).ToList().OrderBy(x => x.Name));
        }
        public ActionResult GuestDoc()
        {
            List<DoctorModel> model = new List<DoctorModel>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.Get_DoctorData();
                foreach (var item in getdata)
                {
                    model.Add(new DoctorModel
                    {
                        Doctor_id = item.Doctor_ID,
                        Doctor_name = item.Doctor_name,
                        Doctor_Specialty = item.Doctor_Specialty,
                        Doctor_Experience = item.Doctor_Experience,
                        Doctor_Phone = item.Doctor_Phone,
                        Doctor_Email = item.Doctor_Email,
                        Doctor_Qualification = item.Doctor_Qualification,
                        Doctor_Fees = item.Doctor_Fees,
                        Doctor_Gender = item.Gender,
                        Doctor_Username = item.Username,
                        Doctor_Password = item.Password,
                    });
                }
            }
            return View("GuestDoctorPage", model);
        }
    }
}