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

    private async void ViewBookDetails_Navigation(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            Book bookObject = (Book)button.BindingContext;
            if (bookObject != null)
            {
                var bookDetailsPage = new ViewBookDetails(bookObject);
                await Navigation.PushAsync(bookDetailsPage);
            }
        }
    }

    private void EditBookDetails_Navigation(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EditBookDetails");
    }

    private void Search_Books(object sender, EventArgs e)
    {

    }
}