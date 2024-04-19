using OOProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProject
{
    public static class BookManager
    {
        public static DatabaseManager Database = new();
        public static List<Book> Books = new(Database.GetAllBooks());

        public static List<Book> SearchBooksPerParameter(string? isbn, string? title, string? author, string? genre)
        {
            List<Book> foundBooks = [];
            foreach (Book book in Books)
            {
                bool foundIsbn = book.ISBN.ToString().ToLower().Contains((isbn ?? book.ISBN.ToString()).ToLower());
                bool foundTitle = book.Title.ToLower().Contains((title ?? book.Title).ToLower());
                bool foundAuthor = book.Author.ToLower().Contains((author ?? book.Author).ToLower());
                bool foundGenre = book.Genre.ToLower().Contains((genre ?? book.Genre).ToLower());

                if (foundIsbn && foundTitle && foundAuthor && foundGenre)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public static List<Book> SearchBooksGeneric(string searchQuery)
        {
            List<Book> foundBooks = [];
            if (string.IsNullOrEmpty(searchQuery)) 
            {
                return Books;
            }

            foreach (var book in Books)
            {
                bool foundIsbn = book.ISBN.ToString().ToLower().Contains(searchQuery.ToLower());
                bool foundTitle = book.Title.ToLower().Contains(searchQuery.ToLower());
                bool foundAuthor = book.Author.ToLower().Contains(searchQuery.ToLower());
                bool foundGenre = book.Genre.ToLower().Contains(searchQuery.ToLower());

                if (foundIsbn || foundTitle || foundAuthor || foundGenre)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public static Book GetBookByISBN(int isbn)
        {
            Book retrievedBook = Database.GetBookByISBN(isbn);
            return retrievedBook;
        }

        public  static void AddNewBook(int isbn, int quant, string title, string author, string genre)
        {
            Book newBook = new(isbn, quant, title, author, genre);
            Database.AddBook(newBook);
            UpdateBooksList();
        }

        public static void DeleteBook(int isbn)
        {
            Database.DeleteBook(isbn);
            UpdateBooksList();
        }

        public static void UpdateBook(int bookToUpdateIsbn, int? quant, string? title, string? author, string? genre)
        {
            Book bookToUpdate = GetBookByISBN(bookToUpdateIsbn);
            bookToUpdate.Quantity = quant ?? bookToUpdate.Quantity;
            bookToUpdate.Title = title ?? bookToUpdate.Title;
            bookToUpdate.Author = author ?? bookToUpdate.Author;
            bookToUpdate.Genre = genre ?? bookToUpdate.Genre;
            
            Database.UpdateBook(bookToUpdate);
            UpdateBooksList();
        }

        public static void UpdateBooksList()
        {
            Books = Database.GetAllBooks();
        }
    }
}
