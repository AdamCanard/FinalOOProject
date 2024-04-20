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
            if (ID.Text == "")
            {
                // Throw exception if it is
                throw new FormatException();
            }
            // Try to convert ID text to int32
            int library_id = Convert.ToInt32(ID.Text);

            string? AccountType = Account.SelectedItem.ToString();

            UserManager.AddNewUser(library_id, Name.Text, Email.Text, Password.Text, Address.Text, AccountType);
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
        catch (Exception ex)
        {
            errorMessage.Text = ex.Message;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}