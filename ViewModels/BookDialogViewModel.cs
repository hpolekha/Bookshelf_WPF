using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Bookshelf.MVVM;
using System.ComponentModel;
using System.Windows;

namespace WPF_Bookshelf.ViewModels
{
    class BookDialogViewModel : IViewModel, INotifyPropertyChanged
    {
        //public bool dialogResult;
        public event PropertyChangedEventHandler PropertyChanged;
        // Closing action
        public Action Close { get; set; }
        private BooksModel BooksModel{ get; set; }
        private Book Book { get; set; }

        // Psroperties
        public string Title { get; set; }

        public string Author { get; set; }
        public ushort Year { get; set; }
        public Category Category { get; set; }

        // Commands
        public RelayCommand<BookDialogViewModel> OkCommand { get; } = new RelayCommand<BookDialogViewModel>
        (
                (bookDialogViewModel) => {

                    if (bookDialogViewModel.Title !=null && !String.IsNullOrEmpty(bookDialogViewModel.Title)
                    && bookDialogViewModel.Author != null && !String.IsNullOrEmpty(bookDialogViewModel.Author) && (bookDialogViewModel.Author).Length > 3
                    && (bookDialogViewModel.Year >= 0 || bookDialogViewModel.Year <= 2100))
                    {
                       bookDialogViewModel.Ok();
                    }     
                }
        );
        public RelayCommand<BookDialogViewModel> CancelCommand { get; } = new RelayCommand<BookDialogViewModel>
        (
            (bookDialogViewModel) => { bookDialogViewModel.Cancel(); }
        );
        public RelayCommand<BookDialogViewModel> NextCategoryCommand { get; } = new RelayCommand<BookDialogViewModel>
        (
            (bookDialogViewModel) => { bookDialogViewModel.NextCategory(); }
        );

        public BookDialogViewModel(Book book, BooksModel booksModel )
        {
            Book = book;
            BooksModel = booksModel;
            if(Book != null)
            {
                Title = book.Title;
                Author = book.Author;
                Year = book.Year;
                Category = book.Category;
            }
            //dialogResult = false;
        }

        // Approval handling
        public void Ok()
        {

            if (Book != null) // edit book
            {
                Book.Title = Title;
                Book.Author = Author;
                Book.Year = Year;
                Book.Category = Category;
            }
            else //create a book
            {
                BooksModel.Books.Add(new Book(Title, Author, Year, Category));
            }

            //dialogResult = true;

            // close viewModel
            Close?.Invoke();
        }

        public void Cancel()
        {
            // close viewModel
            Close?.Invoke();
        }

        public void NextCategory()
        {
            if (Category == Category.Fantasy)
            {
                Category = Category.Poetry;
            }
            else if (Category == Category.Poetry)
            {
                Category = Category.Crime;
            }
            else
            {
                Category = Category.Fantasy;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category"));

        }

        public string DisplayedImage
        {
            get { return "/AssemblyName;component/Images/Fantasy.jpg";  }
        }

    }
}
