using System;
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models
{
    public class ValidDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object Value, ValidationContext ValidationContext)
        {
            var Today = DateTime.Today;
            DateTime EnteredDate=(DateTime)Value;
            var date = Today.Year - EnteredDate.Year;
            if (date > 0)
            {
                return new ValidationResult("Date must be in the future.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}