using OOProject.Models;

namespace OOProject.Views;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Password.Text = string.Empty;
    }
    private void LoginButton(object sender, EventArgs e)
    {
        DatabaseManager db = new DatabaseManager();
        User user = db.GetUserByID(int.Parse(ID.Text));
        //User gives correct password for given ID
        if(user.Password == Password.Text)
        {
            if(user.Account == "Librarian")
            {

                //TODO go to librarian Page -> The BookList is currently kind of the Main librarian page
                Shell.Current.GoToAsync("//LibrarianMenu");
                return;
            }
            else
            {
                //Calculated new fines
                //get all rentals from user
                List<Rental> usersBooks = db.GetAllRentalByUser(user);

                foreach(Rental rental in usersBooks)
                {
                    DateTime returnDate = DateTime.Parse(rental.ReturnDate);
                    if (DateTime.Compare(returnDate, DateTime.Now) < 0)
                    {
                        
                        List<Fine> fines = db.GetAllFines();
                        Fine fine = new Fine(fines.Count, user.library_id, 10);
                        db.AddFine(fine);
                    }
                }
                //TODO go to student/instructor Page
            }

        }
        else
        {
            errorMessage.Text = "Incorrect ID or Password";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}