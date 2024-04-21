namespace OOProject.Views.CustomerView;

public partial class CustomerMenu : ContentPage
{
	public CustomerMenu()
	{
		InitializeComponent();
	}

    // Move to searchbook page
    private void Customer_SearchBook(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//SearchBook");
    }

    // move to viewprofile page
    private void Customer_ViewProfile(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ViewProfile");
    }

    private void Logout(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}