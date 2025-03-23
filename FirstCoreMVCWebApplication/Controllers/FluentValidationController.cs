using FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMVCWebApplication.Controllers
{
    public class FluentValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO productDto)
        {
            var validator = new ProductCreateDTOValidator();

            var validationResult = validator.Validate(productDto);

            if (!validationResult.IsValid)
            {
                var errorResponse = validationResult.Errors.Select(e => new
                {
                    Fields = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return BadRequest(new { Errors = errorResponse });
            }

            return View(productDto);
        }
    }
}
