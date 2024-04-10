using SQLite;
using System.ComponentModel.DataAnnotations;

namespace OOProject.Models
{
    abstract class User
    {
        [Required]
        [PrimaryKey, AutoIncrement]
        public int LibraryID{ get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Unique]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Account { get; set; }

        public override string ToString()
        {
            return $"Id: {LibraryID}\t" +
                $"Name: {Name}\t" +
                $"Email: {Email}\t" +
                $"Account: {Account}";
        }
    }
}
