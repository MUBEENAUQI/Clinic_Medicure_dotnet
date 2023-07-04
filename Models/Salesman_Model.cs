using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Automation.Models
{
    public class Salesman_Model
    {
        public int? Salesman_id { get; set; }
        public int? Login_id { get; set; }

        [Required(ErrorMessage = "Please enter the Salesman's name.")]
        public string Salesman_name { get; set; }


        [Required(ErrorMessage = "Please enter the Salesman's phone number.")]
        public string Salesman_Phone { get; set; }

        [Required(ErrorMessage = "Please enter the Salesman's email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Salesman_Email { get; set; }

        [Required(ErrorMessage = "Please select the Salesman's Gender")]

        public string Salesman_Gender { get; set; }

        [Required(ErrorMessage = "Please enter the Salesman's username.")]
        public string Salesman_Username { get; set; }

        [Required(ErrorMessage = "Please enter the Salesman's password.")]
        public string Salesman_Password { get; set; }
    }
}