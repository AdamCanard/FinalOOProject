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
            userToUpdate.Name = name ?? userToUpdate.Name;
            userToUpdate.Email = email ?? userToUpdate.Email;
            userToUpdate.Password = password ?? userToUpdate.Password;
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
