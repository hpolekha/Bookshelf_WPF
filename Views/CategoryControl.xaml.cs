using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Bookshelf.Views
{
    /// <summary>
    /// Interaction logic for CategoryControl.xaml
    /// </summary>
     public partial class CategoryControl : UserControl
    {
        public CategoryControl()
        {
            InitializeComponent();
        }


        #region ImageSourceProperty
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CategoryControl), new FrameworkPropertyMetadata(null));

        public ImageSource ImageSource
        {
            get { return GetValue(ImageSourceProperty) as ImageSource; }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion

    }
}
