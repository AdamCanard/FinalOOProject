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
    private void Go_Menu_L(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LibrarianMenu");
    }

    // Pays the fine for respective user
    private void Pay_Fine(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            Fine fine = (Fine)button.BindingContext;
            if (fine != null)
            {
                // Delete fine from database
                FineManager.DeleteFine(fine.fine_id);
                FineManager.UpdateFinesList();
                
                // Update fines list for user
                FineList.ItemsSource = FineManager.GetFineByUser(currentUser);
            }
        }
    }

}