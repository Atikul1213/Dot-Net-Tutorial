using FluentValidation;

namespace FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel
{
    public class ProductCreateDTOValidator : AbstractValidator<ProductCreateDTO>
    {
        public ProductCreateDTOValidator()
        {
            RuleFor(p => p.SKU)
                .NotEmpty().WithMessage("Sku is required")
                .Matches("^[A-Z0-9]{8}$").WithMessage("Sku must 8 character long and contains only uppercase letter and digits");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required")
                .Length(3, 50).WithMessage("Name must be 3 and 50 character");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0")
                .PrecisionScale(8, 2, true).WithMessage("Price must have at most 8 digits in total and 2 decimal");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("Category id is required");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Descrption can not exceed 500 characters")
                .When(p => !string.IsNullOrEmpty(p.Description));

            RuleFor(p => p.Discount)
                .InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 100");

            RuleFor(p => p.ManufacturingDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Manufacturing date can not be future");

            RuleFor(p => p.ExpiryDate)
                .GreaterThan(p => p.ManufacturingDate).WithMessage("Expiry date must be after the manufacturing date");

            RuleForEach(p => p.Tags).ChildRules(tag =>
            {
                tag.RuleFor(t => t)
                .NotEmpty().WithMessage("Tag cannot be empty")
                .MaximumLength(20).WithMessage("Tag cannot exceed 20 characters");
            });
        }
    }
}
