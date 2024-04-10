using SQLite;
using System.ComponentModel.DataAnnotations;

namespace OOProject.Models
{
    public class Rental
    {
        [Required]
        [PrimaryKey, AutoIncrement]
        public int RentalID { get; set; }

        [Required]
        public int LibraryId { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required]
        public string DateOfRent { get; set; }

        [Required]
        public string ReturnDate { get; set; }
    }
}
