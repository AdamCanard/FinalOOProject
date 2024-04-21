using OOProject.Models;
namespace OOProject.Views.CustomerView;

public partial class ViewProfile : ContentPage
{
    public User UserToUpdate { get; set; }
	public ViewProfile()
	{
		InitializeComponent();
        BindingContext = UserManager.CurrentUser;
        UserToUpdate = UserManager.CurrentUser;
        FineList.ItemsSource = FineManager.GetFineByUser(UserManager.CurrentUser);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        errorMessage.IsVisible = false;
        confirmationMessage.IsVisible = false;
        confirmationMessage.TextColor = Colors.Green;
    }

    private void Go_Menu_C(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CustomerMenu");
    }

    private void Logout(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    // Saves the currently edited user
    private void Save_ViewProfile(object sender, EventArgs e)
    {
        try
        {
            // throw an exception if the quantity is null or empty
            if (string.IsNullOrEmpty(Password_Entry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Email_Entry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Address_Entry.Text))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Name_Entry.Text))
            {
                throw new ArgumentException();
            }

            string Name = Name_Entry.Text;
            string Address = Address_Entry.Text;
            string Password = Password_Entry.Text;
            string Email = Email_Entry.Text;

            // Call the UpdateUser() method to save the changes made to the user object
            UserManager.UpdateUser(UserToUpdate.library_id, Name, Email, Password, Address, UserToUpdate.Account);
            errorMessage.IsVisible = false;
            confirmationMessage.IsVisible = true;

            // This is to show a differences if you save once, then change the values, and then save again.
            // So every instance something is changed there is a visual queue to the user.
            if (confirmationMessage.TextColor.Equals(Colors.Green))
            {
                confirmationMessage.TextColor = Colors.Blue;
            }
            else
            {
                confirmationMessage.TextColor = Colors.Green;
            }
        }
        // Catches the exceptions and displays the appropriate text to the user.
        catch (ArgumentException)
        {
            errorMessage.Text = "All Fields must be filled";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }

        catch (Exception ex)
        {
            errorMessage.Text = ex.Message;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}