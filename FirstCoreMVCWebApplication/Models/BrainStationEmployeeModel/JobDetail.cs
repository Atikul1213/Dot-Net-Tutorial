using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel
{
    public class JobDetail
    {
        [Key]
        public int JodDetailId { get; set; }
        [Required(ErrorMessage = "Job title is required")]
        public int JobTitleId { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Employee is required")]
        public int EmployeeId { get; set; }
        [DataType(DataType.Currency)]
        [Range(30000, 200000, ErrorMessage = "Salary must be between 30,000 and 2,00,000")]
        public decimal Salary { get; set; }
        public Department Department { get; set; }
        public Employee Employee { get; set; }
        public JobTitle JobTitle { get; set; }

    }
}
