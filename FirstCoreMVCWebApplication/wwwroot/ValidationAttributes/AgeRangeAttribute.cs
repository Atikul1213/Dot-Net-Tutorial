using System;

namespace FirstCoreMVCWebApplication.wwwroot.ValidationAttributes
{
    public class AgeRangeAttribute : ValidationAttribute
    {

        private readonly int _minAge;
        private readonly int _maxAge;

        public AgeRangeAttribute(int minAge, int maxAge)
        {
            if (minAge < 0)
                throw new ArgumentOutOfRangeException(nameof(minAge), "Minimum age cannot be negative");

            if (maxAge < minAge)
                throw new ArgumentOutofRangeException(nameof(maxAge), "Maximum age cannot be less than minimum age.");

            _minAge = minAge;
            _maxAge = maxAge;

            ErrorMessage = $"Age must be between {minAge} and {maxAge}";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var age = DateTime.Now.Year - dateOfBirth.Year;
                if (age < _minAge || age > _maxAge)
                    return new ValidationResult($"Employee age must be between {_minAge} and {_maxAge}");
            }
            return ValidationResult.Success;
        }



    }
}
