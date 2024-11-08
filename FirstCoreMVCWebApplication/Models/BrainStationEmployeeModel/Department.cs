using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Department name should be between 2 and 50 characters")]
        public string Name { get; set; }
    }
}
