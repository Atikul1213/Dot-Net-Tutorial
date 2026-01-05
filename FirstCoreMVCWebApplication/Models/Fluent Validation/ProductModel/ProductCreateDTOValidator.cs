using FluentValidation;

namespace FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel
{
    public class ProductCreateDTOValidator : AbstractValidator<ProductCreateDTO>
    {
        public ProductCreateDTOValidator()
        {
            Include(new ProductBaseDTOValidator<ProductCreateDTO>());
        }
    }
}
