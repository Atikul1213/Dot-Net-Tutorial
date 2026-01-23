using System.ComponentModel.DataAnnotations.Schema;
namespace FirstCoreMVCWebApplication.Models.LazyEagerLoading.Model
{
    public class Product : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;

        [Column(TypeName = ("decimal(18,2)"))]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Sku { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
