using System;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Automation.Models
{
    public class MedicineModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must not exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(50, ErrorMessage = "Manufacturer must not exceed 50 characters")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Dosage is required")]
        [StringLength(50, ErrorMessage = "Dosage must not exceed 50 characters")]
        public string Dosage { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Expiry Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Expiry Date must be a valid date")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value")]
        public int Quantity { get; set; }
    }
}
