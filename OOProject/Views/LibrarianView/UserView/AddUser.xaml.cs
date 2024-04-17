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
        ID.Text = string.Empty;
        Password.Text = string.Empty;
        Name.Text = string.Empty;
        Email.Text = string.Empty;
        Address.Text = string.Empty;
        Account.Text = string.Empty;
    }
    private void AddButton_AddUser_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (ID.Text == "")
            {
                throw new FormatException();
            }
            int library_id = Convert.ToInt32(ID.Text);
            
            UserManager.AddNewUser(library_id, Name.Text, Email.Text, Password.Text, Address.Text, Account.Text);
            confirmationMessage.IsVisible = true;
            errorMessage.IsVisible = false;
        }
        catch (NullReferenceException)
        {
            errorMessage.Text = "Please fill out all the required fields";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        catch (FormatException)
        {
            errorMessage.Text = "Please enter a positive integer for the ISBN and the Quantity";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        catch (Exception)
        {
            errorMessage.Text = "The ISBN number must be unique";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}