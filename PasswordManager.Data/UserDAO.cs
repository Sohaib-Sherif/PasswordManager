using PasswordManager.Database;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAO
{
    public static class UserDAO
    {
        private static DB Database = DB.Instance();


        public static int AddNewUser(string[] userData, Settings settings, PasswordOptions passwordOptions)
        {
            if (Database.AddNewUser(userData) > 0)
            {
                User user = Database.GetUserByEmail(userData[2]);//the email is index 2,he used this method
                if (Database.AddSettingsByUserID(user.ID, settings) > 0)//so he could get the ID
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
		/// <summary>
		/// gets the user by it's ID
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
        public static User SelectUser(User user)//not used
        {
            return Database.GetUserByID(user.ID);
        }
		/// <summary>
		/// checks if there's already a user registered with that email address
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
        public static User GetRegisteredUser(string userEmail)//used in user service
        {
            return Database.GetUserByEmail(userEmail);
        }

        public static int UpdateUser(User user)//used in user service
        {
            return Database.UpdateUser(user);
        }
    }
}
