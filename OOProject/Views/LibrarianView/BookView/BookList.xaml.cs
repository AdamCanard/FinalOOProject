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
        var button = (Button)sender;
        var selectedBook = (Book)button.CommandParameter;
        await Navigation.PushAsync(new ViewBookDetails(selectedBook));
        // await Shell.Current.GoToAsync("//ViewBookDetails");
    }

    private async void EditBookDetails_Navigation(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var selectedBook = (Book)button.CommandParameter;
        await Navigation.PushAsync(new EditBookDetails(selectedBook));
        // await Shell.Current.GoToAsync("//EditBookDetails");
    }

    private void Search_Books(object sender, EventArgs e)
    {

    }
}