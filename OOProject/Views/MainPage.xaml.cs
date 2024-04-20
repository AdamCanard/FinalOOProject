namespace OOProject.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void CounterBtn_Clicked(object sender, EventArgs e)
    {
	    // Move to the login page
        Shell.Current.GoToAsync("//Login");
    }
}