using OOProject.Models;

namespace OOProject.Views.LibrarianView.BookView;

public partial class BookList : ContentPage
{
	public BookList()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BookSearchList.ItemsSource = BookManager.Books;
    }

    private void AddBook_Navigation(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddBook");
    }

    private async void ViewBookDetails_Navigation(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            Book book = (Book)button.BindingContext;
            if (book != null)
            {
                var bookDetailsPage = new ViewBookDetails(book);
                await Navigation.PushAsync(bookDetailsPage);
            }
        }
    }

    private async void EditBookDetails_Navigation(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            Book book = (Book)button.BindingContext;
            if (book != null)
            {
                var editBookPage = new EditBookDetails(book);
                await Navigation.PushAsync(editBookPage);
            }
        }
    }

    private void Search_Books(object sender, EventArgs e)
    {
        string searchQuery = SearchBarEntry.Text;
        BookSearchList.ItemsSource = BookManager.SearchBooksGeneric(searchQuery);
    }
}