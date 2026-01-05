using FirstCoreMVCWebApplication.Data;
using FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel;
using FirstCoreMVCWebApplication.Models.ProductModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion

        #region Ctor
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public async Task<IActionResult> Index([FromQuery] ProductQueryParameters queryParameters)
        {
            var productService = new ProductService();

            var (products, totalCount) = await productService.GetProductsAsync(queryParameters);

            var categories = Enum.GetValues(typeof(ProductCategory)).Cast<ProductCategory>()
                                .Select(category =>
                                new SelectListItem
                                {
                                    Text = category.ToString(),
                                    Value = category.ToString()
                                }).ToList();

            ViewBag.Categories = categories;
            ViewBag.Title = "Products";
            var sortOptions = new List<SelectListItem>()
            {
                new SelectListItem{ Text = "Price", Value = "Price" },
                new SelectListItem { Text = "Date" , Value = "Date Added"}
            };
            ViewBag.SortOptions = sortOptions;

            var pageSizeOption = new List<SelectListItem>()
            {
                new SelectListItem { Text = "3", Value = "3" },
                new SelectListItem { Text = "5", Value = "5" },
                new SelectListItem { Text = "10", Value = "10" },
                new SelectListItem { Text = "20", Value = "20" },
                new SelectListItem { Text = "25", Value = "25" },
            };


            var viewModel = new ProductListViewModel()
            {
                products = products,
                PageNumber = queryParameters.PageNumber,
                PageSize = queryParameters.PaseSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / queryParameters.PaseSize),
                SearchTerm = queryParameters.SearchTerm,
                Category = queryParameters.Category,
                SortBy = queryParameters.SortBy,
                SortAscending = queryParameters.SortAscending,
                Categories = categories,
                SortOptions = sortOptions,
                PageSizeOptions = pageSizeOption,
            };
            return View(viewModel);
        }


        [HttpGet]
        public async Task<ActionResult<ProductUpdateDTO>> GetProducts([FromQuery] string? tags)
        {
            IQueryable<Models.Fluent_Validation.ProductModel.Product> query = _context.Products.AsNoTracking()
                .Include(p => p.Tags);

            if (!string.IsNullOrEmpty(tags))
            {
                var tagList = tags.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => t.Trim().ToLower()).ToList();

                query = query.Where(p => p.Tags.Any(t =>
                    tagList.Contains(t.Name.ToLower())));
            }

            var products = await query.ToListAsync();

            var result = products.Select(p => new ProductUpdateDTO
            {
                ProductId = p.ProductId,
                SKU = p.SKU,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Discount = p.Discount,
                ManufacturingDate = p.ManufacturingDate,
                ExpiryDate = p.ExpiryDate,
                Tags = p.Tags.Select(t => t.Name).ToList()
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCreateDTO>> CreateProduct([FromBody] ProductCreateDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Models.Fluent_Validation.ProductModel.Product()
            {
                SKU = productDto.SKU,
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                Discount = productDto.Discount,
                ManufacturingDate = productDto.ManufacturingDate,
                ExpiryDate = productDto.ExpiryDate
            };

            if (productDto.Tags != null && productDto.Tags.Any())
            {
                foreach (var tagName in productDto.Tags)
                {
                    var normalizedTagName = tagName.Trim().ToLower();
                    var existingTag = await _context.Tags.FirstOrDefaultAsync(t =>
                        t.Name.ToLower() == normalizedTagName);

                    if (existingTag != null)
                        product.Tags.Add(existingTag);
                    else
                        product.Tags.Add(new Tag { Name = normalizedTagName });
                }
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var response = new ProductUpdateDTO
            {
                ProductId = product.ProductId,
                SKU = product.SKU,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Discount = product.Discount,
                ManufacturingDate = product.ManufacturingDate,
                ExpiryDate = product.ExpiryDate,
                Tags = product.Tags.Select(t => t.Name).ToList()
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductUpdateDTO>> UpdateProduct(int id,
            [FromBody] ProductUpdateDTO productDto)
        {

            if (id != productDto.ProductId)
                return BadRequest(new { error = "Product Id in URL and body do not match." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Products
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            product.SKU = productDto.SKU;
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            product.CategoryId = productDto.CategoryId;
            product.Description = productDto.Description;
            product.Discount = productDto.Discount;
            product.ManufacturingDate = productDto.ManufacturingDate;
            product.ExpiryDate = productDto.ExpiryDate;

            product.Tags.Clear();

            if (productDto.Tags != null && productDto.Tags.Any())
            {
                foreach (var tagName in productDto.Tags)
                {
                    var normalizedTagName = tagName.Trim().ToLower();

                    var existingTag = await _context.Tags.FirstOrDefaultAsync(t =>
                    t.Name.ToLower() == normalizedTagName);

                    if (existingTag != null)
                        product.Tags.Add(existingTag);
                    else
                        product.Tags.Add(new Tag { Name = normalizedTagName });
                }
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            var response = new ProductUpdateDTO
            {
                ProductId = product.ProductId,
                SKU = product.SKU,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Discount = product.Discount,
                ManufacturingDate = product.ManufacturingDate,
                ExpiryDate = product.ExpiryDate,
                Tags = product.Tags.Select(t => t.Name).ToList()
            };

            return Ok(response);
        }

        #endregion
    }
}
