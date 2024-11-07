namespace FirstCoreMVCWebApplication.Models.ProductModel
{
    public class ProductService
    {
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Apple iPhone 13", Category = ProductCategory.Electronics, Price = 99, DateAdded = DateTime.Now.AddDays(-10)},
                new Product { Id = 2, Name = "Samsung Galaxy S21", Category = ProductCategory.Electronics, Price = 899, DateAdded = DateTime.Now.AddDays(-11) },
                new Product { Id = 3, Name = "Sony WH-1000XM4 Headphones", Category = ProductCategory.Accessories, Price = 349, DateAdded = DateTime.Now.AddDays(-12) },
                new Product { Id = 4, Name = "Apple MacBook Pro 16\"", Category = ProductCategory.Computers, Price = 2399, DateAdded = DateTime.Now.AddDays(-13) },
                new Product { Id = 5, Name = "Dell XPS 13 Laptop", Category = ProductCategory.Computers, Price = 1099, DateAdded = DateTime.Now.AddDays(-14) },
                new Product { Id = 6, Name = "Amazon Echo Dot (4th Gen)", Category = ProductCategory.SmartHome, Price = 49, DateAdded = DateTime.Now.AddDays(-15) },
                new Product { Id = 7, Name = "Apple Watch Series 7", Category = ProductCategory.Wearables, Price = 399, DateAdded = DateTime.Now.AddDays(-12) },
                new Product { Id = 8, Name = "Google Nest Thermostat", Category = ProductCategory.SmartHome, Price = 129, DateAdded = DateTime.Now.AddDays(-10) },
                new Product { Id = 9, Name = "Fitbit Charge 5", Category = ProductCategory.Wearables, Price = 179, DateAdded = DateTime.Now.AddDays(-2) },
                new Product { Id = 10, Name = "Bose QuietComfort 35 II", Category = ProductCategory.Accessories, Price = 299, DateAdded = DateTime.Now.AddDays(-11) },
                new Product { Id = 11, Name = "Nikon D3500 DSLR Camera", Category = ProductCategory.Cameras, Price = 499, DateAdded = DateTime.Now.AddDays(-2) },
                new Product { Id = 12, Name = "Sony PlayStation 5", Category = ProductCategory.Gaming, Price = 499, DateAdded = DateTime.Now.AddDays(-11) },
                new Product { Id = 13, Name = "Microsoft Xbox Series X", Category = ProductCategory.Gaming, Price = 499, DateAdded = DateTime.Now.AddDays(-10) },
                new Product { Id = 14, Name = "Apple AirPods Pro", Category = ProductCategory.Accessories, Price = 249, DateAdded = DateTime.Now.AddDays(-8) },
                new Product { Id = 15, Name = "JBL Flip 5 Bluetooth Speaker", Category = ProductCategory.Audio, Price = 119, DateAdded = DateTime.Now.AddDays(-7) },
                new Product { Id = 16, Name = "Canon EOS R6 Mirrorless Camera", Category = ProductCategory.Cameras, Price = 2499, DateAdded = DateTime.Now.AddDays(-6) },
                new Product { Id = 17, Name = "Nintendo Switch", Category = ProductCategory.Gaming, Price = 299, DateAdded = DateTime.Now.AddDays(-5) },
                new Product { Id = 18, Name = "LG 65\" OLED TV", Category = ProductCategory.HomeEntertainment, Price = 1999, DateAdded = DateTime.Now.AddDays(-4) },
                new Product { Id = 19, Name = "Samsung Galaxy Buds Pro", Category = ProductCategory.Accessories, Price = 199, DateAdded = DateTime.Now.AddDays(-3) },
                new Product { Id = 20, Name = "Asus ROG Strix Gaming Laptop", Category = ProductCategory.Computers, Price = 1499, DateAdded = DateTime.Now.AddDays(-1) }
            };
        }

        public async Task<(IEnumerable<Product> products, int totalCount)> GetProductsAsync(ProductQueryParameters queryParameters)
        {
            var products = _products.AsQueryable();

            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
                products = products.Where(x => x.Name.Contains(queryParameters.SearchTerm, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
            {
                if (Enum.TryParse(queryParameters.Category, out ProductCategory category))
                    products = products.Where(x => x.Category == category);
            }

            int productCount = products.Count();

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                    products = queryParameters.SortAscending ? products.OrderBy(x => x.Price) :
                        products.OrderByDescending(x => x.Price);

                else if (queryParameters.SortBy.Equals("data", StringComparison.OrdinalIgnoreCase))
                {
                    products = queryParameters.SortAscending ? products.OrderBy(x => x.DateAdded) :
                            products.OrderByDescending(x => x.DateAdded);
                }
            }

            products = products.Skip((queryParameters.PageNumber - 1) * queryParameters.PaseSize).Take(queryParameters.PaseSize);

            return await Task.FromResult((products.ToList(), productCount));


        }




    }
}
