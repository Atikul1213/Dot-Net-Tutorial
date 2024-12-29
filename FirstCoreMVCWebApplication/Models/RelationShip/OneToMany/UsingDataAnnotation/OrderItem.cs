using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToMany.UsingDataAnnotation
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; } // FK, Required Relationship
        public Order Order { get; set; } // Navigation property
    }
}
