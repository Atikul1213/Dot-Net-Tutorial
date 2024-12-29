using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToOne.UsingDataAnnotation
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public Passport Passport { get; set; }  // Navigation property
    }
}
