using OOProject.Models;
namespace OOProject.Views.LibrarianView.BookView;

public partial class BookList : ContentPage
{
	public BookList()
	{
		InitializeComponent();
	}

    private void AddBook_Navigation(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddBook");
    }

    private void ViewBookDetails_Navigation(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ViewBookDetails");
    }

    private void EditBookDetails_Navigation(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EditBookDetails");
    }

    private void Search_Books(object sender, EventArgs e)
    {

    }
}