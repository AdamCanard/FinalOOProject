namespace OOProject.Views.CustomerView;

public partial class ViewProfile : ContentPage
{
	public ViewProfile()
	{
		InitializeComponent();
        BindingContext = UserManager.CurrentUser;
        FineList.ItemsSource = FineManager.GetFineByUser(UserManager.CurrentUser);
    }
}