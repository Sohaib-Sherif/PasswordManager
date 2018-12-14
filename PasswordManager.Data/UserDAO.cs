using PasswordManager.Database;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAO
{//should be renamed to UserDAO
    public static class UserDAO
    {
        private static DB Database = DB.Instance();


        public static int AddNewUser(User user, Settings settings, PasswordOptions passwordOptions)
        {
            if (Database.AddNewUser(user) > 0)
            {
                user = Database.GetUserByEmail(user.Email);//why do it?
                if (Database.AddSettingsByUserID(user.ID, settings) > 0)
                {
                    if (Database.AddPasswordOptionsBySettingsID(Database.GetSettingsByUserID(user.ID).ID, passwordOptions) > 0)
                    {
                        return 3;//added all three 
                    }
                    else return 2;//added just user and settings
                }
                else return 1;//added just the user
            }
            else return 0;
        }

        public static User SelectUser(User user)
        {
            return Database.GetUserByID(user.ID);
        }

        public static User LoginUser(User user)
        {
            return Database.GetUserByEmail(user.Email);//bad name method
        }

        public static int UpdateUser(User user)
        {
            return Database.UpdateUser(user);
        }
    }
}
