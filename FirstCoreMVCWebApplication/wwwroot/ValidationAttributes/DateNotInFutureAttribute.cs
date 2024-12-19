using System;

namespace FirstCoreMVCWebApplication.wwwroot.ValidationAttributes
{
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        public DateNotInFutureAttribute()
        {
            ErrorMessage = "Date of Joining cannot be in the future.";
        }

        protected override ValildationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is DateTime dateValue)
            {
                if (dateValue > DateTime.Now)
                {
                    return new ValidationResult(ErrorMeesage);
                }
            }

            else
            {
                return new ValidationResult("Invalid data type for DaateNotInFutureAttribute");
            }

            return ValidationResult.Success;
        }
    }
}
