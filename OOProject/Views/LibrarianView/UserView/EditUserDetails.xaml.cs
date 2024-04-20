namespace OOProject.Views.LibrarianView.UserView;
using OOProject.Models;
public partial class EditUserDetails : ContentPage
{
	public EditUserDetails(User user)
	{
		InitializeComponent();
		BindingContext = user;
	}
}