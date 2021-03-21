using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Bookshelf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();
        private BooksModel BooksModel { get; } = new BooksModel();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModels.BookListViewModel bookListViewModel = new ViewModels.BookListViewModel(BooksModel);
            WindowService.Show(bookListViewModel);

        }
    }
}
