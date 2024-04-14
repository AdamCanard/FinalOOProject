using OOProject.Models;

namespace OOProject.Views;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}
    private void LoginButton(object sender, EventArgs e)
    {
        DatabaseManager db = new DatabaseManager();
        User user = db.GetUserByID(int.Parse(ID.Text));
        //User gives correct password for given ID
        if(user.Password == Password.Text)
        {
            if(user.Account == "Librarian")
            {
                //TODO go to librarian Page
            }
            else
            {
                //TODO go to student/instructor Page
            }

        }
        else
        {
            errorMessage.Text = "Incorrect ID or Password";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        Shell.Current.GoToAsync("//MainPage");

    }
}