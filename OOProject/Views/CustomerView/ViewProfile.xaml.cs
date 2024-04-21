namespace OOProject.Views.CustomerView;

public partial class ViewProfile : ContentPage
{
	public ViewProfile()
	{
		InitializeComponent();
        BindingContext = UserManager.CurrentUser;
        FineList.ItemsSource = FineManager.GetFineByUser(UserManager.CurrentUser);
    }


    private void Go_Menu_C(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CustomerMenu");
    }

    private void Logout(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}