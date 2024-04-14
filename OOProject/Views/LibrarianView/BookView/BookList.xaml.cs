namespace OOProject.Views.LibrarianView.BookView;

public partial class BookList : ContentPage
{
	public BookList()
	{
		InitializeComponent();
	}

    private void AddBooks(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddBook");
    }
}