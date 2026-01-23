namespace FirstCoreMVCWebApplication.Models.LazyEagerLoading.Model
{
    public class Category : BaseAuditableEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
