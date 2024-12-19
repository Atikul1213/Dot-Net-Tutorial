using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FirstCoreMVCWebApplication.Models.ValidationPractice
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderItem
    {
        public int ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; }
        public decimal Price { get; set; } // This can be the selling price which might include discounts etc.
        [BindNever]
        public Product? Product { get; set; } // Navigation property to Product
    }
    public class Order
    {
        public int OrderId { get; set; }
        [BindRequired]
        public string CustomerName { get; set; }
        [BindRequired]
        public DateTime OrderDate { get; set; }
        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindRequired]
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }
        [BindNever]
        public bool PaymentProcessed { get; set; }
        public List<OrderItem> Items { get; set; }
    }

}
