using SQLite;
using System.ComponentModel.DataAnnotations;

namespace OOProject.Models
{
    public class Rental
    {
        [Required]
        [PrimaryKey, AutoIncrement]
        public int rental_id { get; set; }

        [Required]
        public int library_id { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required]
        public string date_of_rent { get; set; }

        [Required]
        public string return_date { get; set; }
        
        public Rental(){}

        public Rental(int rentalId, int libraryId, int isbn, string dateOfRent, string returnDate)
        {
            rental_id = rentalId;
            library_id = libraryId;
            ISBN = isbn;
            date_of_rent = dateOfRent;
            return_date = returnDate;
        }
    }
}
