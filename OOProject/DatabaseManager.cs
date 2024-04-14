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
        private SQLiteConnection Database { get; set; }

        public DatabaseManager()
        {
            Console.WriteLine(Constants.DatabasePath);
            this.Database = new SQLiteConnection(Constants.DatabasePath);

        }

        

        //add new Book
        public void AddBook(Book book)
        {
            this.Database.Insert(book);
        }

        //delete book
        public void DeleteBook(int ISBN)
        {
            this.Database.Delete<Book>(ISBN);
        }

        //update Book
        public void UpdateBook(Book book)
        {
            this.Database.Update(book);
        }

        //get list of all books
        public List<Book> GetAllBooks()
        {
            return this.Database.Table<Book>().ToList();
        }

        //get books by ISBN
        public Book GetBookByISBN(int ISBN)
        {
            return this.Database.Table<Book>().Where(book => book.ISBN == ISBN).FirstOrDefault();
        }

        //add new fine
        public void AddFine(Fine fine)
        {
            this.Database.Insert(fine);
        }

        //delete fine
        public void DeleteFine(int fineID)
        {
            this.Database.Delete<Fine>(fineID);
        }

        //update fine
        public void UpdateFine(Fine fine)
        {
            this.Database.Update(fine);
        }

        //get list of all fines
        public List<Fine> GetAllFines()
        {
            return this.Database.Table<Fine>().ToList();
        }

        public List<Fine> GetAllFinesByUser(User user)
        {
            return this.Database.Table<Fine>().Where(fine => fine.LibraryID == user.library_id).ToList();
        }

        //get fine by id
        public Fine GetFineByID(int id)
        {
            return this.Database.Table<Fine>().Where(fine => fine.FineId == id).FirstOrDefault();
        }

        //add new rental
        public void AddRental(Rental rental)
        {
            this.Database.Insert(rental);
        }

        //delete rental
        public void DeleteRental(int rentalID)
        {
            this.Database.Delete<Rental>(rentalID);
        }

        //update Rental
        public void UpdateRental(Rental rental)
        {
            this.Database.Update(rental);
        }

        //get list of all rentals
        public List<Rental> GetAllRental()
        {
            return this.Database.Table<Rental>().ToList();
        }

        public List<Rental> GetAllRentalByUser(User user)
        {
            return this.Database.Table<Rental>().Where(rental => rental.LibraryId == user.library_id).ToList();
        }

        //get rental by id
        public Rental GetRentalByID(int id)
        {
            return this.Database.Table<Rental>().Where(rental => rental.RentalID == id).FirstOrDefault();
        }

        //add user
        public void AddUser(User user)
        {
            this.Database.Insert(user);
        }

        //delete user
        public void DeleteUser(int library_id)
        {
            this.Database.Delete<User>(library_id);
        }

        //update user
        public void UpdateUser(User user)
        {
            this.Database.Update(user);
        }

        //get list of all Users
        public List<User> GetAllUser()
        {
            return this.Database.Table<User>().ToList();
        }

        //get User by id
        public User GetUserByID(int library_id)
        {
            return this.Database.Table<User>().Where(user => user.library_id == library_id).FirstOrDefault();
        }
    }
}
