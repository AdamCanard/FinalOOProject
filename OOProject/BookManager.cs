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

        public static Book GetBookByISBN(int isbn)
        {
            Book retrievedBook = Database.GetBookByISBN(isbn);
            return retrievedBook;
        }

        public  static void AddNewBook(int isbn, int quant, string title, string author, string cat)
        {
            Book newBook = new(isbn, quant, title, author, cat);
            Database.AddBook(newBook);
            Books = Database.GetAllBooks();
        }

        public static void DeleteBook(int isbn)
        {
            Database.DeleteBook(isbn);
            Books = Database.GetAllBooks();
        }

        public static void UpdateBook(int bookToUpdateIsbn, int? quant, string? title, string? author, string? genre)
        {
            Book bookToUpdate = Database.GetBookByISBN(bookToUpdateIsbn);
            bookToUpdate.Quantity = quant ?? bookToUpdate.Quantity;
            bookToUpdate.Title = title ?? bookToUpdate.Title;
            bookToUpdate.Author = author ?? bookToUpdate.Author;
            bookToUpdate.Genre = genre ?? bookToUpdate.Genre;
            
            Database.UpdateBook(bookToUpdate);
            Books = Database.GetAllBooks();
        }
    }
}
