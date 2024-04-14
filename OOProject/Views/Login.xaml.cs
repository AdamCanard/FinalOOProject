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
        Password.Text = string.Empty;
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
                //TODO go to librarian Page -> The BookList is currently kind of the Main librarian page
                Shell.Current.GoToAsync("//LibrarianMenu");
                return;
            }
            else
            {
                //TODO go to student/instructor Page
            }

        }
        else
        {
            //TODO say try again onscreen
        }
        Shell.Current.GoToAsync("//MainPage");

    }
}