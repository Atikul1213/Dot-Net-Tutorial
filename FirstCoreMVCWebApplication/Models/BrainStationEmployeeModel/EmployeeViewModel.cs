using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name should be between 2 and 30")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, ErrorMessage = "Last name cannot exceed 30 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Joining Date is required")]
        [DataType(DataType.Date)]
        [DisplayName("Joining Date")]
        public DateTime? JoiningDate { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Gender? Gender { get; set; }
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
        [Display(Name = "Postal or Zip Code")]
        public string PostalCode { get; set; }

        // Job Details
        [Required(ErrorMessage = "Job Title is required")]
        [Display(Name = "Job Title")]
        public int SelectedJobTitleId { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [DataType(DataType.Currency)]
        [Range(30000, 200000, ErrorMessage = "Salary must be between 30,000 and 200,000")]
        public decimal Salary { get; set; }
        [Display(Name = "Skills")]
        public List<int> SkillSetIds { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        // Lists for Dropdowns and Radio Buttons
        public IEnumerable<SelectListItem>? Departments { get; set; }
        public IEnumerable<SelectListItem>? SkillSets { get; set; }
        public IEnumerable<Gender>? Genders { get; set; }
        public IEnumerable<SelectListItem>? JobTitles { get; set; }

    }
}
