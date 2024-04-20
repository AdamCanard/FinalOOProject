using OOProject.Models;
using OOProject.Models.UserTypes;
using static System.Reflection.Metadata.BlobBuilder;

namespace OOProject;

public class RentalManager
{
    private static DatabaseManager Database = new();
    public static List<Rental> Rentals = new(Database.GetAllRental());

    public static Rental GetRentalByID(int id)
    {
        Rental retrievedRental = Database.GetRentalByID(id);
        return retrievedRental;
    }

    public static List<Rental> GetAllRentalsByUser(int libraryID)
    {
        User retrievedUser = Database.GetUserByID(libraryID);
        List<Rental> retrievedRentals = Database.GetAllRentalByUser(retrievedUser);
        return retrievedRentals;
    }

    public static List<Rental> GetAllRentalsByBook(int ISBN)
    {
        Book retrievedBook = Database.GetBookByISBN(ISBN);
        List<Rental> retrievedRentals = Database.GetAllRentalByBook(retrievedBook);
        return retrievedRentals;
    }

    public static void AddRental(int id, int libraryID, int isbn, string rentDate, string returnDate)
    {
        Rental newRental = new Rental(id, libraryID, isbn, rentDate, returnDate);
        Database.AddRental(newRental);
        UpdateRentalsList();
    }

    public static void DeleteRental(int id)
    {
        Database.DeleteRental(id);
        UpdateRentalsList();
    }

    public static void UpdateRental(int rentalToUpdateId, int? libraryID, int? isbn, string? rentDate, string? returnDate)
    {
        Rental rentalToUpdate = Database.GetRentalByID(rentalToUpdateId);
        rentalToUpdate.library_id = libraryID ?? rentalToUpdate.library_id;
        rentalToUpdate.ISBN = isbn ?? rentalToUpdate.ISBN;
        rentalToUpdate.date_of_rent = rentDate ?? rentalToUpdate.date_of_rent;
        rentalToUpdate.return_date = returnDate ?? rentalToUpdate.return_date;
        
        Database.UpdateRental(rentalToUpdate);
        UpdateRentalsList();
    }

    public static void UpdateRentalsList()
    {
        Rentals = Database.GetAllRental();
    }

    public static List<Rental> SearchRentalsGenericByBook(string searchQuery, Book book)
    {
        List<Rental> foundRentals = [];
        List<Rental> rentalsByBook = GetAllRentalsByBook(book.ISBN);
        if (string.IsNullOrEmpty(searchQuery))
        {
            return rentalsByBook;
        }

        foreach (var rental in rentalsByBook)
        {
            User associatedUser = GetAssociatedUser(rental);
            bool rentalID = rental.rental_id.ToString().ToLower().Contains(searchQuery.ToLower());
            bool foundLibraryID = rental.library_id.ToString().ToLower().Contains(searchQuery.ToLower());
            bool foundName = associatedUser.name.ToLower().Contains(searchQuery.ToLower());
            bool foundRentalID = rental.rental_id.ToString().ToLower().Contains(searchQuery.ToLower());
            bool foundRentalDate = rental.date_of_rent.ToLower().Contains(searchQuery.ToLower());
            bool foundReturnDate = rental.return_date.ToLower().Contains(searchQuery.ToLower());

            if (rentalID || foundLibraryID|| foundName || foundRentalID || foundRentalDate || foundReturnDate)
            {
                foundRentals.Add(rental);
            }
        }

        return foundRentals;
    }

    public static void ExtendRentalDuration(int rentalToUpdateId)
    {
        Rental rentalToUpdate = Database.GetRentalByID(rentalToUpdateId);
        User associatedUser = GetAssociatedUser(rentalToUpdate);
        switch (associatedUser is Instructor)
        {
            case true:
                {
                    DateTime currentReturnDate = Convert.ToDateTime(rentalToUpdate.return_date);
                    string newReturnDate = currentReturnDate.AddDays(14).ToShortDateString() + " *";
                    rentalToUpdate.return_date = newReturnDate;
                    break;
                }
            case false:
                {
                    DateTime currentReturnDate = Convert.ToDateTime(rentalToUpdate.return_date);
                    string newReturnDate = currentReturnDate.AddDays(7).ToShortDateString() + " *";
                    rentalToUpdate.return_date = newReturnDate;
                    break;
                }
        }
        Database.UpdateRental(rentalToUpdate);
        UpdateRentalsList();
    }

    public static User GetAssociatedUser(Rental rental)
    {
        User associatedUser = UserManager.GetUserByID(rental.library_id);
        return associatedUser;
    }
}