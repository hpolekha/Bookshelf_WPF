using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using WPF_Bookshelf.MVVM;

namespace WPF_Bookshelf.ViewModels
{
    class BookListViewModel : IViewModel, INotifyPropertyChanged
    {
        public enum Filter {
            All = 0,
            Before2000 = 1 ,
            After2000 = 2 };
        public event PropertyChangedEventHandler PropertyChanged;

        // Closing action
        public Action Close { get; set; }

        // BooksModel
        private BooksModel BooksModel { get; set; }

        // Collection
        private readonly CollectionViewSource collectionViewSource;

        //ViewSource
        public ICollectionView Books { get; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBook)));
            }
        }

        // Commands
        private RelayCommand<object> newWindowCommand;
        private RelayCommand<object> addCommand;
        private RelayCommand<object> editCommand;
        private RelayCommand<object> deleteCommand;

        public RelayCommand<object> NewWindowCommand =>
            (newWindowCommand = newWindowCommand ?? new RelayCommand<object>(o => NewWindow()));

        public RelayCommand<object> AddCommand =>
            (addCommand = addCommand ?? new RelayCommand<object>(o => AddBook()));

        public RelayCommand<object> EditCommand =>
            (editCommand = editCommand ?? new RelayCommand<object>(o => EditBook(SelectedBook), o => SelectedBook != null));

        public RelayCommand<object> DeleteCommand =>
            (deleteCommand = deleteCommand ?? new RelayCommand<object>(o => DeleteBook(SelectedBook), o => SelectedBook != null));


        // BookList managing

        public void NewWindow()
        {
            BookListViewModel bookListViewModel = new BookListViewModel(BooksModel);
            ((App)Application.Current).WindowService.Show(bookListViewModel);
        }

        public void AddBook()
        {
            BookDialogViewModel bookDialogViewModel = new BookDialogViewModel(null, BooksModel);
            ((App)Application.Current).WindowService.ShowDialog(bookDialogViewModel);
        }

        public void EditBook(Book book)
        {
            if(book != null)
            {
                BookDialogViewModel bookDialogViewModel = new BookDialogViewModel(book, BooksModel);
                string tmpTitle = book.Title;
                string tmpAuthor = book.Author;
                ushort tmpYear = book.Year;
                Category tmpCategory = book.Category;
                ((App)Application.Current).WindowService.ShowDialog(bookDialogViewModel);
                //if (bookDialogViewModel.dialogResult == false)
                //{
                //    book.Title = tmpTitle;
                //    book.Author = tmpAuthor;
                //    book.Year = tmpYear;
                //    book.Category = tmpCategory;
                //}

            }
        }

        public void DeleteBook(Book book)
        {
            if(book != null)
            {
                BooksModel.Books.Remove(book);
            }
        }


        // Filter
        private int selectedFilter = 0;
        public int SelectedFilter {
            get {
                return selectedFilter;
            }
            set
            {
                selectedFilter = value;
                UpdateFilter();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(selectedFilter)));
            }
        }
        private void UpdateFilter()
        {
            collectionViewSource.View.Refresh();
        }
        
        bool FilterBook(Book book)
        {
            return SelectedFilter == (int)Filter.All
                || (SelectedFilter == (int)Filter.Before2000 && book.Year < 2000)
                || (SelectedFilter == (int)Filter.After2000 && book.Year >= 2000);
        }

        public BookListViewModel(BooksModel booksModel)
        {
            BooksModel = booksModel;
            collectionViewSource = new CollectionViewSource
            {
                Source = BooksModel.Books
            };
            collectionViewSource.View.Filter = (o) => FilterBook((Book)o);
            SelectedFilter = 0;
            Books = collectionViewSource.View;

        }
    }
}
