using FluentValidation;

namespace FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel
{
    public class ProductUpdateDTOValidator : AbstractValidator<ProductUpdateDTO>
    {
        public ProductUpdateDTOValidator()
        {
            Include(new ProductBaseDTOValidator<ProductUpdateDTO>());

            RuleFor(p => p.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0");
        }
    }
}
