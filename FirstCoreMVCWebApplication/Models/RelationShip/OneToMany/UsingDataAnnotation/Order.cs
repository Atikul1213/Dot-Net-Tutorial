using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToMany.UsingDataAnnotation
{
    public class Order
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; } // Navigation property
    }
}
