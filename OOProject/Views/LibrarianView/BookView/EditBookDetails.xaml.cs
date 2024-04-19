using Microsoft.Maui.Graphics.Text;
using OOProject.Models;
using System.Linq;

namespace OOProject.Views.LibrarianView.BookView;

public partial class EditBookDetails : ContentPage
{
    public Book BookToUpdate { get; set; }

	public EditBookDetails(Book book)
	{
		InitializeComponent();
        // Bind the object that was clicked to open this page and store it as a property to modify it
		BindingContext = book;
        BookToUpdate = book;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Restore to default some UI visual settings
        Delete_Button.IsEnabled = true;
        errorMessage.IsVisible = false;
        confirmationMessage.IsVisible = false;
        errorMessage.FontAttributes = FontAttributes.None;
        confirmationMessage.TextColor = Colors.Green;
    }

    private void Save_EditBook(object sender, EventArgs e)
    {
        try
        {
            // throw an exception if the quantity is null or empty
            if (string.IsNullOrEmpty(Quantity_EditBook.Text))
            {
                throw new ArgumentException();
            }

            // throws a FormatException if the quantity is not a number
            int newStock = Convert.ToInt32(Quantity_EditBook.Text);

            // throw an exception if the quantity is equal to or less than 0
            if (newStock <= 0) 
            {
                throw new ArgumentException();
            }

            // Call the UpdateBook() method to save the changes made to the book object
            BookManager.UpdateBook(BookToUpdate.ISBN, newStock, Title_EditBook.Text, Author_EditBook.Text, Category_EditBook.Text);
            errorMessage.IsVisible = false;
            confirmationMessage.IsVisible = true;

            // This is to show a differences if you save once, then change the values, and then save again.
            if (confirmationMessage.TextColor == Colors.Green) 
            {
                confirmationMessage.TextColor = Colors.Blue;
            }
            else
            {
                confirmationMessage.TextColor = Colors.Green;
            }
        }
        // Catches the exceptions and displays the appropiate text to the user.
        catch (ArgumentException)
        {
            errorMessage.Text = "*Required* Quantity must be a positive integer.";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        catch (FormatException)
        {
            errorMessage.Text = "*Required* Quantity must be numeric.";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        catch (Exception ex)
        {
            errorMessage.Text = ex.Message;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }

    private void Delete_EditBook(object sender, EventArgs e)
    {
        RentalManager.UpdateRentalsList();
        // A flag that determines if later we will throw an exception or not
        bool canDelete = true;

        // Check if a this book has been rented in any of the rentals
        foreach (Rental rental in RentalManager.Rentals) 
        {
            if (rental.ISBN == BookToUpdate.ISBN) 
            {
                canDelete = false;
                Delete_Button.IsEnabled = false;
                break;
            }
        }

        // if there is a book a rental throw an exception
        try
        {
            if (canDelete == false) 
            {
                throw new FeatureNotEnabledException();
            }

            // Currently throwing an error - Needs Cascade deleting to preserve foreign key constraints
            // If we have extra time I would like to add a "Are you sure you want to delete this book" popout thingy - Simon
            BookManager.DeleteBook(BookToUpdate.ISBN);
        }
        catch (FeatureNotEnabledException) 
        {
            // This exception kind of works for this but we could create an exceptions class (I really dont want to) - Simon
            errorMessage.Text = "Book cannot be deleted, as a copy has been rented out to a customer. \nEnsure all copies have been returned before deleting this book.";
            errorMessage.FontAttributes = FontAttributes.Bold;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        catch (Exception ex)
        {
            errorMessage.FontAttributes = FontAttributes.None;
            errorMessage.Text = ex.Message;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}