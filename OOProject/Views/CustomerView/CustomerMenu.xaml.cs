namespace OOProject.Views.CustomerView;

public partial class CustomerMenu : ContentPage
{
	public CustomerMenu()
	{
		InitializeComponent();
	}

    private void Customer_SearchBook(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//SearchBook");
    }

    private void Customer_ViewProfile(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ViewProfile");
    }
}