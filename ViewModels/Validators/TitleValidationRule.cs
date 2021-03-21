using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace WPF_Bookshelf.ViewModels.Validators
{
    class TitleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Title cannot be ull or empty
            //if (value is null || String.IsNullOrEmpty(value.ToString())){
            if (value is null || String.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Pease enter a title.");
            }

            return ValidationResult.ValidResult;
        }

        


    }
}
