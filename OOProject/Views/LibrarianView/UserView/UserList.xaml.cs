namespace OOProject.Views.LibrarianView.UserView;
using OOProject.Models;
using System.Net;
using System.Security.Principal;
using System.Xml.Linq;


public partial class UserList : ContentPage
{
	public UserList()
	{
		InitializeComponent();
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Update list of Users
        UserManager.UpdateUserList();
        UserSearchList.ItemsSource = UserManager.Users;
    }

    private void Go_Menu_L(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LibrarianMenu");
    }

    private void Logout(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    // Move to the add user page
    private void AddUser_Navigation(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddUser");
    }


    // Move to the ViewUserDetails page
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

    // Move to the Edit User Details page
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

    // Searches the users
    private void Search_Users(object sender, EventArgs e)
    {
        string searchQuery = UserSearchBarEntry.Text;
        UserSearchList.ItemsSource = UserManager.SearchUsersGeneric(searchQuery);
    }

}