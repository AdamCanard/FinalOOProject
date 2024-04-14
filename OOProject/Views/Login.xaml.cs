namespace OOProject.Views;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}
    private void LoginButton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}