using PasswordManager.DAO;
using PasswordManager.Entities;
using PasswordManager.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to User related Settings and data.
    /// </summary>
    public static class SettingsService
    {

        /// <summary>
        /// Gets the Settings for Supplied User.
        /// </summary>
        /// <param name="user">User for which Settings are required.</param>
        /// <returns>Settings: The Settings for User</returns>
        public static Task<Settings> GetUserSettingsAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
				return SettingsDAO.GetUserSettings(user);
            });
        }

        /// <summary>
        /// Updates the supplied User Settings.
        /// </summary>
        /// <param name="user">User for which settings are to be updated.</param>
        /// <param name="settings">Settings which are to be updated.</param>
        /// <returns>User: User with the updated settings.</returns>
        public static Task<User> UpdateUserSettingsAsync(User user, Settings settings)
        {
            return Task.Factory.StartNew(() =>
            {
				if (SettingsDAO.UpdateUserSettings(user, settings) > 0)
				{
					user.Settings = settings;

					return user;
				}
				else return null;
            });
        }

        /// <summary>
        /// Gets the PasswordOptions Settings.
        /// </summary>
        /// <param name="settings">Settings for which PasswordOptions are required.</param>
        /// <returns>PasswordOptions object to be attached to settings.</returns>
        public static Task<PasswordOptions> GetUserPasswordOptionsAsync(Settings settings)
        {
            return Task.Factory.StartNew(() =>
            {
				return PasswordOptionsDAO.GetPasswordOptionsBySettings(settings);
            });
        }

        /// <summary>
        /// Updates the PasswordOptions for supplied User Settings
        /// </summary>
        /// <param name="settings">Settings to be updated with PasswordOptions.</param>
        /// <param name="passwordOptions">PasswordOptions to be updated.</param>
        /// <returns>VOOOOIIIIDDDD</returns>
        public static Task UpdateUserPasswordOptionsAsync(Settings settings, PasswordOptions passwordOptions)
        {
            return Task.Factory.StartNew(() =>
            {
				PasswordOptionsDAO.UpdatePasswordOptionsBySettings(settings, passwordOptions);
			});
        }
    }
}
