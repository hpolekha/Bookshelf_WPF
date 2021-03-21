using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace WPF_Bookshelf.Views
{
    class CategoryToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // return "Images/Fantasy.jpg";

            if (value is null || (Category)value == Category.Fantasy)
            {
                return "Images/Fantasy.jpg";
                //return "Images/Fantasy3.jpg";

            }
            else
            {
                if ((Category)value == Category.Poetry)
                {
                    return "Images/Poetry.jpg";
                    //return "Images/poetry.png";

                }
                else // Crime
                {
                    return "Images/Crime.jpg";
                    //return "Images/crime.png";

                }
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}

