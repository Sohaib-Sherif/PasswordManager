using PasswordManager.Entities;
using PasswordManager.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PasswordManager.Utilities//Move into Utilities or something
{
    /// <summary>
    /// A static class that provides validation for different entities and objects in BearPass
    /// </summary>
    public static class Validate
    {

        /// <summary>
        /// Determines wether the supplied User object is valid.
        /// </summary>
        /// <param name="user">User object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public static bool User(User user)
        {
            //we should also check if user is authorized or exists -gul:0301171247
            //i think that would be heavy operation because i am calling this method in so many places. -gul:0401171150
            if (user != null)
            {
                if (Verify.ID(user.ID) && Verify.Email(user.Email) && Verify.Text(user.Master))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied Password object is valid.
        /// </summary>
        /// <param name="password">Password object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public static bool Password(Password password)
        {
            if (password != null)
            {
                if (Verify.Email(password.Email) && Verify.Text(password.Text))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied List of Password objects is valid.
        /// </summary>
        /// <param name="passwords">List of type Password object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public static bool Passwords(List<Password> passwords)
        {
            if (passwords != null)//I find this implementation to be stupid
            {
                bool result = true;

                foreach (Password password in passwords)
                {
                    if (password != null)
                    {
                        if (!Verify.Email(password.Email) || !Verify.Text(password.Text))//why would I verify
                        {//the correctness of a password email?
                            result = false;//I think I should break if one password was incorrect
                        }
                    }
                    else result = false;
                }
                return result;
            }
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied Settings object is valid.
        /// </summary>
        /// <param name="settings">Settings object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public static bool Settings(Settings settings)
        {
            if (settings != null)
            {
                if (Verify.ID(settings.ID) && Verify.ID(settings.UserID))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied PasswordOptions object is valid.
        /// </summary>
        /// <param name="passwordOptions">PasswordOptions object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public static bool PasswordOptions(PasswordOptions passwordOptions)
        {
            if (passwordOptions != null)
            {
                if (Verify.ID(passwordOptions.ID) && Verify.ID(passwordOptions.SettingsID))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
