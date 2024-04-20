namespace OOProject.Views.LibrarianView.UserView;
using OOProject.Models;
public partial class EditUserDetails : ContentPage
{
    public User UserToUpdate { get; set; }

    public EditUserDetails(User user)
    {
        InitializeComponent();
        // Bind the object that was clicked to open this page and store it as a property to modify it
        BindingContext = user;
        UserToUpdate = user;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Restore to default some UI visual settings
        Delete_Button.IsEnabled = true;
        errorMessage.IsVisible = false;
        confirmationMessage.IsVisible = false;
        errorMessage.FontAttributes = FontAttributes.None;
        confirmationMessage.TextColor = Colors.Green;
    }

    private void Go_Menu_L(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LibrarianMenu");
    }
    
    // Saves the currently edited user
    private void Save_EditUser(object sender, EventArgs e)
    {
        try
        {
            // throw an exception if the quantity is null or empty
            if (string.IsNullOrEmpty(Account_EditEntry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(password_EditEntry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(email_EditEntry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Address_EditEntry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(name_EditEntry.Text))
            {
                throw new ArgumentException();
            }
            
            string Name = name_EditEntry.Text;
            string Account = Account_EditEntry.Text;
            string Address = Address_EditEntry.Text;
            string Password = password_EditEntry.Text;
            string Email = email_EditEntry.Text;

            // Call the UpdateUser() method to save the changes made to the user object
            UserManager.UpdateUser(UserToUpdate.library_id, Name, Email, Password, Address, Account);
            errorMessage.IsVisible = false;
            confirmationMessage.IsVisible = true;

            // This is to show a differences if you save once, then change the values, and then save again.
            // So every instance something is changed there is a visual queue to the user.
            if (confirmationMessage.TextColor.Equals(Colors.Green))
            {
                confirmationMessage.TextColor = Colors.Blue;
            }
            else
            {
                confirmationMessage.TextColor = Colors.Green;
            }
        }
        // Catches the exceptions and displays the appropriate text to the user.
        catch (ArgumentException)
        {
            errorMessage.Text = "All Fields must be filled";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        
        catch (Exception ex)
        {
            errorMessage.Text = ex.Message;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }

    // Deletes the currently selected user
    private void Delete_EditUser(object sender, EventArgs e)
    {
        //User can only be deleted if they have no rentals or fines
        FineManager.UpdateFinesList();
        // A flag that determines if later we will throw an exception or not
        bool canDeleteFine = true;

        // Check if a this user has a fine
        foreach (Fine fine in FineManager.Fines)
        {
            if (fine.library_id == UserToUpdate.library_id)
            {
                canDeleteFine = false;
                Delete_Button.IsEnabled = false;
                break;
            }
        }

        RentalManager.UpdateRentalsList();
        // A flag that determines if later we will throw an exception or not
        bool canDeleteRental = true;

        // Check if a this user has a rented book
        foreach (Rental rental in RentalManager.Rentals)
        {
            if (rental.library_id == UserToUpdate.library_id)
            {
                canDeleteRental = false;
                Delete_Button.IsEnabled = false;
                break;
            }
        }

        // if there is a book a rental throw an exception
        try
        {
            if (canDeleteRental == false || canDeleteFine == false)
            {
                throw new FeatureNotEnabledException();
            }

            // Currently throwing an error - Needs Cascade deleting to preserve foreign key constraints
            // If we have extra time I would like to add a "Are you sure you want to delete this book" popout thingy - Simon
            UserManager.DeleteUser(UserToUpdate.library_id);
            Shell.Current.GoToAsync("//UserList");
        }
        catch (FeatureNotEnabledException)
        {
            // This exception kind of works for this but we could create an exceptions class (I really dont want to) - Simon
            errorMessage.Text = "User cannot be deleted, as a copy has been rented out to a customer. \nEnsure all copies have been returned before deleting this book.";
            errorMessage.FontAttributes = FontAttributes.Bold;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        catch (Exception ex)
        {
            errorMessage.FontAttributes = FontAttributes.None;
            errorMessage.Text = ex.Message;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}