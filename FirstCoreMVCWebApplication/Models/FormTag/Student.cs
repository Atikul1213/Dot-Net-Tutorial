using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.FormTag
{
    public class Student
    {
        public Student()
        {
            Hobbies = new List<string>();
            Skills = new List<string>();
        }
        public int StudentId { get; set; }
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Address is requied")]
        [StringLength(500)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public Branch Branch { get; set; }
        public bool TermsAndConditions { get; set; }
        public List<string> Hobbies { get; set; }
        [Required(ErrorMessage = "At least one skill required")]
        public List<string> Skills { get; set; }
    }
}
