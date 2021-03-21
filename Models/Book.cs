using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Bookshelf
{
    class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Title
        private string title;
        public string Title {
            get { return title; }
            set {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        // Author
        private string author;
        public string Author {
            get { return author; }
            set
            {
                author = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Author"));
            }
        }

        //Year
        private ushort year;
        public ushort Year {
            get { return year; }
            set
            {
                year = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Year"));
            }
        }

        // Category
        private Category category;
        public Category Category {
            get { return category; }
            set
            {
                category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category"));
            }
        }

        public Book(string title, string autor, ushort year, Category category)
        {
            Title = title;
            Author = autor;
            Year = year;
            Category = category;
        }

        public Book(Book book)
        {
            this.Title = book.Title;
            this.Author = book.Author;
            this.Year = book.Year;
            this.Category = book.Category;
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

        }

    }
}
