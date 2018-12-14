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
        /// <param name="user">User to check.</param>
        /// <returns>Boolean: True if User exists, False if not.</returns>
        public static Task<bool> UserExistAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Validate.User(user))
                {
                    if (UserDAO.LoginUser(user) != null)
                        return true;
                    else return false;
                }
                else return false;
            });
        }

        /// <summary>
        /// Registers the new User.
        /// </summary>
        /// <param name="user">User to be registered.</param>
        /// <returns>User: The newly registered user with Default Settings.</returns>
        public static Task<User> RegisterUserAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Validate.User(user))
                {// addina a new user with default settings
                    if (UserDAO.AddNewUser(user, Globals.Defaults.Settings, Globals.Defaults.PasswordOptions) > 0)
                    {
                        return LoginUser(user);// why checking here?
                    }
                    else return null;
                }
                else return null;
            });
        }

        /// <summary>
        /// Login the User.
        /// </summary>
        /// <param name="user">User to be Login.</param>
        /// <returns>User: The logged in User.</returns>
        public static Task<User> LoginUserAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Validate.User(user))
                {
                    User UserFromDB = UserDAO.LoginUser(user);
                    if (Validate.User(UserFromDB) && PasswordsService.IsSame(UserFromDB.Master, user.Master))
                    {
                        return PopulateUserData(UserFromDB);
                    }
                    else return null;
                }
                else return null;
            });
        }

        /// <summary>
        /// Login the User.
        /// </summary>
        /// <param name="user">User to be Login.</param>
        /// <returns>User: The logged in User.</returns>
        public static User LoginUser(User user)
        {
            if (Validate.User(user))
            {
                User UserFromDB = UserDAO.LoginUser(user);
                if (Validate.User(UserFromDB) && PasswordsService.IsSame(UserFromDB.Master, user.Master))
                {
                    return PopulateUserData(UserFromDB);
                }
                else return null;
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
                if (Validate.User(user))
                {
                    user.Passwords = CryptoService.DecryptUserPasswords(user, PasswordDAO.GetUserPasswords(user));
                    user.Settings = SettingsDAO.GetUserSettings(user);
                    user.Settings.PasswordOptions = PasswordOptionsDAO.GetPasswordOptionsBySettings(user.Settings);

                    return user;
                }
                else return null;
            });
        }

        /// <summary>
        /// Populates the User with Passwords and Settings.
        /// </summary>
        /// <param name="user">User to be populated.</param>
        /// <returns>User: User with its Passwords and Settings.</returns>
        public static User PopulateUserData(User user)
        {
            if (Validate.User(user))
            {
                user.Passwords = CryptoService.DecryptUserPasswords(user, PasswordDAO.GetUserPasswords(user));
                //user.Settings = (SettingsData.Instance().GetUserSettings(user) == null) ? Globals.Defaults.Settings : SettingsData.Instance().GetUserSettings(user);
                user.Settings = SettingsDAO.GetUserSettings(user);
                user.Settings.PasswordOptions = PasswordOptionsDAO.GetPasswordOptionsBySettings(user.Settings);

                return user;
            }
            else return null;
        }
    }
}
