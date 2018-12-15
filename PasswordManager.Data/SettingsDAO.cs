using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;
using PasswordManager.Database;

namespace PasswordManager.DAO
{
    public static class SettingsDAO
    {
        

        private static DB Database = DB.Instance();

        public static int UpdateUserSettings(User user, Settings settings)
        {
            return Database.UpdateSettings(user.ID, settings);
        }

        public static Settings GetUserSettings(User user)
        {
            return Database.GetSettingsByUserID(user.ID);
        }
    }
}
