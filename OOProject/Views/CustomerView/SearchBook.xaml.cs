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

    private void Search_Books(object sender, EventArgs e)
    {
        string searchQuery = SearchBarEntry.Text;
        BookSearchList.ItemsSource = BookManager.SearchBooksGeneric(searchQuery);
    }

    private void Borrow_Book_Button(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            try
            {
                Book book = (Book)button.BindingContext;
                if (book != null)
                {
                    List<Fine> userFines = FineManager.GetFineByUser(UserManager.CurrentUser);
                    if (userFines.Count > 0)
                    {
                        throw new Exception();
                    }
                    if (book.Quantity == 0)
                    {
                        throw new FormatException();
                    }
                    int lastRentalId = 1;
                    RentalManager.Rentals.ForEach(r => { lastRentalId = r.rental_id; });

                    if (UserManager.CurrentUser.Account == "Instructor")
                    {
                        RentalManager.AddRental(lastRentalId + 1, UserManager.CurrentUser.library_id, book.ISBN, DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(14).ToShortDateString());
                    }
                    else
                    {
                        RentalManager.AddRental(lastRentalId + 1, UserManager.CurrentUser.library_id, book.ISBN, DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(7).ToShortDateString());
                    }
                    book.Quantity = book.Quantity - 1;
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