using OOProject.Models;

namespace OOProject;

public class FineManager
{
    public static DatabaseManager Database = new();
    public static List<Fine> Fines = new(Database.GetAllFines());
    
    // Finds the matching Fine by its ID
    public static Fine GetFineById(int id)
    {
        Fine retrievedFine = Database.GetFineByID(id);
        return retrievedFine;
    }

    // Searches the Database for all fines that are linked to a user
    public static List<Fine> GetFineByUser(User user)
    {
        List<Fine> retrievedFines = Database.GetAllFinesByUser(user);
        return retrievedFines;
    }

    // Add Fine to the Database
    public static void AddFine(int id, int libraryId, int amount)
    {
        Fine newFine = new Fine(id, libraryId, amount);
        Database.AddFine(newFine);
        UpdateFinesList();
    }

    // Delete Fine from Database
    public static void DeleteFine(int id)
    {
        Database.DeleteFine(id);
        UpdateFinesList();
    }

    // Update Fine in the Database
    public static void UpdateFine(int fineToUpdateId, int? libraryId, int? amount)
    {
        Fine retrievedFine = GetFineById(fineToUpdateId);
        retrievedFine.library_id = libraryId ?? retrievedFine.library_id;

        if (retrievedFine.amount < 0)
        {
            Console.WriteLine("Amount to update fine with was less than 0, must be 0 or greater");
            return;
        }
        
        retrievedFine.amount = amount ?? retrievedFine.amount;
        
        Database.UpdateFine(retrievedFine);
        UpdateFinesList();
    }

    // Updates the list of Fines using the Database list
    public static void UpdateFinesList()
    {
        Fines = Database.GetAllFines();
    }
}