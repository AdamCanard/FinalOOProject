namespace OOProject.Views.LibrarianView.UserView;
using OOProject.Models;

public partial class ViewUserDetails : ContentPage
{
    public ViewUserDetails(User user)
    {
        InitializeComponent();
        BindingContext = user;
        FineList.ItemsSource = FineManager.GetFineByUser(user);
    }

}