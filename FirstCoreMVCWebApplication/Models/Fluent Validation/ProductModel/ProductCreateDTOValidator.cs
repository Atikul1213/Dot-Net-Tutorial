using FirstCoreMVCWebApplication.Data;
using FluentValidation;

namespace FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel
{
    public class ProductCreateDTOValidator : AbstractValidator<ProductCreateDTO>
    {
        private readonly ApplicationDbContext _context;
        public ProductCreateDTOValidator(ApplicationDbContext context)
        {
            _context = context;
            Include(new ProductBaseDTOValidator<ProductCreateDTO>(_context));
        }
    }
}
