using PasswordManager.Database;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAO
{
    public static class PasswordDAO
    {
        
        private static DB Database = DB.Instance();

        
        public static int SaveNewUserPassword(User user, Password password)
        {
            return Database.AddNewPassword(user.ID, password);
        }

        public static int SaveNewUserPasswords(User user, List<Password> passwords)
        {
            return Database.AddNewPasswords(user.ID, passwords);
        }

        public static List<Password> GetUserPasswords(User user)
        {
            return Database.GetPasswordsByUserID(user.ID);
        }

        public static int UpdateUserPassword(User user, Password password)//I guess I can limit the numbers
        {// of methods be removing the single operation methods and leave the one that works on lists
            return Database.UpdatePassword(user.ID, password);
        }

        public static int UpdateUserPasswords(User user, List<Password> passwords)
        {
            return Database.UpdatePasswords(user.ID, passwords);
        }

        public static int DeleteUserPassword(User user, Password password)
        {
            return Database.DeletePasswordByID(user.ID, password.ID);
        }
    }
}
