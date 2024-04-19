using OOProject.Models;

namespace OOProject.Views.LibrarianView.BookView;

public partial class ViewBookDetails : ContentPage
{
    public Book BookRef;
	public ViewBookDetails(Book book)
	{
		InitializeComponent();
        BindingContext = book;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RentalList.ItemsSource = RentalManager.Rentals;
    }
}