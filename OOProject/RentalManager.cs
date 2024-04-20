using OOProject.Models;

namespace OOProject;

public class RentalManager
{
    private static DatabaseManager Database = new();
    public static List<Rental> Rentals = new(Database.GetAllRental());

    // Gets a Rental using its ID
    public static Rental GetRentalByID(int id)
    {
        Rental retrievedRental = Database.GetRentalByID(id);
        return retrievedRental;
    }

    // Gets all rentals that match a user's library ID
    public static List<Rental> GetAllRentalsByUser(int libraryID)
    {
        User retrievedUser = Database.GetUserByID(libraryID);
        List<Rental> retrievedRentals = Database.GetAllRentalByUser(retrievedUser);
        return retrievedRentals;
    }

    // Get all rentals of a specific book using the book's ISBN
    public static List<Rental> GetAllRentalsByBook(int ISBN)
    {
        Book retrievedBook = BookManager.GetBookByISBN(ISBN);
        List<Rental> retrievedRentals = Database.GetAllRentalByBook(retrievedBook);
        return retrievedRentals;
    }

    // Adds a Rental to the database
    public static void AddRental(int id, int libraryID, int isbn, string rentDate, string returnDate)
    {
        Rental newRental = new Rental(id, libraryID, isbn, rentDate, returnDate);
        Database.AddRental(newRental);
        UpdateRentalsList();
    }

    // Deletes a Rental from the database
    public static void DeleteRental(int id)
    {
        Database.DeleteRental(id);
        UpdateRentalsList();
    }

    // Updates a Rental in the Database
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

    // Updates the local Rentals list using the Database
    public static void UpdateRentalsList()
    {
        Rentals = Database.GetAllRental();
    }
}