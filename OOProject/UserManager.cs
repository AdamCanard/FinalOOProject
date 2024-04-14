using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOProject.Models;

namespace OOProject
{
    public static class UserManager
    {
        public static DatabaseManager Database = new();
        public static List<User> Users = new(Database.GetAllUser());

        public static void AddNewUser(int library_id, string name, string email, string password, string address, string account)
        {
            User newUser = new(library_id, name, email, password, address, account);
            Database.AddUser(newUser);
            Users = Database.GetAllUser();
            return;
        }
    }
}
