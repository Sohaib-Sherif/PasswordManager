using PasswordManager.Entities;
using PasswordManager.Globals;
using PasswordManager.Services;
using PasswordManager.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.App
{
    public partial class PasswordGenerateOptions : Form
    {
        private User user;

        public PasswordOptions PasswordOptions { get; set; }

        public PasswordGenerateOptions(User user)
        {
            InitializeComponent();

            this.user = user;
            PasswordOptions = user.Settings.PasswordOptions;
        }

        private void PasswordGenerateOptions_Load(object sender, EventArgs e)
        {
            AllowLowercaseCheckBox.Checked =PasswordOptions.AllowLowercaseCharacters;
            AllowUppercaseCheckBox.Checked =PasswordOptions.AllowUppercaseCharacters;
            AllowNumberCheckBox.Checked =PasswordOptions.AllowNumberCharacters;
            AllowSpecialCheckBox.Checked =PasswordOptions.AllowSpecialCharacters;
            AllowUnderscoreCheckBox.Checked =PasswordOptions.AllowUnderscoreCharacters;
            AllowSpaceCheckBox.Checked =PasswordOptions.AllowSpaceCharacters;

            RequireLowercaseCheckBox.Checked =PasswordOptions.RequireLowercaseCharacters;
            RequireUppercaseCheckBox.Checked =PasswordOptions.RequireUppercaseCharacters;
            RequireNumberCheckBox.Checked =PasswordOptions.RequireNumberCharacters;
            RequireSpecialCheckBox.Checked =PasswordOptions.RequireSpecialCharacters;
            RequireUnderscoreCheckBox.Checked =PasswordOptions.RequireUnderscoreCharacters;
            RequireSpaceCheckBox.Checked =PasswordOptions.RequireSpaceCharacters;

            txtOtherCharacters.Text =PasswordOptions.OtherCharacters;
            txtMinimumCharacters.Text =PasswordOptions.MinimumCharacters.ToString();
            txtMaximumCharacters.Text =PasswordOptions.MaximumCharacters.ToString();
        }
		#region checkBoxes
		private void AllowLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.AllowLowercaseCharacters = AllowLowercaseCheckBox.Checked;
        }

        private void AllowUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.AllowUppercaseCharacters = AllowUppercaseCheckBox.Checked;
        }

        private void AllowNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.AllowNumberCharacters = AllowNumberCheckBox.Checked;
        }

        private void AllowSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.AllowSpecialCharacters = AllowSpecialCheckBox.Checked;
        }

        private void AllowUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.AllowUnderscoreCharacters = AllowUnderscoreCheckBox.Checked;
        }

        private void AllowSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.AllowSpaceCharacters = AllowSpecialCheckBox.Checked;
        }

        private void RequireLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.RequireLowercaseCharacters = RequireLowercaseCheckBox.Checked;
        }

        private void RequireUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.RequireUppercaseCharacters = RequireUppercaseCheckBox.Checked;
        }

        private void RequireNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.RequireNumberCharacters = RequireNumberCheckBox.Checked;
        }

        private void RequireSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.RequireSpecialCharacters = RequireSpecialCheckBox.Checked;
        }

        private void RequireUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.RequireUnderscoreCharacters = RequireUnderscoreCheckBox.Checked;
        }

        private void RequireSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           PasswordOptions.RequireSpaceCharacters = RequireSpaceCheckBox.Checked;
        }
		#endregion

		private void txtOtherCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verify.Text(txtOtherCharacters.Text))
            {
               PasswordOptions.AllowOtherCharacters = true;
               PasswordOptions.RequireOtherCharacters = true;
               PasswordOptions.OtherCharacters = txtOtherCharacters.Text;
            }
            else {
               PasswordOptions.AllowOtherCharacters = false;
               PasswordOptions.RequireOtherCharacters = false;
               PasswordOptions.OtherCharacters = string.Empty;
            }
        }

        private void txtMinimumCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verify.Text(txtMinimumCharacters.Text))
            {
               PasswordOptions.MinimumCharacters = Convert.ToInt32(txtMinimumCharacters.Text);

                if (Verify.Text(txtMaximumCharacters.Text))
                {
                    int MinChars = Convert.ToInt32(txtMinimumCharacters.Text);
                    int MaxChars = Convert.ToInt32(txtMaximumCharacters.Text);

                    if (MinChars > MaxChars)
                        txtMaximumCharacters.Text = txtMinimumCharacters.Text;
                }
            }
            else
            {
               PasswordOptions.MinimumCharacters = 10;
            }
        }

        private void txtMaximumCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verify.Text(txtMaximumCharacters.Text))
            {
               PasswordOptions.MaximumCharacters = Convert.ToInt32(txtMaximumCharacters.Text);

                if (Verify.Text(txtMinimumCharacters.Text))
                {
                    int MinChars = Convert.ToInt32(txtMinimumCharacters.Text);
                    int MaxChars = Convert.ToInt32(txtMaximumCharacters.Text);

					if (MaxChars < MinChars)
						txtMinimumCharacters.Text = txtMaximumCharacters.Text;
                }
            }
            else
            {
               PasswordOptions.MaximumCharacters = 12;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
				user.Settings.PasswordOptions = PasswordOptions;
				//update password options
				SettingsService.UpdateUserPasswordOptionsAsync(user.Settings, PasswordOptions);
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
            }
        }
    }
}
