using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.ValidationPractice
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the first name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select a department.")]
        public Department? Department { get; set; }
    }
}
