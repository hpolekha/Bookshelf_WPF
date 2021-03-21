using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace WPF_Bookshelf.ViewModels.Validators
{
    class AuthorValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Author cannot be null or empty
            if (String.IsNullOrEmpty((String)value))
            {
                return new ValidationResult(false, "Pease enter an author.");
            }
            // Author name cannot be shourter than 3 symbolr=s
            if ((value.ToString()).Length < 3)
            {
                return new ValidationResult(false, "The name is too short. Author's name has to contain at least 4 letters.");
            } 
            return ValidationResult.ValidResult;
        }
    }
}
