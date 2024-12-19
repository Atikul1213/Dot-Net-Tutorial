using System.ComponentModel.DataAnnotations;

namespace FirstCoreMVCWebApplication.Models.ValidationPractice
{
    public class WhitelistAttribute : ValidationAttribute
    {
        public string[] AllowedValues { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && AllowedValues.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"This value {value} is not allowed");
        }
    }
