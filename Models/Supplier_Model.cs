using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Automation.Models
{
    public class Supplier_Model
    {
        public int? Supplier_id { get; set; }
        public int? Login_id { get; set; }

        [Required(ErrorMessage = "Please enter the Supplier's name.")]
        public string Supplier_name { get; set; }


        [Required(ErrorMessage = "Please enter the Supplier's phone number.")]
        public string Supplier_Phone { get; set; }

        [Required(ErrorMessage = "Please enter the Supplier's email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Supplier_Email { get; set; }

        [Required(ErrorMessage = "Please select the Supplier's Gender")]

        public string Supplier_Gender { get; set; }

        [Required(ErrorMessage = "Please enter the Supplier's username.")]
        public string Supplier_Username { get; set; }

        [Required(ErrorMessage = "Please enter the Supplier's password.")]
        public string Supplier_Password { get; set; }
    }
}