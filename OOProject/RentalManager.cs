using OOProject.Models;

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
}