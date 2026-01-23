namespace FirstCoreMVCWebApplication.Models.LazyEagerLoading.Model
{
    public class OrderStatus : BaseAuditableEntity
    {
        public int OrderStatusId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
