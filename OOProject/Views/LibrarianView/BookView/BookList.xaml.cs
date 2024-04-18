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
        BookManager.UpdateBooksList();

        List<Book> completeList = BookManager.Books;
        List<Book> foundBooks = new();
        string searchQuery = SearchBarEntry.Text;

        // SearchBook Method

        BookSearchList.ItemsSource = foundBooks;
    }
}