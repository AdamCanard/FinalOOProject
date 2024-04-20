using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using OOProject.Models;

namespace OOProject.Views.LibrarianView.BookView;

public partial class ViewBookDetails : ContentPage
{
    public Book BookRef { get; set; }
	public ViewBookDetails(Book book)
	{
		InitializeComponent();
        BindingContext = book;
        BookRef = book;
        RentalList.ItemsSource = RentalManager.GetAllRentalsByBook(book.ISBN);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        confirmationMessage.IsVisible = false;
        errorMessage.IsVisible = false;
    }

    private void ExtendBookDuration(object sender, EventArgs e)
    {
        try
        {
            if (sender is Button button)
            {
                Rental rental = (Rental)button.BindingContext;
                if (rental.return_date.Contains("*"))
                {
                    throw new FormatException();
                }

                RentalManager.ExtendRentalDuration(rental.rental_id);
                RentalList.ItemsSource = null;
                RentalList.ItemsSource = RentalManager.GetAllRentalsByBook(BookRef.ISBN);

                confirmationMessage.Text = "Rental period has been extended!";
                confirmationMessage.IsVisible = true;
                errorMessage.IsVisible = false;
            }
        }
        catch (FormatException) 
        {
            errorMessage.Text = "This book's rental period can no longer be extended!";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        } 
    }

    private void ReturnBook(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            Rental rental = (Rental)button.BindingContext;
            
            RentalManager.DeleteRental(rental.rental_id);
            RentalList.ItemsSource = null;
            RentalList.ItemsSource = RentalManager.GetAllRentalsByBook(BookRef.ISBN);
            confirmationMessage.Text = $"A copy of {BookRef.Title} has been returned.";
            confirmationMessage.IsVisible = true;
            errorMessage.IsVisible = false;
        }
    }

    private void Search_Rentals(object sender, EventArgs e)
    {
        string searchQuery = RentalSearchBarEntry.Text;
        RentalList.ItemsSource = RentalManager.SearchRentalsGenericByBook(searchQuery, BookRef);
    }
}