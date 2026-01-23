using FirstCoreMVCWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class LazyEagerController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Ctor
        public LazyEagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Eager Loading Methods

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                // STEP 1: Query Orders and eagerly load all required relationships.
                // .Include() loads one related entity.
                // .ThenInclude() allows chaining into deeper levels of relationships.
                // .AsNoTracking() improves performance for read-only data (no change tracking).

                var orders = await _context.Orders
                    .AsNoTracking()
                    .Include(o => o.Customer).ThenInclude(c => c.Profile) // Order → Customer → Profile
                    .Include(o => o.Customer).ThenInclude(c => c.Addresses)
                    .Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(p => p.Category)
                    .Include(o => o.OrderStatus)
                    .Include(o => o.ShippingAddress)
                    .Include(o => o.BillingAddress)
                    .Where(o => o.IsActive)
                    .ToListAsync();

                var result = new
                {
                    Order = orders.Select(o => new
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate.ToString("yyyy-MM-dd"),
                        Status = o.OrderStatus.Name,
                        TotalAmount = o.TotalAmount,
                        ShippingAddress = $"{o.ShippingAddress?.Line1}, {o.ShippingAddress?.City}",
                        BillingAddress = $"{o.BillingAddress?.Line1}, {o.BillingAddress?.City}",

                        Customer = new
                        {
                            CustomerId = o.Customer.CustomerId,
                            Name = o.Customer.Name,
                            Email = o.Customer.Email,
                            Phone = o.Customer.Phone,
                            DisplayName = o.Customer.Profile?.DisplayName,
                            Gender = o.Customer.Profile?.Gender,
                            DateOfBirth = o.Customer.Profile?.DateOfBirth.ToString("yyyy-MM-dd"),
                        },

                        Items = o.OrderItems.Select(oi => new
                        {
                            ProductName = oi.Product.Name,
                            Category = oi.Product.Category.Name,
                            Quantity = oi.Quantity,
                            UnitPrice = oi.UnitPrice
                        }).ToList()
                    })
                };

            }
            catch (Exception ex)
            {

            }

            return Ok();
        }


        public async Task<IActionResult> GetFilteredOrders(int days, int minAmount)
        {
            var query = _context.Orders
                .Where(o => o.IsActive &&
                o.OrderDate >= DateTime.Now.AddDays(-days) &&
                o.TotalAmount >= minAmount &&
                o.Customer.IsActive)

                .AsNoTracking()
                .Include(o => o.Customer).ThenInclude(c => c.Profile)
                .Include(o => o.OrderItems.Where(i => i.Product.IsActive))
                .ThenInclude(i => i.Product).ThenInclude(p => p.Category)
                .Include(o => o.BillingAddress)
                .Include(o => o.ShippingAddress);

            var orders = await query.ToListAsync();

            var result = orders.Select(o => new
            {
                o.OrderId,
                o.OrderDate,
                o.TotalAmount,
                Customer = o.Customer.Name,
                Profile = o.Customer.Profile?.DisplayName,
                Cities = o.Customer.Addresses?.Select(a => a.City).ToList(),
                ProductNames = o.OrderItems.Select(i => i.Product.Name).ToList(),
                ItemCount = o.OrderItems.Count
            });

            return Ok();
        }


        #endregion

        #region Lazy Loading Methods

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCustomerById(int id)
        {
            // STEP 1: Fetch only the Customer entity by primary key.
            // Lazy loading ensures that related entities are NOT loaded at this point.
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            // Load Profile automatically when accessed
            // EF triggers a SELECT for Profile table
            var profile = customer.Profile;

            var addresses = customer.Addresses;

            var orders = customer.Orders;

            var result = new
            {
                customer.CustomerId,
                customer.Name,
                customer.Email,
                customer.Phone,

                Profile = profile == null ? null : new
                {
                    profile.DisplayName,
                    profile.Gender,
                    DateOfBirth = profile.DateOfBirth.ToString("yyyy-MM-dd")
                },

                Addresses = addresses?.Select(a => new
                {
                    a.AddressId,
                    a.Line1,
                    a.Street,
                    a.City,
                    a.PostalCode,
                    a.Country
                }).ToList(),

                Orders = orders?.Select(o => new
                {
                    o.OrderId,
                    OrderDate = o.OrderDate.ToString("yyyy-MM-dd"),
                    o.TotalAmount,
                    Status = o.OrderStatus?.Name,
                    Items = o.OrderItems?.Select(oi => new
                    {
                        oi.ProductId,
                        ProductName = oi.Product.Name,
                        Category = oi.Product.Category.Name,
                        oi.Quantity,
                        oi.UnitPrice
                    })
                }).ToList()
            };
            return Ok(result);
        }

        public async Task<IActionResult> DemonstrateLazyLoadingBehaviour(int id)
        {
            // STEP 1: Retrieve only the main Customer entity.
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            // STEP 2: DISABLE Lazy Loading
            _context.ChangeTracker.LazyLoadingEnabled = false;


            // Accessing navigation properties now will NOT trigger SQL queries.
            var profileWhenDisabled = customer.Profile;      // Will remain NULL
            var addressesWhenDisabled = customer.Addresses;  // Will remain NULL
            var ordersWhenDisabled = customer.Orders;        // Will remain NULL

            // STEP 3: ENABLE Lazy Loading
            _context.ChangeTracker.LazyLoadingEnabled = true;
            var profileWhenEnabled = customer.Profile;
            var addressesWhenEnabled = customer.Addresses;
            var ordersWhenEnabled = customer.Orders;

            var result = new
            {
                LazyLoadingInitiallyDisabled = new
                {
                    Message = "Lazy Loading Disabled — Related entities are NOT fetched automatically.",
                    Profile = profileWhenDisabled == null ? "Not Loaded" : "Loaded",
                    Address = addressesWhenDisabled == null ? "Not Loaded" : "Loaded",
                    Orders = ordersWhenDisabled == null ? "Not Loaded" : "Loaded"
                },

                LazyLoadingAfterEnabled = new
                {
                    Message = "Lazy Loading Enabled — Related entities are automatically fetched when accessed.",
                    Profile = profileWhenEnabled == null ? "Null" : profileWhenEnabled.DisplayName,
                    AddressCount = addressesWhenEnabled?.Count,
                    OrderCount = ordersWhenEnabled?.Count
                }
            };

            return Ok();
        }


        public IActionResult DemonstrateNPlusOneProblem()
        {
            // STEP 1: Load all customers from the database (1 SQL query executed here)
            var customers = _context.Customers.ToList();

            // Lazy Loading triggers a NEW SQL query per customer.
            // So if there are 100 customers, 100 additional SELECT queries are fired!
            var result = customers.Select(c => new
            {
                c.CustomerId,
                c.Name,
                ProfileName = c.Profile?.DisplayName, // Triggers SQL query per customer
            }).ToList();


            return Ok(result);
        }


        public IActionResult FixNPlusOneProblem()
        {
            // STEP 1: Use Eager Loading to include related entities in one go.
            // Even though we will not return Profile data, EF Core loads it efficiently
            // in the same query — preventing N additional round trips.
            var customer = _context.Customers
                .Include(c => c.Profile)
                .AsNoTracking()
                .ToList();

            // STEP 2: Project only Customer data (no related data returned).
            var result = customer.Select(c => new
            {
                c.CustomerId,
                c.Name,
                c.Email,
                c.Phone
            }).ToList();

            return Ok(result);
        }


        public IActionResult FixSerializationIssue()
        {
            var customers = _context.Customers
                .AsNoTracking()
                 .Select(c => new
                 {
                     c.CustomerId,
                     c.Name,
                     c.Email,
                     c.Phone
                 }).ToList();

            return Ok(customers);
        }

        #endregion


        #region Explicit Loading Method

        public async Task<IActionResult> GetOrderWithExplicitLoading(int id)
        {
            // STEP 1: Load only the main entity first.
            var order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound($"Order with Id{id} not found");

            // STEP 2: Load related entities explicitly when required.

            // Load Customer reference
            await _context.Entry(order).Reference(o => o.Customer).LoadAsync();

            // Load OrderItems collection
            await _context.Entry(order).Collection(o => o.OrderItems).LoadAsync();

            await _context.Entry(order).Reference(o => o.OrderStatus).LoadAsync();

            // Load nested relationship: OrderItems → Product → Category
            foreach (var item in order.OrderItems)
            {
                await _context.Entry(item).Reference(i => i.Product).LoadAsync();
                await _context.Entry(item.Product).Reference(p => p.Category).LoadAsync();
            }

            var response = new
            {
                order.OrderId,
                order.OrderDate,
                order.TotalAmount,
                Status = order.OrderStatus?.Name,
                Customer = order.Customer == null ? null : new
                {
                    order.Customer.CustomerId,
                    order.Customer.Name,
                    order.Customer.Email,
                    order.Customer.Phone
                },
                Items = order.OrderItems?.Select(i => new
                {
                    i.ProductId,
                    ProductName = i.Product?.Name,
                    Category = i.Product?.Category?.Name,
                    i.Quantity,
                    i.UnitPrice
                })
            };

            return Ok(response);
        }


        public async Task<IActionResult> GetHIghValueOrderExplicit()
        {

            var orders = await _context.Orders
                .Where(o => o.IsActive && o.OrderDate >= DateTime.Now.AddDays(-30))
                .AsNoTracking()
                .ToListAsync();

            var activeCustomerIds = orders.Select(o => o.CustomerId)
                .Distinct().ToList();


            var activeCustomers = await _context.Customers
                .Where(c => activeCustomerIds.Contains(c.CustomerId) && c.IsActive)
                .AsNoTracking()
                .ToListAsync();

            foreach (var order in orders)
            {
                order.Customer = activeCustomers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
            }


            foreach (var order in orders)
            {
                await _context.Entry(order)
                    .Collection(o => o.OrderItems)
                    .Query()
                    .Where(i => i.Quantity >= 3 && i.Product.IsActive)
                    .Include(i => i.Product)
                    .LoadAsync();
            }

            var filterOrders = orders
                .Where(o => o.Customer != null && o.OrderItems.Any())
                .Select(o => new
                {
                    o.OrderId,
                    CustomerName = o.Customer.Name,
                    FilteredItemCount = o.OrderItems.Count,
                    TotalAmount = o.TotalAmount
                }).ToList();


            return Ok();
        }
        #endregion
    }
}
