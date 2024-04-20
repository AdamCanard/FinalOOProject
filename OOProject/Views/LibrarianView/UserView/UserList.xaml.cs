namespace OOProject.Views.LibrarianView.UserView;
using OOProject.Models;


public partial class UserList : ContentPage
{
	public UserList()
	{
		InitializeComponent();
	}

    private void AddUser_Navigation(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddUser");
    }

    private async void ViewUserDetails_Navigation(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            User user = (User)button.BindingContext;
            if (user != null)
            {
                var userDetailsPage = new ViewUserDetails(user);
                await Navigation.PushAsync(userDetailsPage);
            }
        }
    }

    private async void EditUserDetails_Navigation(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            User user = (User)button.BindingContext;
            if (user != null)
            {
                var editUserPage = new EditUserDetails(user);
                await Navigation.PushAsync(editUserPage);
            }
        }
    }
}