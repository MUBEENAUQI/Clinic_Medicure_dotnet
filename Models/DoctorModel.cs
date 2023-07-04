using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Automation.Models
{
    public class DoctorModel
    {
        public int? Doctor_id { get; set; }
        public int? Login_id { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's name.")]
        public string Doctor_name { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's specialty.")]
        public string Doctor_Specialty { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's experience.")]
        public int? Doctor_Experience { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's phone number.")]
        public string Doctor_Phone { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Doctor_Email { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's qualification.")]
        public string Doctor_Qualification { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's fees.")]
        public int? Doctor_Fees { get; set; }

        [Required(ErrorMessage = "Please select the doctor's gender.")]
        public string Doctor_Gender { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's username.")]
        public string Doctor_Username { get; set; }

        [Required(ErrorMessage = "Please enter the doctor's password.")]
        public string Doctor_Password { get; set; }

    }
}