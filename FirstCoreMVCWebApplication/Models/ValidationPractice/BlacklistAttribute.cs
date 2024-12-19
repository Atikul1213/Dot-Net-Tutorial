using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.ValidationPractice
{
    public class BlacklistAttribute : ValidationAttribute
    {
        public string[] DisallowedValues { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;
            if (string.IsNullOrEmpty(email))
            {
                return ValidationResult.Success;
            }

            var domain = email.Split('@').LastOrDefault();
            if (domain != null && DisallowedValues.Contains(domain, StringComparer.OrdinalIgnoreCase))
                return new ValidationResult($"The domain {domain} is not allowed");

            return ValidationResult.Success;
        }
    }
}
