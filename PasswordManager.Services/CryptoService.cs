using PasswordManager.Entities;
using PasswordManager.Globals;
using PasswordManager.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to Encryption and Decryption functions.
    /// </summary>
    public static class CryptoService
    {

        /// <summary>
        /// Encrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="password">Password to be encrypted.</param>
        /// <returns>Password: The Password in encrypted format.</returns>
        public static Task<Password> EncryptUserPasswordAsync(User user, Password password)
        {
            return Task.Factory.StartNew(() =>
            {
				if (Verify.Text(password.Text))
				{
					password.Text = Gulipso.Encrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
				}
					return password;
            });
        }


        /// <summary>
        /// Encrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="password">Password to be encrypted.</param>
        /// <returns>Password: The Password in encrypted format.</returns>
        public static Password EncryptUserPassword(User user, Password password) 
        {
			if (Verify.Text(password.Text))
			{
				password.Text = Gulipso.Encrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
			}			
			return password;
        }

        /// <summary>
        /// Encrypts the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="passwords">List of Passwords to be encrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in encrypted format.</returns>
        public static Task<List<Password>> EncryptUserPasswordsAsync(User user, List<Password> passwords)
        {
            return Task.Factory.StartNew(() =>
            {
                List<Password> EncryptedPasswords = new List<Password>();

                foreach (Password password in passwords)
                {
                    EncryptedPasswords.Add(EncryptUserPassword(user, password));
                }

                return EncryptedPasswords;
            });
        }

        /// <summary>
        /// Encrypts the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="passwords">List of Passwords to be encrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in encrypted format.</returns>
        public static List<Password> EncryptUserPasswords(User user, List<Password> passwords)
        {
            List<Password> EncryptedPasswords = new List<Password>();

                foreach (Password password in passwords)
                {
                    EncryptedPasswords.Add(EncryptUserPassword(user, password));
                }

                return EncryptedPasswords;
        }

        /// <summary>
        /// Decrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="password">Password to be Decrypted.</param>
        /// <returns>Password: The Password in Decrypted format.</returns>
        public static Task<Password> DecryptUserPasswordAsync(User user, Password password)
        {
            return Task.Factory.StartNew(() =>
            {
				if (Verify.Text(password.Text))
				{
					password.Text = Gulipso.Decrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
				}
				return password;
            });
        }

        /// <summary>
        /// Decrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="password">Password to be Decrypted.</param>
        /// <returns>Password: The Password in Decrypted format.</returns>
        public static Password DecryptUserPassword(User user, Password password)
        {
			if (Verify.Text(password.Text))
			{
				password.Text = Gulipso.Decrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
			}
			return password;
        }

        /// <summary>
        /// Decrypted the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="passwords">List of Passwords to be Decrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in Decrypted format.</returns>
        public static Task<List<Password>> DecryptUserPasswordsAsync(User user, List<Password> passwords)
        {
            return Task.Factory.StartNew(() =>
            {
                List<Password> decryptedPasswords = new List<Password>();

                foreach (var password in passwords)
                {
                    decryptedPasswords.Add(DecryptUserPassword(user, password));
                }
                return decryptedPasswords;
            });
        }

        /// <summary>
        /// Decrypted the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="passwords">List of Passwords to be Decrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in Decrypted format.</returns>
        public static List<Password> DecryptUserPasswords(User user, List<Password> passwords)
        {
            List<Password> decryptedPasswords = new List<Password>();

                foreach (var password in passwords)
                {
                    decryptedPasswords.Add(DecryptUserPassword(user, password));
                }
                return decryptedPasswords;
        }
    }
}
