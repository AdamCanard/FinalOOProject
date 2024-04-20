namespace OOProject.Views.LibrarianView.UserView;

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

}