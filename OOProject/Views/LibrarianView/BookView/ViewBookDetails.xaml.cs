using OOProject.Models;

namespace OOProject.Views.LibrarianView.BookView;

public partial class ViewBookDetails : ContentPage
{
	public ViewBookDetails(Book book)
	{
		InitializeComponent();
		BindingContext = book;
	}
}