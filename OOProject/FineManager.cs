using OOProject.Models;
using System.Diagnostics.Metrics;

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

    public static void CalculateAllFines()
    {
        List<User> customers = Database.GetAllUser();

        // Checking ALL customers
        foreach (User customer in customers)
        {
            if (customer.Account == "Librarian")
            {
                continue;
            }

            // This counter is used to calculate how expensive a fine will be
            int counter = 0;
            bool hasPreviousFines = false;

            // See if the are any books that are going to be returned late
            List<Rental> customerBooks = Database.GetAllRentalByUser(customer);
            foreach (Rental rental in customerBooks)
            {
                DateTime returnDate = DateTime.Parse(rental.return_date);
                if (DateTime.Compare(returnDate, DateTime.Now) < 0)
                {
                    counter += 1;
                }
            }

            // If there are no fines, next customer
            if (counter == 0) { continue; }

            foreach (Fine fine in Fines)
            {
                // Check if they had a previous fine
                if (fine.library_id == customer.library_id)
                {
                    hasPreviousFines = true;
                    UpdateFine(fine.fine_id, fine.library_id, counter * 10);
                    break;
                }  
            }

            // If no previous fines, create a new fine
            if (!hasPreviousFines) 
            {
                AddFine(Fines.Count, customer.library_id, counter * 10);
            }
        }
    }

    // Similar to above, but for one customer
    public static void CalculateUserFines(User customer)
    {
        int counter = 0;
        bool hasPreviousFines = false;

        List<Rental> customerBooks = Database.GetAllRentalByUser(customer);
        foreach (Rental rental in customerBooks)
        {
            DateTime returnDate = DateTime.Parse(rental.return_date);
            if (DateTime.Compare(returnDate, DateTime.Now) < 0)
            {
                counter += 1;
            }
        }

        if (counter == 0) { return; }

        foreach (Fine fine in Fines)
        {
            if (fine.library_id == customer.library_id)
            {
                hasPreviousFines = true;
                UpdateFine(fine.fine_id, fine.library_id, counter * 10);
                break;
            }
        }

        if (!hasPreviousFines)
        {
            AddFine(Fines.Count, customer.library_id, counter * 10);
        }
    }
}