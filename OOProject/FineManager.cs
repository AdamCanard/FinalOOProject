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
        retrievedFine.LibraryID = libraryId ?? retrievedFine.LibraryID;

        if (retrievedFine.Amount < 0)
        {
            Console.WriteLine("Amount to update fine with was less than 0, must be 0 or greater");
            return;
        }
        
        retrievedFine.Amount = amount ?? retrievedFine.Amount;
        
        Database.UpdateFine(retrievedFine);
        UpdateFinesList();
    }

    public static void UpdateFinesList()
    {
        Fines = Database.GetAllFines();
    }
}