using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace WPF_Bookshelf.ViewModels.Validators
{
    class YearValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Year cannot be null or empty
            if (String.IsNullOrEmpty((String)value))
            {
                    return new ValidationResult(false, "Pease enter a year.");
            }

            if (!UInt16.TryParse(value.ToString(), out ushort year) || year > 2100)
            {
                return new ValidationResult(false, "Pease enter a number from 0 to 2100.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
