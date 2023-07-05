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
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Doctor()
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                DoctorModel model = new DoctorModel();

                int loginId = Convert.ToInt32(Session["LoginId"]);

                model.Login_id = loginId;

                var getdata = db.Get_DoctorData_byLoginID(loginId).FirstOrDefault();
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

                return View("DoctorProfile", model);

            }
        }

        //patinet
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

            return View("DoctorPatientView", model);
        }


        public ActionResult AddPatient()
        {

            return View("DoctorPatientAdd");

        }

        public ActionResult EditPatient(int id)
        {
            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.patientById(id).FirstOrDefault();
                Patient1 model = new Patient1();

                model.Patient_Id = Convert.ToInt32(id);
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


                return View("DoctorPatientAdd", model);
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
                            db.patient_details_update(model.Patient_Id, model.Patient_Name, model.Patient_Email, model.Patient_Birthday, model.Patient_Phone, model.Patient_gender, model.Patient_Bloodgrp, model.Patient_Address, model.Patient_Weight, model.Patient_Height, model.Patient_Prescription, model.Patient_Username, model.Patient_Password, model.Login_id);
                        ViewBag.Message = "Data Updated successfully";

                        return View("DoctorPatientAdd");

                    }
                }
                else
                {
                    using (MedicareEntities db = new MedicareEntities())
                    {


                        db.Add_LoginData(model.Patient_Username, model.Patient_Password, 1);
                        db.Database.Connection.Close();
                        db.Database.Connection.Open();
                        db.patient_details_insert(model.Patient_Name, model.Patient_Email, model.Patient_Birthday, model.Patient_Phone, model.Patient_gender, model.Patient_Bloodgrp, model.Patient_Address, model.Patient_Weight, model.Patient_Height, model.Patient_Prescription, model.Patient_Username, model.Patient_Password);


                        ViewBag.Message = "Data inserted successfully";

                        return View("DoctorPatientAdd");

                    }
                }


            }
            else
            {
                return View("DoctorPatientAdd", model);
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

            return View("DoctorPatientView", model);
        }

        //orders and medicines
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
                        name = item.MedicineName,
                        date = item.OrderDate

                    });
                }
            }

            return View(model);
        }
        public ActionResult Purchaseorder()
        {

            return View("DoctorPurchaseAdd");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult orderAdd(OrderModel model)
        {
            using (MedicareEntities db = new MedicareEntities())
            {

                db.Order_Medicine(model.medicineID, model.quantity);
                ViewBag.Message = "Medicine Ordered Successfully";

                return View("DoctorPurchaseAdd");

            }



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedicine(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                using (MedicareEntities db = new MedicareEntities())
                {
                    // Call the stored procedure to add the medicine
                    db.Add_Medicines(model.Name, model.Manufacturer, model.Dosage, model.Description, model.ExpiryDate, model.Price, model.Quantity);

                    ViewBag.Message = "Medicine added successfully";

                    // Clear the model to reset the form fields
                    ModelState.Clear();

                    return View("AddNewMedicine", new MedicineModel());
                }
            }
            else
            {
                return View("AddNewMedicine", model);
            }
        }

        public ActionResult NewMed()
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