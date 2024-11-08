using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel
{
    public class JobTitle
    {
        [Key]
        public int JobTitleId { get; set; }
        [Required]
        [StringLength(100)]
        public string TitleName { get; set; }
    }
}
