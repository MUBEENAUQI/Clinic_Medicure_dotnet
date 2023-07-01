using Clinic_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Clinic_Automation.Controllers
{
    [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Admin()
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


            return View("AdminDoctorView", model);

        }
        public ActionResult AddDoctor()
        {

            return View("AdminDoctorAdd");

        }

        public ActionResult EditDoctor(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.Get_DoctorData_byID(id).FirstOrDefault();
                DoctorModel model = new DoctorModel();
                model.Doctor_id = getdata.Doctor_ID;
                model.Doctor_name = getdata.Doctor_name;
                model.Doctor_Specialty = getdata.Doctor_Specialty;
                model.Doctor_Experience = getdata.Doctor_Experience;
                model.Doctor_Phone = getdata.Doctor_Phone;
                model.Doctor_Email = getdata.Doctor_Email;
                model.Doctor_Qualification = getdata.Doctor_Qualification;
                model.Doctor_Fees = getdata.Doctor_Fees;
                model.Doctor_Gender = getdata.Gender;
                model.Doctor_Username = getdata.Username;
                model.Doctor_Password = getdata.Password;
                model.Login_id = getdata.Login_ID;
                Console.WriteLine($"loginId {model.Login_id}");
                return View("AdminDoctorAdd", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDoctor(DoctorModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.Doctor_id > 0)
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {
                        if (model.Login_id.HasValue && model.Login_id > 0)
                            db.Update_DoctorData(model.Doctor_name, model.Doctor_Specialty, model.Doctor_Experience, model.Doctor_Phone, model.Doctor_Email, model.Doctor_Qualification, model.Doctor_Fees, model.Doctor_Gender, model.Doctor_Username, model.Doctor_Password,model.Login_id);
                        ViewBag.Message = "Data Updated successfully";

                        return View("AdminDoctorAdd");

                    }
                }
                else
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {


                        db.Add_LoginData(model.Doctor_Username, model.Doctor_Password, 2);
                        db.Database.Connection.Close();
                        db.Database.Connection.Open();
                        db.Add_Doctor(model.Doctor_name, model.Doctor_Specialty, model.Doctor_Experience, model.Doctor_Phone, model.Doctor_Email, model.Doctor_Qualification, model.Doctor_Fees, model.Doctor_Gender, model.Doctor_Username, model.Doctor_Password);


                        ViewBag.Message = "Data inserted successfully";

                        return View("AdminDoctorAdd");

                    }
                }

                return View("AdminDoctorAdd");
            }
            else
            {
                return View("AdminDoctorAdd", model);
            }

        }

        public ActionResult DeleteDoctor(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                db.DeleteDoctor(id);
            }

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


            return View("AdminDoctorView", model);
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            LoginModel model = new LoginModel();
            model.Account_List = Account_list_get.GetAccountList();
            return RedirectToAction("Login", "Login", model);


        }
    }
}