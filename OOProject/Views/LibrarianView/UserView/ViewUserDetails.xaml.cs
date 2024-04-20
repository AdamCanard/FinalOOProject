namespace OOProject.Views.LibrarianView.UserView;
using OOProject.Models;


public partial class ViewUserDetails : ContentPage
{
    public User currentUser;
    public ViewUserDetails(User user)
    {
        InitializeComponent();
        currentUser = user;
        BindingContext = user;
        FineList.ItemsSource = FineManager.GetFineByUser(user);
    }

    private void Pay_Fine(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            Fine fine = (Fine)button.BindingContext;
            if (fine != null)
            {
                FineManager.DeleteFine(fine.fine_id);
                FineManager.UpdateFinesList();
                FineList.ItemsSource = FineManager.GetFineByUser(currentUser);
            }
        }
    }

}