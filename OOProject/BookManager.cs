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

        public  static void AddNewBook(int isbn, int quant, string title, string author, string cat)
        {
            Book newBook = new(isbn, quant, title, author, cat);
            Database.AddBook(newBook);
            Books = Database.GetAllBooks();
            return;
        }
    }
}
