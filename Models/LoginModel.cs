using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please select a department")]
        [Display(Name = "Department")]
        public int Account_id { get; set; }
        public string Account_name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Username")]
        public string User_name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }

        public List<SelectListItem> Account_List { get; set; }
        public List<SelectListItem> LoginData { get; set; }

    }
}