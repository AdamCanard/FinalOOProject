using SQLite;
using System.ComponentModel.DataAnnotations;

namespace OOProject.Models
{
    public class User
    {

        [Required]
        [PrimaryKey]
        public int library_id{ get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [Unique]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public string Address { get; set; }

        public string Account { get; set; }

        public User() { }

        public User(int id, string name, string email, string password, string address, string account) 
        {
            library_id = id;
            this.name = name;
            this.email = email;
            this.password = password;
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
                $"Name: {name}\t" +
                $"Email: {email}\t" +
                $"Address: {Address}\t" +
                $"Account: {Account}";
        }
    }
}
