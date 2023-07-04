using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Automation.Models
{
    public class Patient1
    {
        [Key]
        public int? Patient_Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]

       
        public string Patient_Name { get; set; }
        [Required(ErrorMessage = "Please enter mail-id")]
        [EmailAddress]
        public string Patient_Email { get; set; }
        [Required(ErrorMessage = "Please enter DOB")]
        //public System.DateTime Patient_Birthday { get; set; }
        public DateTime? Patient_Birthday { get; set; }
        [Required(ErrorMessage = "Please enter mobile number")]
        [MinLength(10, ErrorMessage = "mobile no should not exceed 10")]
        public string Patient_Phone { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Patient_gender { get; set; }
        [Required(ErrorMessage = "Please enter blood group")]
        public string Patient_Bloodgrp { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Patient_Address { get; set; }
        [Required(ErrorMessage = "Please enter weight(in kgs)")]
        public decimal? Patient_Weight { get; set; }
        [Required(ErrorMessage = "Please enterheight in cms")]
        public decimal? Patient_Height { get; set; }
        [Required(ErrorMessage = "Please enter Presciption")]
        public string Patient_Prescription { get; set; }
        public int? Login_id { get; set; }
        [Required(ErrorMessage = "Please enter the username.")]
        public string Patient_Username { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's password.")]
        public string Patient_Password { get; set; }
    }
}