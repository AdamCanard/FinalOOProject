namespace OOProject.Views.CustomerView;
using OOProject.Models;

public partial class SearchBook : ContentPage
{
	public SearchBook()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BookSearchList.ItemsSource = BookManager.Books;
    }

    // Searches books database using the search query
    private void Search_Books(object sender, EventArgs e)
    {
        string searchQuery = SearchBarEntry.Text;
        BookSearchList.ItemsSource = BookManager.SearchBooksGeneric(searchQuery);
    }

    // Borrows a book
    private void Borrow_Book_Button(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            try
            {
                // Get respective book from event sender
                Book book = (Book)button.BindingContext;
                if (book != null)
                {
                    // check to make sure that user doesn't have any fines
                    List<Fine> userFines = FineManager.GetFineByUser(UserManager.CurrentUser);
                    if (userFines.Count > 0)
                    {
                        throw new Exception();
                    }
                    if (book.Quantity == 0)
                    {
                        throw new FormatException();
                    }
                    
                    // Find last rental in rental list and save its ID
                    Rental lastRental = RentalManager.Rentals.Last();
                    int lastRentalId = lastRental.rental_id;

                    // Choose days rented based on user account
                    int daysRented = UserManager.CurrentUser.Account == "Instructor" ? 7 : 14;
                    
                    // Set rentDate to today
                    string rentDate = DateTime.Now.ToShortDateString();
                    
                    // Set return date based on days rented
                    string returnDate = DateTime.Now.AddDays(daysRented).ToShortDateString();
                    
                    // Add rental to database
                    RentalManager.AddRental(lastRentalId + 1, UserManager.CurrentUser.library_id, book.ISBN, rentDate, returnDate);
                    
                    // lower the book quantity
                    book.Quantity -= 1;
                    
                    // update persistence layer
                    BookManager.UpdateBook(book.ISBN, book.Quantity, book.Title, book.Genre);
                    BookSearchList.ItemsSource = BookManager.Books;
                    confirmationMessage.IsVisible = true;
                    errorMessage.IsVisible = false;
                }
            }
            catch (FormatException ex)
            {
                errorMessage.Text = "Book is out of stock, please borrow a different one";
                errorMessage.IsVisible = true;
                confirmationMessage.IsVisible = false;
            }
            catch (Exception ex)
            {
                errorMessage.Text = "Please pay all fines before borrowing a book";
                errorMessage.IsVisible = true;
                confirmationMessage.IsVisible = false;
            }
            
        }
    }
}