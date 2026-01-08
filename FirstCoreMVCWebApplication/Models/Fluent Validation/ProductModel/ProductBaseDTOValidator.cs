using FirstCoreMVCWebApplication.Data;
using FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Models.Fluent_Validation
{
    public class ProductBaseDTOValidator<T> : AbstractValidator<T> where T :
        ProductBaseDTO
    {
        private readonly ApplicationDbContext _context;
        public ProductBaseDTOValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(p => p.SKU)
                .NotEmpty().WithMessage("Sku is required")
                .Matches("^[A-Z0-9]{8}$").WithMessage("Sku must 8 character long and contains only uppercase letter and digits")
                .MustAsync(BeUniqueSKUAsync).WithMessage("Sku must be unique");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required")
                .Length(3, 50).WithMessage("Name must be 3 and 50 character")
                .MustAsync(BeUniqueNameAsync).WithMessage("Product name must be unique");

            #region Custom Validation

            RuleFor(p => p.Name)
                .Must(value => !string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                .WithMessage("Name must contain only alphabetic characters");

            RuleFor(p => p.SKU)
                .MustAsync(async (sku, CancellationToken) =>
                    !await _context.Products.AnyAsync(x => x.SKU == sku, CancellationToken))
                .WithMessage("SKU must be unique");

            RuleFor(p => p)
                .Custom((product1, context) =>
                {
                    if (product1.Name == product1.SKU)
                    {
                        context.AddFailure("Name", "Product name and SKU cannot be the same");
                    }
                });

            #endregion

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0")
                .PrecisionScale(8, 2, true).WithMessage("Price must have at most 8 digits in total and 2 decimal");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("Category id is required")
                .MustAsync(CategoryExistsAsync).WithMessage("Category must exist");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Descrption can not exceed 500 characters")
                .When(p => !string.IsNullOrEmpty(p.Description));

            RuleFor(p => p.Discount)
                .InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 100")
                .MustAsync(IsValidDiscountBasedOnRuleAsync).WithMessage("Discount is not valid based on business rules");

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


            #region Conditional Validation 

            RuleFor(p => p.SKU)
                .NotEmpty()
                .When(x => x.Name == "SpecialProduct")
                .WithMessage("SKU is required for SpecialProduct");

            RuleFor(p => p.Price)
                .InclusiveBetween(50, 100)
                .Unless(x => x.CategoryId == 1)
                .WithMessage("Price must be between 50 and 100 unless the product is in category 1");


            #endregion
        }

        #region Utilities

        private async Task<bool> BeUniqueNameAsync(string productName, CancellationToken cancellationToken)
        {
            return !await _context.Products.AsNoTracking()
                .AnyAsync(p => p.Name == productName, cancellationToken);
        }

        private async Task<bool> BeUniqueSKUAsync(string sku, CancellationToken cancellationToken)
        {
            return !await _context.Products.AsNoTracking()
                .AnyAsync(p => p.SKU == sku, cancellationToken);
        }

        private async Task<bool> CategoryExistsAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking()
                .AnyAsync(c => c.CategoryId == categoryId, cancellationToken);
        }

        private async Task<bool> IsValidDiscountBasedOnRuleAsync(decimal discount, CancellationToken cancellationToken)
        {
            decimal price = 150;
            if (price < 100)
            {
                return discount <= 50;
            }
            else
            {
                return discount <= 30;
            }
        }

        #endregion
    }
}
