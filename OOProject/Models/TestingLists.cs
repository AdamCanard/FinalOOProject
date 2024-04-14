using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOProject;

namespace OOProject.Models
{
    // Testing Class used for binding objects and lists
    public class TestingLists : BindableObject
    {

        // This is the only important part of this code
        public List<Book> BooksList { get; set; } = BookManager.Books;

        public List<Book> Books { get; set; } =
        [
            new(1001, 10, "History of World War II", "Somebody", "History"),
            new(1002, 5, "Harry Potter", "J. K. Rowling", "Fantasy"),
            new(1003, 2, "Eragorn", "Who knows", "Fantasy"),
            new(1001, 10, "History of World War II", "Somebody", "History"),
            new(1002, 5, "Harry Potter", "J. K. Rowling", "Fantasy"),
            new(1003, 2, "Eragorn", "Who knows", "Fantasy")
        ];

        public List<User> Users { get; set; } =
        [
            new(101, "John Schmoe", "John.Schmoe@gmail.com", "Password", "20 Street Nowhere", "Librarian"),
            new(201, "Simon Luna", "Simon.Luna@sait.ca", "Password", "101 Chapala Grove SE", "Student"),
            new(301, "Ricky Locke", "Ricky.Locke@gmail.com", "Password", "9999 Ave Hell", "Instructor"),
            new(101, "John Schmoe", "John.Schmoe@gmail.com", "Password", "20 Street Nowhere", "Librarian"),
            new(201, "Simon Luna", "Simon.Luna@sait.ca", "Password", "101 Chapala Grove SE", "Student"),
            new(301, "Ricky Locke", "Ricky.Locke@gmail.com", "Password", "9999 Ave Hell", "Instructor"),
            new(101, "John Schmoe", "John.Schmoe@gmail.com", "Password", "20 Street Nowhere", "Librarian"),
            new(201, "Simon Luna", "Simon.Luna@sait.ca", "Password", "101 Chapala Grove SE", "Student"),
            new(301, "Ricky Locke", "Ricky.Locke@gmail.com", "Password", "9999 Ave Hell", "Instructor")
        ];

        public Book FirstBook { get; set; } = new(1003, 2, "Eragorn", "Who knows", "Fantasy");
    }
}
