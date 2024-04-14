using OOProject.Models;

namespace OOProject.Views.LibrarianView.BookView;

public partial class EditBookDetails : ContentPage
{
	public EditBookDetails(Book book)
	{
		InitializeComponent();
		BindingContext = book;
	}
}