using PasswordManager.DAO;
using PasswordManager.Entities;
using PasswordManager.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to User related objects and data.
    /// </summary>
    public static class UsersService
    {

        /// <summary>
        /// Determines wether User already exists or not.
        /// </summary>
        /// <param name="userEmail">User Email to check.</param>
        /// <returns>Boolean: True if User exists, False if not.</returns>
        public static Task<bool> UserExistAsync(string userEmail)
        {
            return Task.Factory.StartNew(() =>
            {
                if (UserDAO.GetRegisteredUser(userEmail) != null)
                        return true;
                else return false;
            });
        }

        /// <summary>
        /// Registers the new User.
        /// </summary>
        /// <param name="userData">User to be registered.</param>
        /// <returns>User: The newly registered user with Default Settings.</returns>
        public static Task<User> RegisterUserAsync(string[] userData)
        {
            return Task.Factory.StartNew(() =>
            {
				if (UserDAO.AddNewUser(userData, Globals.Defaults.Settings, Globals.Defaults.PasswordOptions) > 0)
                {
					return UserDAO.GetRegisteredUser(userData[2]);//the email is index 2 in the array
                }
                else return null;
            });
        }

        /// <summary>
        /// Login the User.
        /// </summary>
		/// <param name="userEmail"></param>
		/// <param name="userMasterPassword"></param>
        /// <returns>User: The logged in User.</returns>
        public static Task<User> LoginUserAsync(string userEmail, string userMasterPassword)
        {
            return Task.Factory.StartNew(() =>
            {
                User UserFromDB = UserDAO.GetRegisteredUser(userEmail);
				if (Validate.User(UserFromDB) && PasswordsService.IsSame(UserFromDB.Master, userMasterPassword))
				{
					return PopulateUserData(UserFromDB);//decrypts passwords and stuff then return user
				}
				else return null;
            });
        }

        /// <summary>
        /// Login the User.
        /// </summary>
        /// <param name="userEmail"></param>
		/// <param name="userMasterPassword"></param>
        /// <returns>User: The logged in User.</returns>
        public static User LoginUser(string userEmail, string userMasterPassword)
        {
            User UserFromDB = UserDAO.GetRegisteredUser(userEmail);
            if (Validate.User(UserFromDB) && PasswordsService.IsSame(UserFromDB.Master, userMasterPassword))
            {
				return PopulateUserData(UserFromDB);
            }
			else return null;
        }

        /// <summary>
        /// Updates the given User.
        /// </summary>
        /// <param name="user">User to be updated.</param>
        /// <returns>User: updated User.</returns>
        public static Task<User> UpdateUserAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Validate.User(user))
                {
                    if (UserDAO.UpdateUser(user) > 0)
                    {
                        return user;
                    }
                    else return user;
                }
                else return null;
            });
        }


        /// <summary>
        /// Updates the given User.
        /// </summary>
        /// <param name="user">User to be updated.</param>
        /// <returns>User: updated User.</returns>
        public static User UpdateUser(User user)
        {
            if (Validate.User(user))
                {
                    if (UserDAO.UpdateUser(user) > 0)
                    {
                        return user;
                    }
                    else return user;
                }
                else return null;
        }

        /// <summary>
        /// Populates the User with Passwords and Settings.
        /// </summary>
        /// <param name="user">User to be populated.</param>
        /// <returns>User: User with its Passwords and Settings.</returns>
        public static Task<User> PopulateUserDataAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                user.Passwords = CryptoService.DecryptUserPasswords(user, PasswordDAO.GetUserPasswords(user));
                user.Settings = SettingsDAO.GetUserSettings(user);
                user.Settings.PasswordOptions = PasswordOptionsDAO.GetPasswordOptionsBySettings(user.Settings);
                return user;
            });
        }

        /// <summary>
        /// Populates the User with Passwords and Settings.
        /// </summary>
        /// <param name="user">User to be populated.</param>
        /// <returns>User: User with its Passwords and Settings.</returns>
        private static User PopulateUserData(User user)
        {
            user.Passwords = CryptoService.DecryptUserPasswords(user, PasswordDAO.GetUserPasswords(user));
            user.Settings = SettingsDAO.GetUserSettings(user);
            user.Settings.PasswordOptions = PasswordOptionsDAO.GetPasswordOptionsBySettings(user.Settings);
			return user;
        }
    }
}
