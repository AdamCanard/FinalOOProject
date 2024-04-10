using OOProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProject
{
    public class DatabaseManager
    {
        private SQLiteConnection database;

        public DatabaseManager()
        {
            Console.WriteLine(Constants.DatabasePath);
            this.database = new SQLiteConnection(Constants.DatabasePath);

        }

        //add new Book
        public void AddBook(Book book)
        {
            this.database.Insert(book);
        }

        //delete book
        public void DeleteBook(int ISBN)
        {
            this.database.Delete<Book>(ISBN);
        }

        //update Book
        public void UpdateBook(Book book)
        {
            this.database.Update(book);
        }

        //get list of all books
        public List<Book> GetAllBooks()
        {
            return this.database.Table<Book>().ToList();
        }

        //get books by ISBN
        public Book GetBookByISBN(int ISBN)
        {
            return this.database.Table<Book>().Where(book => book.ISBN == ISBN).FirstOrDefault();
        }

        //add new fine
        public void AddFine(Fine fine)
        {
            this.database.Insert(fine);
        }

        //delete fine
        public void DeleteFine(int fineID)
        {
            this.database.Delete<Fine>(fineID);
        }

        //update fine
        public void UpdateFine(Fine fine)
        {
            this.database.Update(fine);
        }

        //get list of all fines
        public List<Fine> GetAllFines()
        {
            return this.database.Table<Fine>().ToList();
        }

        //get fine by id
        public Fine GetFineByID(int id)
        {
            return this.database.Table<Fine>().Where(fine => fine.FineId == id).FirstOrDefault();
        }

        //add new rental
        public void AddRental(Rental rental)
        {
            this.database.Insert(rental);
        }

        //delete rental
        public void DeleteRental(int rentalID)
        {
            this.database.Delete<Rental>(rentalID);
        }

        //update Rental
        public void UpdateRental(Rental rental)
        {
            this.database.Update(rental);
        }

        //get list of all rentals
        public List<Rental> GetAllRental()
        {
            return this.database.Table<Rental>().ToList();
        }

        //get rental by id
        public Rental GetRentalByID(int id)
        {
            return this.database.Table<Rental>().Where(rental => rental.RentalID == id).FirstOrDefault();
        }

    }
}
