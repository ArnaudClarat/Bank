namespace Bank.Components.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DynamicDateRangeAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateTime dateValue)
            {
                return new ValidationResult("Invalid date format.");
            }

            var today = DateTime.Today;
            var minDate = today.AddYears(-MaxAge); // Date minimale (e.g., 180 ans en arrière)
            var maxDate = today.AddYears(-MinAge); // Date maximale (e.g., 18 ans en arrière)

            if (dateValue < minDate || dateValue > maxDate)
            {
                return new ValidationResult($"Date must be between {minDate.ToShortDateString()} and {maxDate.ToShortDateString()}.");
            }
            return ValidationResult.Success;
        }
    }

}
