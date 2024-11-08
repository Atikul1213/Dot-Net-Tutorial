﻿using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Street is required")]
        [StringLength(100, ErrorMessage = "Street cannot exceed 100 characters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters")]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$|^\d{6}$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
