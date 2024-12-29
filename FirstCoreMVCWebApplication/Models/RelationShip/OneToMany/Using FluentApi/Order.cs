namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToMany.Using_FluentApi
{
    public class Order
    {
        public int Id { get; set; } // Primary Key
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; } // Navigation property
    }
}
