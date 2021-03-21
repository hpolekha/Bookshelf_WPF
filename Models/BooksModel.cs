using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WPF_Bookshelf
{
    class BooksModel
    {
        public ObservableCollection<Book> Books { get; private set; } = new ObservableCollection<Book>();

        public BooksModel()
        {
            generateSamples();
        }

        private void generateSamples()
        {
            // Generate Bookshelf items
            Books.Add(new Book("The Little Prince", "Antoine de Saint-Exupéry", 1943, Category.Fantasy));
            Books.Add(new Book("The House at Sea’s End ", "Elly Griffiths", 2011, Category.Crime));
            Books.Add(new Book("Zero Star Hotel", "Anselm Berrigan", 2002, Category.Poetry));
            Books.Add(new Book("Leaves of Grass", "Walt Whitman", 1855, Category.Poetry));
        }

        // Add book to the collection
        public void AddBook(string title, string author, ushort year, Category category)
        {
            Book newBook = new Book(title, author, year, category);
            if (Books.IndexOf(newBook) < 0)
                Books.Add(newBook);
        }

        public void AddBook(Book book)
        {
            if (Books.IndexOf(book) < 0)
                Books.Add(book);
        }

        public void AddBook()
        {
            AddBook("title", "author", 0, Category.Fantasy);
        }

        // Delete book from the collection

        public void DeleteBook(Book book)
        {
            Books.Remove(book);
        }

        // Change category
        public void NextCategory(Book book)
        {
            int index = Books.IndexOf(book);
            if (index >= 0)
                Books[index].NextCategory();
        }
    }
}
