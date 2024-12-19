using FluentValidation;

namespace FirstCoreMVCWebApplication.Models.Fluent_Validation
{
    public class RegistrationValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is Required")
                .Length(5, 30).WithMessage("Username must be between 5 and 30 character");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Valid email address is required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(6, 100).WithMessage("Password must be between 6 and 100 character");
        }
    }
}
