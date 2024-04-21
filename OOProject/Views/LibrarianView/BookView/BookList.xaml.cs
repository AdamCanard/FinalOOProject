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
        
        // Make sure that BookManager list is updated properly
        BookManager.UpdateBooksList();
        
        // Update book search list source
        BookSearchList.ItemsSource = BookManager.Books;
    }

    private void Go_Menu_L(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LibrarianMenu");
    }

    private void Logout(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    // Switch to AddBook page
    private async void AddBook_Navigation(object sender, EventArgs e)
    {
        var addBookPage = new AddBook();
        await Navigation.PushAsync(addBookPage);
    }

    // Move to ViewBookDetails page
    private async void ViewBookDetails_Navigation(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            // Find book attached to button object sender
            Book book = (Book)button.BindingContext;
            if (book != null)
            {
                // Open Book Details page with respective book
                var bookDetailsPage = new ViewBookDetails(book);
                await Navigation.PushAsync(bookDetailsPage);
            }
        }
    }

    // Open Edit Book details
    private async void EditBookDetails_Navigation(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            // Find book attached to event sender
            Book book = (Book)button.BindingContext;
            if (book != null)
            {
                // Open editbookpage with respective book
                var editBookPage = new EditBookDetails(book);
                await Navigation.PushAsync(editBookPage);
            }
        }
    }

    // Searches books using searchquery
    private void Search_Books(object sender, EventArgs e)
    {
        string searchQuery = BookSearchBarEntry.Text;
        BookSearchList.ItemsSource = BookManager.SearchBooksGeneric(searchQuery);
    }
}