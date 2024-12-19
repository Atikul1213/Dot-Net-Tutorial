using FirstCoreMVCWebApplication.Models.ValidationPractice;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private List<Product> listProducts;
        public OrderController()
        {
            listProducts = new List<Product>()
            {
                new Product { ProductId = 1, Name = "Laptop", Price = 999.99m },
                new Product { ProductId = 3, Name = "Mobile", Price = 300.50m },
                new Product { ProductId = 4, Name = "Desktop", Price = 1330.50m }
            };
        }

        [HttpGet]
        public IActionResult Create()
        {
            var order = new Order
            {
                OrderDate = DateTime.Today,
                Items = listProducts.Select(p => new OrderItem
                {
                    ProductId = p.ProductId,
                    Quantity = 0, // Initialize with zero, let user choose the amount
                    Price = p.Price,
                    Product = p // Link the product details directly
                }).ToList()
            };
            return View(order);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                // Reapply correct prices and link products to guard against tampering
                foreach (var item in order.Items)
                {
                    var product = listProducts.FirstOrDefault(p => p.ProductId == item.ProductId);
                    if (product != null)
                    {
                        item.Price = product.Price;
                        item.Product = product;
                    }
                }

                order.OrderTotal = CalculateOrderTotal(order);
                order.PaymentProcessed = ProcessPayment(order);

                return RedirectToAction("Success");
            }

            // Ensure products are linked if returning to view after a failed validation
            foreach (var item in order.Items)
            {
                item.Product = listProducts.FirstOrDefault(p => p.ProductId == item.ProductId);
            }

            return View(order);
        }

        private decimal CalculateOrderTotal(Order order)
        {
            decimal total = 0m;
            foreach (var item in order.Items)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

        private bool ProcessPayment(Order order)
        {
            // Assume payment processing always succeeds for this example
            return true;
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
