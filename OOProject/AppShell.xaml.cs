using OOProject.Views;
using OOProject.Views.LibrarianView.BookView;
using OOProject.Views.LibrarianView.UserView;

namespace OOProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(AddBook), typeof(AddBook));
            Routing.RegisterRoute(nameof(BookList), typeof(BookList));
            Routing.RegisterRoute(nameof(EditBookDetails), typeof(EditBookDetails));
            Routing.RegisterRoute(nameof(ViewBookDetails), typeof(ViewBookDetails));
            Routing.RegisterRoute(nameof(AddUser), typeof(AddUser));
            Routing.RegisterRoute(nameof(UserList), typeof(UserList));
            Routing.RegisterRoute(nameof(EditUserDetails), typeof(EditUserDetails));
            Routing.RegisterRoute(nameof(ViewUserDetails), typeof(ViewUserDetails));

        }
    }
}
