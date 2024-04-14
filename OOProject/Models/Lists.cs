using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOProject;

namespace OOProject.Models
{
    // Testing Class used for binding objects and lists
    public class Lists : BindableObject
    {

        // This is the only important part of this code
        public List<Book> BooksList { get; set; } = BookManager.Books;
        public List<User> UsersList { get; set; } = UserManager.Users;
        
    }
}
