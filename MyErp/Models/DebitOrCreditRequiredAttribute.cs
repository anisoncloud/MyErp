using System;
using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DebitOrCreditRequiredAttribute : ValidationAttribute
    {
        /*protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var line = validationContext.ObjectInstance as JournalLine;
            if (line == null)
            {
                // attribute applied to something else — treat as success or return error
                return ValidationResult.Success;
            }

            // Safe extraction (works if Debit/Credit are decimal?).
            decimal debit = line.Debit.GetValueOrDefault(0m);
            decimal credit = line.Credit.GetValueOrDefault(0m);

            if (debit == 0m && credit == 0m)
                return new ValidationResult("Either Debit or Credit must be entered.", new[] { nameof(JournalLine.Debit), nameof(JournalLine.Credit) });

            if (debit > 0m && credit > 0m)
                return new ValidationResult("You cannot enter both Debit and Credit in the same line.", new[] { nameof(JournalLine.Debit), nameof(JournalLine.Credit) });

            return ValidationResult.Success;
        }*/
    }

}
