using OOProject.Models;

namespace OOProject.Views;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UserManager.UpdateUserList();
        Password.Text = string.Empty;
        errorMessage.IsVisible = false;
        confirmationMessage.IsVisible = false;
    }
    private void LoginButton(object sender, EventArgs e)
    {
        DatabaseManager db = new DatabaseManager();
        User user = db.GetUserByID(int.Parse(ID.Text));
 
        //User gives correct password for given ID
        if (user.password == Password.Text)
        {
            // calculate all fines
            if(user.Account == "Librarian")
            {
                FineManager.CalculateAllFines();
                Shell.Current.GoToAsync("//LibrarianMenu");
                return;
            }
            else
            {
                //Calculated new fines
                //get all rentals from user
                FineManager.CalculateUserFines(user);
                UserManager.CurrentUser = user;
                Shell.Current.GoToAsync("//CustomerMenu");
                return;
            }
        }
        else
        {
            errorMessage.Text = "Incorrect ID or Password";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}