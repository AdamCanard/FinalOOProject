using OOProject.Models;
namespace OOProject.Views.LibrarianView.BookView;

public partial class AddBook : ContentPage
{
    public AddBook()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BookManager.UpdateBooksList();
        ISBN_AddBook.Text = string.Empty;
        Title_AddBook.Text = string.Empty;
        Author_AddBook.Text = string.Empty;
        Category_AddBook.Text = string.Empty;
        Quantity_AddBook.Text = string.Empty;
        confirmationMessage.IsVisible = false;
        errorMessage.IsVisible = false;
    }

    private void Go_Menu_L(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LibrarianMenu");
    }

    private void Logout(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddButton_AddBook_Clicked(object sender, EventArgs e)
    {
        try
        {
            // If add book quantity is 0
            if (Quantity_AddBook.Text == "0")
            {
                // Throw format exception if 0
                throw new FormatException();
            }
            
            // Convert ISBN text to int
            int isbn = Convert.ToInt32(ISBN_AddBook.Text);
            
            // Convert quantity text to int
            int stock = Convert.ToInt32(Quantity_AddBook.Text);
            
            // Add new book to Database
            BookManager.AddNewBook(isbn, stock, Title_AddBook.Text, Author_AddBook.Text, Category_AddBook.Text);
            confirmationMessage.IsVisible = true;
            errorMessage.IsVisible = false;
        }
        
        // Make sure all fields are filled out
        catch (NullReferenceException) 
        {
            errorMessage.Text = "Please fill out all the required fields";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        
        // Make sure fields are filled out correctly
        catch (FormatException) 
        {
            errorMessage.Text = "Please enter a positive integer for the ISBN and the Quantity";
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
        // Need a new exception for catching conflicting primary/foreign keys
        catch (Exception ex) 
        {
            errorMessage.Text = ex.Message;
            errorMessage.IsVisible = true;
            confirmationMessage.IsVisible = false;
        }
    }
}