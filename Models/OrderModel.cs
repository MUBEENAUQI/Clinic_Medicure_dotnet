using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Automation.Models
{
    public class OrderModel
    {



        [Required(ErrorMessage = "Please enter the Medicine ID.")]
        public int medicineID { get; set; }
        public int orderID { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Please enter the Quantity Required")]
        public int? quantity { get; set; }

    }
}