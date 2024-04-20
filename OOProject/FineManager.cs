using OOProject.Models;

namespace OOProject;

public class FineManager
{
    public static DatabaseManager Database = new();
    public static List<Fine> Fines = new(Database.GetAllFines());
    
    public static Fine GetFineById(int id)
    {
        Fine retrievedFine = Database.GetFineByID(id);
        return retrievedFine;
    }

    public static List<Fine> GetFineByUser(User user)
    {
        List<Fine> retrievedFines = Database.GetAllFinesByUser(user);
        return retrievedFines;
    }

    public static void AddFine(int id, int libraryId, int amount)
    {
        Fine newFine = new Fine(id, libraryId, amount);
        Database.AddFine(newFine);
        UpdateFinesList();
    }

    public static void DeleteFine(int id)
    {
        Database.DeleteFine(id);
        UpdateFinesList();
    }

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

    public static void UpdateFinesList()
    {
        Fines = Database.GetAllFines();
    }
}