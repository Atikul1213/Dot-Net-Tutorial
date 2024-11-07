using FirstCoreMVCWebApplication.Models.ProductModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class ProductController : Controller
    {
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
    }
}
