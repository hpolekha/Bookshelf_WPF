using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WPF_Bookshelf.MVVM
{
    public class WindowService : IWindowService
    {
        public void Show(IViewModel viewModel)
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            Uri iconUri = new Uri("https://sprzaska.zabierzow.org.pl/wp/wp-content/uploads/2020/04/check-1-icon.png", UriKind.RelativeOrAbsolute);
            window.Icon = BitmapFrame.Create(iconUri);
            window.Title = "Bookshelf";
            window.Show();
        }

        public void ShowDialog(IViewModel viewModel)
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            Uri iconUri = new Uri("https://sprzaska.zabierzow.org.pl/wp/wp-content/uploads/2020/04/check-1-icon.png", UriKind.RelativeOrAbsolute);
            window.Icon =  BitmapFrame.Create(iconUri);
            window.Title = "Book";
            window.ShowDialog();
        }
    }
}
