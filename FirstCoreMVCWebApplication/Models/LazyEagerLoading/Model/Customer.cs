namespace FirstCoreMVCWebApplication.Models.LazyEagerLoading.Model
{
    public class Customer : BaseAuditableEntity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual Profile? Profile { get; set; }
        public virtual ICollection<Address>? Addresses { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
