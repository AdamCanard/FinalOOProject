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
        
    }

    private void Go_Menu_L(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LibrarianMenu");
    }

    private void ExtendBookDuration(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            Rental rental = (Rental)button.BindingContext;

            // RentalManager.Extend();
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
        }
    }
}