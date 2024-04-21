using OOProject.Models;
namespace OOProject.Views.LibrarianView.UserView;

public partial class AddUser : ContentPage
{
	public AddUser()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Account.SelectedIndex = 3;
        UserManager.UpdateUserList();
    }

    private void Go_Menu_L(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LibrarianMenu");
    }

    private void Logout(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    // Adds the User to the Database based on the data input
    private void AddButton_AddUser_Clicked(object sender, EventArgs e)
    {
        if (Account.SelectedItem == null)
        {
            return;
        }
        try
        {
            // Check if ID text is empty
            if (ID_AddEntry.Text == "")
            {
                // Throw exception if it is
                throw new FormatException();
            }

            // throw an exception if the quantity is null or empty
            if (string.IsNullOrEmpty(Email_AddEntry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Address_AddEntry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Password_AddEntry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Name_AddEntry.Text))
            {
                throw new ArgumentException();
            }

            // Try to convert ID text to int32
            int library_id = Convert.ToInt32(ID_AddEntry.Text);

            bool userExists = UserManager.GetUserByID(library_id) is not null;

            if (userExists)
            {
                throw new Exception();
            }

            string Name = Name_AddEntry.Text;
            string Password = Password_AddEntry.Text;
            string Address = Address_AddEntry.Text;
            string Email = Email_AddEntry.Text;


            string? AccountType = Account.SelectedItem.ToString();

            UserManager.AddNewUser(library_id, Name_AddEntry.Text, Email_AddEntry.Text, Password_AddEntry.Text, Address_AddEntry.Text, AccountType);
            confirmationMessage.IsVisible = true;
            errorMessage.IsVisible = false;
        }
        
        // Make sure all fields are filled
        catch (NullReferenceException)
        {
            errorMessage.Text = "Please fill out all the required fields";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        // Make sure fields are filled out correctly
        catch (FormatException)
        {
            errorMessage.Text = "Please enter a positive integer for the LibraryId" ;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        catch (Exception)
        {
            errorMessage.Text = "That user ID is taken by another user please try again";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }    
}