using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;
using System.Data.SqlClient;

namespace PasswordManager.Database
{
    /// <summary>
    /// This class gives direct access to Functions with SQL Queries to Database.
    /// </summary>
    public class DB
    {
        private static DB _instance;
		private SqlConnection connection;
		static string connectionString = @"Data Source=(local); Initial Catalog=PasswordManager; Integrated Security = TRUE";

		protected DB()
        {
			//connection = new SqlConnection(@"Data Source=(local); Initial Catalog=PasswordManager; Integrated Security = TRUE");
        }

        public static DB Instance()
        {
            if (_instance == null)
            {
                _instance = new DB();
            }

            return _instance;
        }
		#region User methods
		/// <summary>
		/// Add New User with Settings and PasswordOptions
		/// </summary>
		/// <param name="user">User Entity.</param>
		/// <param name="settings">Settings Entity.</param>
		/// <param name="passwordOptions">PasswordOptions Entity.</param>
		/// <returns>Number of Rows Affected.</returns>
		public int AddNewUser(string[] userData)
        {
            int AffectedRows = -1;

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = connection.CreateCommand();
				SqlTransaction userTransaction = connection.BeginTransaction();

				command.Connection = connection;
				command.Transaction = userTransaction;

				try
				{
					//Adding New User Values
					command.CommandText = "Insert into Users (Name, Username, Email, MasterPassword) values (@Name, @Username, @Email, @MasterPassword)";
					command.Parameters.AddWithValue("Name", userData[0]);
					command.Parameters.AddWithValue("Username", userData[1]);
					command.Parameters.AddWithValue("Email", userData[2]);
					command.Parameters.AddWithValue("MasterPassword", userData[3]);

					//Add User to Database
					AffectedRows = command.ExecuteNonQuery();
					// Attempt to commit the transaction.
					userTransaction.Commit();
				}
				catch
				{
					userTransaction.Rollback();

					return 0;
				}
			}
			return AffectedRows;
        }
        
