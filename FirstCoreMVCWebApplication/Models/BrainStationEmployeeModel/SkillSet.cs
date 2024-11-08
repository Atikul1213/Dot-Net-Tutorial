using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel
{
    public class SkillSet
    {
        [Key]
        public int SkillSetId { get; set; }
        [Required(ErrorMessage = "Skil Name is Required")]
        [StringLength(50)]
        public string SkillName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
