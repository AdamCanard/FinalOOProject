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

        // Searches the Books list by each individual parameter
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

        // Searches the Books list using a single search query
        public static List<Book> SearchBooksGeneric(string searchQuery)
        {
            // Create empty list of books
            List<Book> foundBooks = [];
            
            // Check if search query is null or empty
            if (string.IsNullOrEmpty(searchQuery)) 
            {
                return Books;
            }

            // Iterate over each book and check search query against ISBN, Title, Author and Genre
            foreach (var book in Books)
            {
                bool foundIsbn = book.ISBN.ToString().ToLower().Contains(searchQuery.ToLower());
                bool foundTitle = book.Title.ToLower().Contains(searchQuery.ToLower());
                bool foundAuthor = book.Author.ToLower().Contains(searchQuery.ToLower());
                bool foundGenre = book.Genre.ToLower().Contains(searchQuery.ToLower());

                // If the query matches any of the parameters, add the book to the returned list
                if (foundIsbn || foundTitle || foundAuthor || foundGenre)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        // Queries the database for books with a matching ISBN number
        public static Book GetBookByISBN(int isbn)
        {
            Book retrievedBook = Database.GetBookByISBN(isbn);
            return retrievedBook;
        }

        // Adds a new book to the database
        public  static void AddNewBook(int isbn, int quant, string title, string author, string genre)
        {
            Book newBook = new(isbn, quant, title, author, genre);
            Database.AddBook(newBook);
            UpdateBooksList();
        }

        // Deletes a book from the database
        public static void DeleteBook(int isbn)
        {
            Database.DeleteBook(isbn);
            UpdateBooksList();
        }

        // Updates an existing book in the database
        public static void UpdateBook(int bookToUpdateIsbn, int? quant, string? title, string? genre)
        {
            Book bookToUpdate = GetBookByISBN(bookToUpdateIsbn);
            bookToUpdate.Quantity = quant ?? bookToUpdate.Quantity;
            bookToUpdate.Title = title ?? bookToUpdate.Title;
            bookToUpdate.Genre = genre ?? bookToUpdate.Genre;
            
            Database.UpdateBook(bookToUpdate);
            UpdateBooksList();
        }

        // Updates the local list of books using the Database
        public static void UpdateBooksList()
        {
            Books = Database.GetAllBooks();
        }
    }
}
