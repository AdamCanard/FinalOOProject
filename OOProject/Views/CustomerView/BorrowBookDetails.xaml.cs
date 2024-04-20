using OOProject.Models;
namespace OOProject.Views.CustomerView;

public partial class BorrowBookDetails : ContentPage
{
	public BorrowBookDetails()
	{
		InitializeComponent();
    }

    private void Go_Menu_C(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CustomerMenu");
    }
}