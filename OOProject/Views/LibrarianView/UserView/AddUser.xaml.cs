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

        UserManager.UpdateUserList();
    }
    
    // Adds the User to the Database based on the data input
    private void AddButton_AddUser_Clicked(object sender, EventArgs e)
    {
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
            
            // Create new user with ID and other information
            UserManager.AddNewUser(library_id, Name.Text, Email.Text, Password.Text, Address.Text, Account.Text);
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
            errorMessage.Text = ex.ToString();
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}