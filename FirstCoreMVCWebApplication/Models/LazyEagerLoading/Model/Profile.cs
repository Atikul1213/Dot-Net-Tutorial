using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.LazyEagerLoading.Model
{
    public class Profile : BaseAuditableEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
