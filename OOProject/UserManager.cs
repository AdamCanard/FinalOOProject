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
        public static User CurrentUser;
        public static List<string> ValidAccountTypes = ["Librarian", "Instructor", "Student"];

        public static List<User> SearchUsersPerParameter(string? library_id, string? name, string? email, string? address, string? account)
        {
            List<User> foundUsers = [];

            foreach (var user in Users)
            {
                bool foundId = user.library_id.ToString().ToLower()
                    .Contains((library_id ?? user.library_id.ToString()).ToLower());
                bool foundName = user.name.ToLower()
                    .Contains((name ?? user.name).ToLower());
                bool foundEmail = user.email.ToLower()
                    .Contains((email ?? user.email).ToLower());
                bool foundAddress = user.Address.ToLower()
                    .Contains((address ?? user.Address).ToLower());
                bool foundAccount = user.Account.ToLower()
                    .Contains((account ?? user.Account).ToLower());

                if (foundId && foundName && foundEmail && foundAddress && foundAccount)
                {
                    foundUsers.Add(user);
                }
            }

            return foundUsers;
        }

        public static List<User> SearchUsersGeneric(string searchQuery)
        {
            List<User> foundUsers = [];

            foreach (var user in Users)
            {
                bool foundId = user.library_id.ToString().ToLower()
                    .Contains(searchQuery.ToLower());
                bool foundName = user.name.ToLower()
                    .Contains(searchQuery.ToLower());
                bool foundEmail = user.email.ToLower()
                    .Contains(searchQuery.ToLower());
                bool foundAddress = user.Address.ToLower()
                    .Contains(searchQuery.ToLower());
                bool foundAccount = user.Account.ToLower()
                    .Contains(searchQuery.ToLower());

                if (foundId || foundName || foundEmail || foundAddress || foundAccount)
                {
                    foundUsers.Add(user);
                }
            }

            return foundUsers;
        }

        public static void AddNewUser(int library_id, string name, string email, string password, string address, string account)
        {
            User newUser = new(library_id, name, email, password, address, account);
            Database.AddUser(newUser);
            UpdateUserList();
        }

        public static User GetUserByID(int id)
        {
            User retrievedUser = Database.GetUserByID(id);
            return retrievedUser;
        }

        public static void DeleteUser(int id)
        {
            Database.DeleteUser(id);
            UpdateUserList();
        }

        public static void UpdateUser(int userToUpdateID, string? name, string? email, string? password,
            string? address, string? account)
        {
            User userToUpdate = GetUserByID(userToUpdateID);
            userToUpdate.name = name ?? userToUpdate.name;
            userToUpdate.email = email ?? userToUpdate.email;
            userToUpdate.password = password ?? userToUpdate.password;
            userToUpdate.Address = address ?? userToUpdate.Address;
            userToUpdate.Account = account ?? userToUpdate.Account;
            
            Database.UpdateUser(userToUpdate);
            UpdateUserList();
        }

        public static void UpdateUserList()
        {
            Users = Database.GetAllUser();
        }
    }
}
