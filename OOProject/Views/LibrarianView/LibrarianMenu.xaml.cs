namespace OOProject.Views.LibrarianView;

public partial class LibrarianMenu : ContentPage
{
	public LibrarianMenu()
	{
		InitializeComponent();
	}

    private void Librarian_AddBook(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddBook");
    }

    private void Librarian_BookList(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//BookList");
    }

    private void Librarian_AddUser(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddUser");
    }

    private void Librarian_UserList(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//UserList");
    }

}