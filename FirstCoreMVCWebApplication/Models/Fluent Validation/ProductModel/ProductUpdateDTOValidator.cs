using FirstCoreMVCWebApplication.Data;
using FluentValidation;

namespace FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel
{
    public class ProductUpdateDTOValidator : AbstractValidator<ProductUpdateDTO>
    {
        private readonly ApplicationDbContext _context;
        public ProductUpdateDTOValidator(ApplicationDbContext context)
        {
            _context = context;
            Include(new ProductBaseDTOValidator<ProductUpdateDTO>(_context));

            RuleFor(p => p.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0");
        }
    }
}