        /// <summary>
        /// Get User from Database
        /// </summary>
        /// <param name="userID">User ID to select User.</param>
        /// <returns>User Entity.</returns>
        public User GetUserByID(int userID)
        {
            User user = null;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Select * from Users where ID = @ID", connection))
				{
					command.Parameters.AddWithValue("@ID", userID);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							user = new User
							{
								ID = Convert.ToInt32(reader["ID"]),
								Name = reader["Name"].ToString(),
								Username = reader["Username"].ToString(),
								Email = reader["Email"].ToString(),
								Master = reader["MasterPassword"].ToString()
							};
						}
					}
				}
			}
			return user;
        }

        /// <summary>
        /// Get User from Database via Email
        /// </summary>
        /// <param name="Email">User Email to select User.</param>
        /// <returns>User Entity.</returns>
        public User GetUserByEmail(string Email)
        {
            User user = null;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Select * from Users where Email = @Email", connection))
				{
					command.Parameters.AddWithValue("@Email", Email);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							user = new User
							{
								ID = Convert.ToInt32(reader["ID"]),
								Name = reader["Name"].ToString(),
								Username = reader["Username"].ToString(),
								Email = Email,
								Master = reader["MasterPassword"].ToString()
							};
						}
					}
				}
			}
			return user;
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user">User Entity to Update.</param>
        /// <returns>Number of Rows Affected.</returns>
        public int UpdateUser(User user)
        {
            int AffectedRows = -1;//why -1 in someplaces and 0 in others?
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Update Users set Name= @Name, Username= @Username, @Email=@Email, MasterPassword= @MasterPassword where ID = @ID", connection))
				{
					command.Parameters.AddWithValue("@ID", user.ID);
					command.Parameters.AddWithValue("@Name", user.Name);
					command.Parameters.AddWithValue("@Username", user.Username);
					command.Parameters.AddWithValue("@Email", user.Email);
					command.Parameters.AddWithValue("@MasterPassword", user.Master);


					AffectedRows = command.ExecuteNonQuery();
				}
			}
			return AffectedRows;
        }
		#endregion
		#region Password methods
		/// <summary>
		/// Add New Password to Database.
		/// </summary>
		/// <param name="userID">User ID to add Password for.</param>
		/// <param name="password">Password Entity to be saved.</param>
		/// <returns>Number of Rows Affected.</returns>
		public int AddNewPassword(int userID, Password password)
        {
            int AffectedRows = -1;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Insert into Passwords (UserID, Name, Email, Username, Website, Body, Notes, DateCreated, DateModified) values (@UserID, @Name, @Email, @Username, @Website, @Body, @Notes, @DateCreated, @DateModified)", connection))
				{
					command.Parameters.AddWithValue("UserID", userID);
					command.Parameters.AddWithValue("Name", password.Name);
					command.Parameters.AddWithValue("Email", password.Email);
					command.Parameters.AddWithValue("Username", password.Username);
					command.Parameters.AddWithValue("Website", password.Website);
					command.Parameters.AddWithValue("Body", password.Text);
					command.Parameters.AddWithValue("Notes", password.Notes);
					command.Parameters.AddWithValue("DateCreated", password.DateCreated);
					command.Parameters.AddWithValue("DateModified", password.DateModified);


					AffectedRows = command.ExecuteNonQuery();
				}
			}
			return AffectedRows;
        }

        /// <summary>
        /// Add List of New Passwords to Database.
        /// </summary>
        /// <param name="userID">User ID to Add Passwords to.</param>
        /// <param name="passwords">List of Passwords.</param>
        /// <returns>Number of Rows Affected.</returns>
        public int AddNewPasswords(int userID, List<Password> passwords)
        {
            int AffectedRows = 0;
			foreach (Password password in passwords)
			{
				using (connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(
				"Insert into Passwords (UserID, Name, Email, Username, Website, Body, Notes, DateCreated, DateModified) values (@UserID, @Name, @Email, @Username, @Website, @Body, @Notes, @DateCreated, @DateModified)", connection))
					{
						command.Parameters.AddWithValue("UserID", userID);
						command.Parameters.AddWithValue("Name", password.Name);
						command.Parameters.AddWithValue("Email", password.Email);
						command.Parameters.AddWithValue("Username", password.Username);
						command.Parameters.AddWithValue("Website", password.Website);
						command.Parameters.AddWithValue("Body", password.Text);
						command.Parameters.AddWithValue("Notes", password.Notes);
						command.Parameters.AddWithValue("DateCreated", password.DateCreated);
						command.Parameters.AddWithValue("DateModified", password.DateModified);


						AffectedRows += command.ExecuteNonQuery();
					}
				}
			}
			return AffectedRows;
        }

        /// <summary>
        /// Get List of Passwords.
        /// </summary>
        /// <param name="userID">User ID for Passwords</param>
        /// <returns>List of Passwords.</returns>
        public List<Password> GetPasswordsByUserID(int userID)
        {
			List<Password> passwords = new List<Password>();
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Select * from Passwords where UserID = @UserID", connection))
				{
					command.Parameters.AddWithValue("@UserID", userID);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						Password password;

						while (reader.Read())
						{
							password = new Password
							{
								ID = Convert.ToInt32(reader["ID"]),
								UserID = userID,
								Name = reader["Name"].ToString(),
								Email = reader["Email"].ToString(),
								Username = reader["Username"].ToString(),
								Website = reader["Website"].ToString(),
								Text = reader["Body"].ToString(),
								Notes = reader["Notes"].ToString(),
								DateCreated = Convert.ToDateTime(reader["DateCreated"].ToString()),
								DateModified = Convert.ToDateTime(reader["DateModified"].ToString())
							};

							passwords.Add(password);
						}
					}
				}
			}
			return passwords;
        }

        /// <summary>
        /// Update the supplied Password
        /// </summary>
        /// <param name="userID">User ID for Password.</param>
        /// <param name="password">Password Entity to be updated.</param>
        /// <returns>Number of Rows Affected.</returns>
        public int UpdatePassword(int userID, Password password)
        {
            int AffectedRows = 0;

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Update Passwords set Name= @Name, Email=@Email, Username= @Username, Website= @Website, Body= @Body, Notes= @Notes, DateCreated= @DateCreated, DateModified= @DateModified where ID = @ID AND UserID= @UserID", connection))
				{
					command.Parameters.AddWithValue("ID", password.ID);
					command.Parameters.AddWithValue("UserID", userID);
					command.Parameters.AddWithValue("Name", password.Name);
					command.Parameters.AddWithValue("Email", password.Email);
					command.Parameters.AddWithValue("Username", password.Username);
					command.Parameters.AddWithValue("Website", password.Website);
					command.Parameters.AddWithValue("Body", password.Text);
					command.Parameters.AddWithValue("Notes", password.Notes);
					command.Parameters.AddWithValue("DateCreated", password.DateCreated);
					command.Parameters.AddWithValue("DateModified", password.DateModified);


					AffectedRows = command.ExecuteNonQuery();
				}
			}
			return AffectedRows;
        }

        /// <summary>
        /// Updates List of Passwords.
        /// </summary>
        /// <param name="userID">User ID for Passwords.</param>
        /// <param name="passwords">List of Password Entities.</param>
        /// <returns>Number of Rows Affected.</returns>
        public int UpdatePasswords(int userID, List<Password> passwords)
        {
            //we'll use transaction in here
            int AffectedRows = 0;

            foreach (Password password in passwords)
            {
                AffectedRows += UpdatePassword(userID, password);
            }

            return AffectedRows;
        }

        /// <summary>
        /// Deletes the Password.
        /// </summary>
        /// <param name="userID">User ID for Password.</param>
        /// <param name="passwordID">Password ID for Password.</param>
        /// <returns>Number of Rows Affected.</returns>
        public int DeletePasswordByID(int userID, int passwordID)
        {
            int AffectedRows = 0;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Delete from Passwords where ID = @ID AND UserID = @UserID", connection))
				{
					command.Parameters.AddWithValue("ID", passwordID);
					command.Parameters.AddWithValue("UserID", userID);


					AffectedRows = command.ExecuteNonQuery();
				}
			}
			return AffectedRows;
        }
		#endregion
		#region Settings methods
		/// <summary>
		/// Add Settings to Database for the User.
		/// </summary>
		/// <param name="userID">User ID for Settings.</param>
		/// <param name="settings">Settings Entity to Saved.</param>
		/// <returns>Number of Rows Affected.</returns>
		public int AddSettingsByUserID(int userID, Settings settings)
        {
            int AffectedRows = 0;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Insert into Settings (UserID, DateTimeFormat, ShowEmailColumn, ShowUsernameColumn, ShowPasswordColumn) values (@UserID, @DateTimeFormat, @ShowEmailColumn, @ShowUsernameColumn, @ShowPasswordColumn)", connection))
				{
					command.Parameters.AddWithValue("UserID", userID);
					command.Parameters.AddWithValue("DateTimeFormat", settings.DateTimeFormat);
					command.Parameters.AddWithValue("ShowEmailColumn", settings.ShowEmailColumn);
					command.Parameters.AddWithValue("ShowUsernameColumn", settings.ShowUsernameColumn);
					command.Parameters.AddWithValue("ShowPasswordColumn", settings.ShowPasswordColumn);


					AffectedRows = command.ExecuteNonQuery();
				}
			}
			return AffectedRows;
        }

        /// <summary>
        /// Get Settings against the Supplied User ID
        /// </summary>
        /// <param name="userID">User ID for Settings</param>
        /// <returns>Settings Entity for User.</returns>
        public Settings GetSettingsByUserID(int userID)
        {
			Settings settings = null;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Select * from Settings where UserID = @UserID", connection))
				{
					command.Parameters.AddWithValue("@UserID", userID);


					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							settings = new Settings
							{
								ID = Convert.ToInt32(reader["ID"]),
								UserID = userID,
								ShowEmailColumn = Convert.ToBoolean(reader["ShowEmailColumn"]),
								ShowUsernameColumn = Convert.ToBoolean(reader["ShowUsernameColumn"]),
								ShowPasswordColumn = Convert.ToBoolean(reader["ShowPasswordColumn"]),
								DateTimeFormat = reader["DateTimeFormat"].ToString()
							};
						}
					}
				}
			}


			return settings;
        }

        /// <summary>
        /// Updates Settings for supplied User ID
        /// </summary>
        /// <param name="userID">User ID for Settings</param>
        /// <param name="settings">Settings Entity to be updated.</param>
        /// <returns>Number of Rows Affected.</returns>
        public int UpdateSettings(int userID, Settings settings)
        {
            int AffectedRows = 0;

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
				"Update Settings set DateTimeFormat= @DateTimeFormat, ShowEmailColumn=@ShowEmailColumn, ShowUsernameColumn= @ShowUsernameColumn, ShowPasswordColumn = @ShowPasswordColumn where ID = @ID AND UserID = @UserID", connection))
				{
					command.Parameters.AddWithValue("ID", settings.ID);
					command.Parameters.AddWithValue("UserID", userID);
					command.Parameters.AddWithValue("DateTimeFormat", settings.DateTimeFormat);
					command.Parameters.AddWithValue("ShowEmailColumn", settings.ShowEmailColumn);
					command.Parameters.AddWithValue("ShowUsernameColumn", settings.ShowUsernameColumn);
					command.Parameters.AddWithValue("ShowPasswordColumn", settings.ShowPasswordColumn);


					AffectedRows = command.ExecuteNonQuery();
				}
			}

			return AffectedRows;
        }
		#endregion
		#region PasswordOptions methods
		public int AddPasswordOptionsBySettingsID(int settingsID, PasswordOptions passwordOptions)
        {
            int AffectedRows = 0;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(@"Insert into PasswordOptions (SettingsID, AllowLowercaseCharacters, AllowUppercaseCharacters, AllowNumberCharacters, AllowSpecialCharacters, AllowUnderscoreCharacters, AllowSpaceCharacters, AllowOtherCharacters, RequireLowercaseCharacters, RequireUppercaseCharacters, RequireNumberCharacters, RequireSpecialCharacters, RequireUnderscoreCharacters, RequireSpaceCharacters, RequireOtherCharacters, MinimumCharacters, MaximumCharacters ) values (@SettingsID, @AllowLowercaseCharacters, @AllowUppercaseCharacters, @AllowNumberCharacters, @AllowSpecialCharacters, @AllowUnderscoreCharacters, @AllowSpaceCharacters, @AllowOtherCharacters, @RequireLowercaseCharacters, @RequireUppercaseCharacters, @RequireNumberCharacters, @RequireSpecialCharacters, @RequireUnderscoreCharacters, @RequireSpaceCharacters, @RequireOtherCharacters, @MinimumCharacters, @MaximumCharacters)", connection))
				{
					command.Parameters.AddWithValue("SettingsID", settingsID);
					command.Parameters.AddWithValue("AllowLowercaseCharacters", passwordOptions.AllowLowercaseCharacters);
					command.Parameters.AddWithValue("AllowUppercaseCharacters", passwordOptions.AllowUppercaseCharacters);
					command.Parameters.AddWithValue("AllowNumberCharacters", passwordOptions.AllowNumberCharacters);
					command.Parameters.AddWithValue("AllowSpecialCharacters", passwordOptions.AllowSpecialCharacters);
					command.Parameters.AddWithValue("AllowUnderscoreCharacters", passwordOptions.AllowUnderscoreCharacters);
					command.Parameters.AddWithValue("AllowSpaceCharacters", passwordOptions.AllowSpaceCharacters);
					command.Parameters.AddWithValue("AllowOtherCharacters", passwordOptions.AllowOtherCharacters);
					command.Parameters.AddWithValue("RequireLowercaseCharacters", passwordOptions.RequireLowercaseCharacters);
					command.Parameters.AddWithValue("RequireUppercaseCharacters", passwordOptions.RequireUppercaseCharacters);
					command.Parameters.AddWithValue("RequireNumberCharacters", passwordOptions.RequireNumberCharacters);
					command.Parameters.AddWithValue("RequireSpecialCharacters", passwordOptions.RequireSpecialCharacters);
					command.Parameters.AddWithValue("RequireUnderscoreCharacters", passwordOptions.RequireUnderscoreCharacters);
					command.Parameters.AddWithValue("RequireSpaceCharacters", passwordOptions.RequireSpaceCharacters);
					command.Parameters.AddWithValue("RequireOtherCharacters", passwordOptions.RequireOtherCharacters);
					command.Parameters.AddWithValue("MinimumCharacters", passwordOptions.MinimumCharacters);
					command.Parameters.AddWithValue("MaximumCharacters", passwordOptions.MaximumCharacters);


					AffectedRows = command.ExecuteNonQuery();
				}
			}


			return AffectedRows;
        }

        /// <summary>
        /// Get PasswordOptions from Database.
        /// </summary>
        /// <param name="userID">User ID for PasswordOptions</param>
        /// <returns>PasswordOptions Entity.</returns>
        public PasswordOptions GetPasswordOptionsByID(int userID)//Not used 
        {
            PasswordOptions passwordOptions = null;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Select * from PasswordOptions where SettingsID = @SettingsID", connection))
				{
					//this method is rough right now. It will be removed later
					command.Parameters.AddWithValue("@SettingsID", userID);//how come we use userID for Settings
																		   //ID, this is duplicated code!

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							passwordOptions = new PasswordOptions();
							passwordOptions.AllowLowercaseCharacters = Convert.ToBoolean(reader["AllowLowercaseCharacters"]);
							passwordOptions.AllowUppercaseCharacters = Convert.ToBoolean(reader["AllowUppercaseCharacters"]);
							passwordOptions.AllowNumberCharacters = Convert.ToBoolean(reader["AllowNumberCharacters"]);
							passwordOptions.AllowSpecialCharacters = Convert.ToBoolean(reader["AllowSpecialCharacters"]);
							passwordOptions.AllowUnderscoreCharacters = Convert.ToBoolean(reader["AllowUnderscoreCharacters"]);
							passwordOptions.AllowSpaceCharacters = Convert.ToBoolean(reader["AllowSpaceCharacters"]);
							passwordOptions.AllowOtherCharacters = Convert.ToBoolean(reader["AllowOtherCharacters"]);
							passwordOptions.RequireLowercaseCharacters = Convert.ToBoolean(reader["RequireLowercaseCharacters"]);
							passwordOptions.RequireUppercaseCharacters = Convert.ToBoolean(reader["RequireUppercaseCharacters"]);
							passwordOptions.RequireNumberCharacters = Convert.ToBoolean(reader["RequireNumberCharacters"]);
							passwordOptions.RequireSpecialCharacters = Convert.ToBoolean(reader["RequireSpecialCharacters"]);
							passwordOptions.RequireUnderscoreCharacters = Convert.ToBoolean(reader["RequireUnderscoreCharacters"]);
							passwordOptions.RequireSpaceCharacters = Convert.ToBoolean(reader["RequireSpaceCharacters"]);
							passwordOptions.RequireOtherCharacters = Convert.ToBoolean(reader["RequireOtherCharacters"]);
							passwordOptions.MinimumCharacters = Convert.ToInt32(reader["MinimumCharacters"]);
							passwordOptions.MaximumCharacters = Convert.ToInt32(reader["MaximumCharacters"]);
							passwordOptions.OtherCharacters = Convert.ToString(reader["OtherCharacters"]);
						}
					}
				}
			}

			return passwordOptions;
        }

        /// <summary>
        /// Get PasswordOptions by Setting ID
        /// </summary>
        /// <param name="settingsID">Settings ID for PasswordOptions</param>
        /// <returns>PasswordOptions Entity.</returns>
        public PasswordOptions GetPasswordOptionsBySettingsID(int settingsID)//used in PasswordOptionsDAO
        {
            PasswordOptions passwordOptions = null;
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			"Select * from PasswordOptions where SettingsID = @SettingsID", connection))
				{
					command.Parameters.AddWithValue("@SettingsID", settingsID);


					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							passwordOptions = new PasswordOptions();
							passwordOptions.ID = Convert.ToInt32(reader["ID"]);
							passwordOptions.SettingsID = settingsID;
							passwordOptions.AllowLowercaseCharacters = Convert.ToBoolean(reader["AllowLowercaseCharacters"]);
							passwordOptions.AllowUppercaseCharacters = Convert.ToBoolean(reader["AllowUppercaseCharacters"]);
							passwordOptions.AllowNumberCharacters = Convert.ToBoolean(reader["AllowNumberCharacters"]);
							passwordOptions.AllowSpecialCharacters = Convert.ToBoolean(reader["AllowSpecialCharacters"]);
							passwordOptions.AllowUnderscoreCharacters = Convert.ToBoolean(reader["AllowUnderscoreCharacters"]);
							passwordOptions.AllowSpaceCharacters = Convert.ToBoolean(reader["AllowSpaceCharacters"]);
							passwordOptions.AllowOtherCharacters = Convert.ToBoolean(reader["AllowOtherCharacters"]);
							passwordOptions.RequireLowercaseCharacters = Convert.ToBoolean(reader["RequireLowercaseCharacters"]);
							passwordOptions.RequireUppercaseCharacters = Convert.ToBoolean(reader["RequireUppercaseCharacters"]);
							passwordOptions.RequireNumberCharacters = Convert.ToBoolean(reader["RequireNumberCharacters"]);
							passwordOptions.RequireSpecialCharacters = Convert.ToBoolean(reader["RequireSpecialCharacters"]);
							passwordOptions.RequireUnderscoreCharacters = Convert.ToBoolean(reader["RequireUnderscoreCharacters"]);
							passwordOptions.RequireSpaceCharacters = Convert.ToBoolean(reader["RequireSpaceCharacters"]);
							passwordOptions.RequireOtherCharacters = Convert.ToBoolean(reader["RequireOtherCharacters"]);
							passwordOptions.MinimumCharacters = Convert.ToInt32(reader["MinimumCharacters"]);
							passwordOptions.MaximumCharacters = Convert.ToInt32(reader["MaximumCharacters"]);
							passwordOptions.OtherCharacters = Convert.ToString(reader["OtherCharacters"]);
						}
					}
				}
			}


			return passwordOptions;
        }

        /// <summary>
        /// Updates PasswordOptions for the Supplied Settings ID.
        /// </summary>
        /// <param name="settingsID">Settings ID for PasswordOptions.</param>
        /// <param name="passwordOptions">PasswordOptions Entity to be updated.</param>
        /// <returns>Number of Rows Affected.</returns>
        public int UpdatePasswordOptionsBySettingsID(int settingsID, PasswordOptions passwordOptions)
        {
            int AffectedRows = 0;

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
			@"Update PasswordOptions set
                  AllowLowercaseCharacters     = @AllowLowercaseCharacters,
                  AllowUppercaseCharacters     = @AllowUppercaseCharacters,
                  AllowNumberCharacters        = @AllowNumberCharacters,
                  AllowSpecialCharacters       = @AllowSpecialCharacters,
                  AllowUnderscoreCharacters    = @AllowUnderscoreCharacters,
                  AllowSpaceCharacters         = @AllowSpaceCharacters,
                  AllowOtherCharacters         = @AllowOtherCharacters,
                  RequireLowercaseCharacters   = @RequireLowercaseCharacters,
                  RequireUppercaseCharacters   = @RequireUppercaseCharacters,
                  RequireNumberCharacters      = @RequireNumberCharacters,
                  RequireSpecialCharacters     = @RequireSpecialCharacters,
                  RequireUnderscoreCharacters  = @RequireUnderscoreCharacters,
                  RequireSpaceCharacters       = @RequireSpaceCharacters,
                  RequireOtherCharacters       = @RequireOtherCharacters,
                  MinimumCharacters            = @MinimumCharacters,
                  MaximumCharacters            = @MaximumCharacters,
                  OtherCharacters              = @OtherCharacters
                  where SettingsID = @SettingsID
                ", connection))
				{
					command.Parameters.AddWithValue("SettingsID", settingsID);
					command.Parameters.AddWithValue("AllowLowercaseCharacters", passwordOptions.AllowLowercaseCharacters);
					command.Parameters.AddWithValue("AllowUppercaseCharacters", passwordOptions.AllowUppercaseCharacters);
					command.Parameters.AddWithValue("AllowNumberCharacters", passwordOptions.AllowNumberCharacters);
					command.Parameters.AddWithValue("AllowSpecialCharacters", passwordOptions.AllowSpecialCharacters);
					command.Parameters.AddWithValue("AllowUnderscoreCharacters", passwordOptions.AllowUnderscoreCharacters);
					command.Parameters.AddWithValue("AllowSpaceCharacters", passwordOptions.AllowSpaceCharacters);
					command.Parameters.AddWithValue("AllowOtherCharacters", passwordOptions.AllowOtherCharacters);
					command.Parameters.AddWithValue("RequireLowercaseCharacters", passwordOptions.RequireLowercaseCharacters);
					command.Parameters.AddWithValue("RequireUppercaseCharacters", passwordOptions.RequireUppercaseCharacters);
					command.Parameters.AddWithValue("RequireNumberCharacters", passwordOptions.RequireNumberCharacters);
					command.Parameters.AddWithValue("RequireSpecialCharacters", passwordOptions.RequireSpecialCharacters);
					command.Parameters.AddWithValue("RequireUnderscoreCharacters", passwordOptions.RequireUnderscoreCharacters);
					command.Parameters.AddWithValue("RequireSpaceCharacters", passwordOptions.RequireSpaceCharacters);
					command.Parameters.AddWithValue("RequireOtherCharacters", passwordOptions.RequireOtherCharacters);
					command.Parameters.AddWithValue("MinimumCharacters", passwordOptions.MinimumCharacters);
					command.Parameters.AddWithValue("MaximumCharacters", passwordOptions.MaximumCharacters);
					command.Parameters.AddWithValue("OtherCharacters", passwordOptions.OtherCharacters);


					AffectedRows = command.ExecuteNonQuery();
				}
			}

			return AffectedRows;
        }
		#endregion
	}
}
