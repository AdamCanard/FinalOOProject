using OOProject.Models;

namespace OOProject.Views.LibrarianView.BookView;

public partial class EditBookDetails : ContentPage
{
    public Book EditingBook { get; set; }

	public EditBookDetails(Book book)
	{
		InitializeComponent();
		BindingContext = book;
        EditingBook = book;
    }

    private void Save_EditBook(object sender, EventArgs e)
    {
        try
        {
            if (Quantity_EditBook.Text == "0")
            {
                throw new FormatException();
            }
            int stock = Convert.ToInt32(Quantity_EditBook.Text);
            BookManager.UpdateBook(EditingBook.ISBN, stock, Title_EditBook.Text, Author_EditBook.Text, Category_EditBook.Text);
        }
        catch (NullReferenceException)
        {
            //errorMessage.Text = "Please fill out all the required fields";
            //errorMessage.IsVisible = true;
            //confirmationMessage.IsVisible = false;
        }
        catch (FormatException)
        {
            //errorMessage.Text = "Please enter a positive integer for the ISBN and the Quantity";
            //errorMessage.IsVisible = true;
            // confirmationMessage.IsVisible = false;
        }
        catch (Exception)
        {
            // errorMessage.Text = "The ISBN number must be unique";
            //errorMessage.IsVisible = true;
            // confirmationMessage.IsVisible = false;
        }
    }

    private void Delete_EditBook(object sender, EventArgs e)
    {
        // Currently throwing an error - Needs Cascade deleting to preserve foreign key constraints
        // If we have extra time I would like to add a "Are you sure you want to delete this book" popout thingy - Simon
        BookManager.DeleteBook(EditingBook.ISBN);
    }
}