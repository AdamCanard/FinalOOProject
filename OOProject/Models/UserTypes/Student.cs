using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProject.Models.UserTypes
{
    internal class Student : User
    {
        public List<Rental> rentals { get; set; }
        public List<Fine> fines { get; set; }

        public Student(DatabaseManager db, User user)
        {
            this.rentals = db.GetAllRentalByUser(user);
            this.fines = db.GetAllFinesByUser(user);
        }

        public void BorrowBook(DatabaseManager db, Book book)
        {
            //check if fines
            //no fines, create rental object
        }

    }
}
