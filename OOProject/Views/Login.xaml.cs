namespace OOProject.Views;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}
    private void OnCounterClicked(object sender, EventArgs e)
    {
        // Navigation using Shell
        Shell.Current.GoToAsync("//MainPage");
    }
}