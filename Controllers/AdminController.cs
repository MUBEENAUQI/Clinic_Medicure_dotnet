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

        public ActionResult Doctor()
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
        //patient
        public ActionResult Patient()
        {
            List<Patient1> model = new List<Patient1>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.patient_details_view();
                foreach (var item in getdata)
                {
                    model.Add(new Patient1
                    {
                        Patient_Id = item.Patient_Id,
                        Patient_Name = item.Patient_Name,
                        Patient_Email = item.Patient_Email,
                        Patient_Birthday = item.Patient_Birthday,
                        Patient_Phone = item.Patient_Phone,
                        Patient_gender = item.Patient_gender,
                        Patient_Bloodgrp = item.Patient_Bloodgrp,
                        Patient_Address = item.Patient_Address,
                        Patient_Weight = item.Patient_Weight,
                        Patient_Height = item.Patient_Height,
                        Patient_Prescription = item.Patient_Prescription
                    });
                }
            }

            return View("AdminPatientView", model);
        }


        public ActionResult AddPatient()
        {

            return View("AdminPatientAdd");

        }

        public ActionResult EditPatient(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.patientById(id).FirstOrDefault();
                Patient1 model = new Patient1();
               
                model.Patient_Id =Convert.ToInt32(id);
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


                return View("AdminPatientAdd", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePatient(Patient1 model)
        {

            if (ModelState.IsValid)
            {
                if (model.Patient_Id > 0)
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {
                        if (model.Patient_Id.HasValue && model.Patient_Id > 0)
                            db.patient_details_update(model.Patient_Id, model.Patient_Name, model.Patient_Email, model.Patient_Birthday, model.Patient_Phone, model.Patient_gender, model.Patient_Bloodgrp, model.Patient_Address, model.Patient_Weight, model.Patient_Height, model.Patient_Prescription,model.Patient_Username,model.Patient_Password,model.Login_id);
                        ViewBag.Message = "Data Updated successfully";

                        return View("AdminPatientAdd");

                    }
                }
                else
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {


                        db.Add_LoginData(model.Patient_Username, model.Patient_Password, 1);
                        db.Database.Connection.Close();
                        db.Database.Connection.Open();
                        db.patient_details_insert(model.Patient_Name, model.Patient_Email, model.Patient_Birthday, model.Patient_Phone, model.Patient_gender, model.Patient_Bloodgrp, model.Patient_Address, model.Patient_Weight, model.Patient_Height, model.Patient_Prescription,model.Patient_Username,model.Patient_Password);


                        ViewBag.Message = "Data inserted successfully";

                        return View("AdminPatientAdd");

                    }
                }


            }
            else
            {
                return View("AdminPatientAdd", model);
            }

        }

        public ActionResult DeletePatient(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                db.patient_details_delete(id);
            }

            List<Patient1> model = new List<Patient1>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.patient_details_view();
                foreach (var item in getdata)
                {
                    model.Add(new Patient1
                    {
                        Patient_Id = item.Patient_Id,
                        Patient_Name = item.Patient_Name,
                        Patient_Email = item.Patient_Email,
                        Patient_Birthday = item.Patient_Birthday,
                        Patient_Phone = item.Patient_Phone,
                        Patient_gender = item.Patient_gender,
                        Patient_Bloodgrp = item.Patient_Bloodgrp,
                        Patient_Address = item.Patient_Address,
                        Patient_Weight = item.Patient_Weight,
                        Patient_Height = item.Patient_Height,
                        Patient_Prescription = item.Patient_Prescription
                    });
                }
            }

            return View("AdminPatientView", model);
        }

        //Salesman
        public ActionResult Salesman()
        {
            List<Salesman_Model> model = new List<Salesman_Model>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.Salesman_View();
                foreach (var item in getdata)
                {

                    model.Add(new Salesman_Model
                    {
                        Salesman_id = item.SM_ID,
                        Salesman_name = item.SM_Name,
                        Salesman_Phone = item.SM_phone,
                        Salesman_Email = item.SM_Email,
                        Salesman_Gender = item.SM_Gender,
                        Login_id=item.Login_ID
                       
                    });
                }
            }

            return View("AdminSalesmanView", model);
        }
       


        public ActionResult AddSalesman()
        {

            return View("AdminSalesmanAdd");

        }

        public ActionResult EditSalesman(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                var item = db.Salesman_View_byID(id).FirstOrDefault();
               Salesman_Model model = new Salesman_Model();

                model.Salesman_id = item.SM_ID;
                model.Salesman_name = item.SM_Name;
                model.Salesman_Phone = item.SM_phone;
                model.Salesman_Email = item.SM_Email;
                model.Salesman_Gender = item.SM_Gender;
                model.Login_id = item.Login_ID;
                model.Salesman_Username = item.Username;
                model.Salesman_Password = item.Password;

                
                return View("AdminSalesmanAdd", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSalesman(Salesman_Model model)
        {

            if (ModelState.IsValid)
            {
                if (model.Salesman_id > 0)
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {
                        if (model.Salesman_id.HasValue && model.Salesman_id > 0)
                            db.Salesman_Update(model.Salesman_name, model.Salesman_Phone, model.Salesman_Email, model.Salesman_Gender, model.Salesman_Username, model.Salesman_Password, model.Login_id);
                        ViewBag.Message = "Data Updated successfully";

                        return View("AdminSalesmanAdd");

                    }
                }
        
                else
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {


                        db.Add_LoginData(model.Salesman_Username, model.Salesman_Password, 4);
                        db.Database.Connection.Close();
                        db.Database.Connection.Open();
                        db.Salesman_Insert(model.Salesman_name,model.Salesman_Email,model.Salesman_Phone,model.Salesman_Gender,model.Salesman_Username,model.Salesman_Password);

	
                        ViewBag.Message = "Data inserted successfully";

                        return View("AdminSalesmanAdd");

                    }
                }


            }
            else
            {
                return View("AdminSalesmanAdd", model);
            }

        }

        public ActionResult DeleteSalesman(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                db.Salesman_Delete(id);
            }

            List<Salesman_Model> model = new List<Salesman_Model>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.Salesman_View();
                foreach (var item in getdata)
                {
                    model.Add(new Salesman_Model
                    {
                        Salesman_id = item.SM_ID,
                        Salesman_name = item.SM_Name,
                        Salesman_Phone = item.SM_phone,
                        Salesman_Email = item.SM_Email,
                        Salesman_Gender = item.SM_Gender,
                        Login_id = item.Login_ID
                    });
                }
            }

            return View("AdminSalesmanView", model);
        }

        //Supplier
        public ActionResult Supplier()
        {
            List<Supplier_Model> model = new List<Supplier_Model>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.Supplier_View();
                foreach (var item in getdata)
                {

                    model.Add(new Supplier_Model
                    {
                        Supplier_id = item.Supplier_id,
                        Supplier_name = item.Supplier_name,
                        Supplier_Phone = item.Supplier_phone,
                        Supplier_Email = item.Supplier_email,
                        Supplier_Gender = item.Supplier_Gender,
                        Login_id = item.Login_ID

                    });
                }
            }

            return View("AdminSupplierView", model);
        }



        public ActionResult AddSupplier()
        {

            return View("AdminSupplierAdd");

        }

        public ActionResult EditSupplier(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                var item = db.Supplier_View_byID(id).FirstOrDefault();
                Supplier_Model model = new Supplier_Model();

                model.Supplier_id = item.Supplier_id;
                model.Supplier_name = item.Supplier_name;
                model.Supplier_Phone = item.Supplier_phone;
                model.Supplier_Email = item.Supplier_email;
                model.Supplier_Gender = item.Supplier_Gender;
                model.Login_id = item.Login_ID;
                model.Supplier_Username = item.Username;
                model.Supplier_Password = item.Password;


                return View("AdminSupplierAdd", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSupplier(Supplier_Model model)
        {

            if (ModelState.IsValid)
            {
                if (model.Supplier_id > 0)
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {
                        if (model.Supplier_id.HasValue && model.Supplier_id > 0)
                            db.Supplier_Update(model.Supplier_name, model.Supplier_Phone, model.Supplier_Email, model.Supplier_Gender, model.Supplier_Username, model.Supplier_Password, model.Login_id);
                        ViewBag.Message = "Data Updated successfully";

                        return View("AdminSupplierAdd");

                    }
                }

                else
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {


                        db.Add_LoginData(model.Supplier_Username, model.Supplier_Password, 3);
                        db.Database.Connection.Close();
                        db.Database.Connection.Open();
                        db.Supplier_Insert(model.Supplier_name, model.Supplier_Email, model.Supplier_Phone, model.Supplier_Gender, model.Supplier_Username, model.Supplier_Password);


                        ViewBag.Message = "Data inserted successfully";

                        return View("AdminSupplierAdd");

                    }
                }


            }
            else
            {
                return View("AdminSupplierAdd", model);
            }

        }

        public ActionResult DeleteSupplier(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                db.Supplier_Delete(id);
            }

            List<Supplier_Model> model = new List<Supplier_Model>();
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.Supplier_View();
                foreach (var item in getdata)
                {
                    model.Add(new Supplier_Model
                    {
                        Supplier_id = item.Supplier_id,
                        Supplier_name = item.Supplier_name,
                        Supplier_Phone = item.Supplier_phone,
                        Supplier_Email = item.Supplier_email,
                        Supplier_Gender = item.Supplier_Gender,
                        Login_id = item.Login_ID
                    });
                }
            }

            return View("AdminSupplierView", model);
        }
    }
}