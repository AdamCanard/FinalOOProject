using SQLite;
using System.ComponentModel.DataAnnotations;

namespace OOProject.Models
{
    public class User
    {

        [Required]
        [PrimaryKey, AutoIncrement]
        public int library_id{ get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Unique]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string Account { get; set; }

        public User() { }

        public User(int id, string name, string email, string password, string address, string account) 
        {
            library_id = id;
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Account = account;
        }

        public List<Book> DisplayBooks(DatabaseManager db)
        {
            return db.GetAllBooks();

        }

        public override string ToString()
        {
            return $"Id: {library_id}\t" +
                $"Name: {Name}\t" +
                $"Email: {Email}\t" +
                $"Address: {Address}\t" +
                $"Account: {Account}";
        }
    }
}
