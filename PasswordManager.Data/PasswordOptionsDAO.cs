using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;
using PasswordManager.Database;

namespace PasswordManager.DAO
{
    public static class PasswordOptionsDAO
    {
        
        private static DB Database = DB.Instance();


        public static int UpdatePasswordOptionsBySettings(Settings settings, PasswordOptions passwordOptions)
        {
            return Database.UpdatePasswordOptionsBySettingsID(settings.ID, passwordOptions);
        }

        public static PasswordOptions GetPasswordOptionsBySettings(Settings settings)
        {
            return Database.GetPasswordOptionsBySettingsID(settings.ID);
        }
    }
}
