using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel
{

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public JobDetail JobDetail { get; set; }
        public ICollection<SkillSet> SkillSets { get; set; }
    }
}
