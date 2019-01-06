﻿using PasswordManager.Entities;
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
    public partial class NewPassword : Form
    {
        User user;
        
        public NewPassword(User user)
        {
            InitializeComponent();

            this.user = user;
            
            txtName.Focus();
        }
        
        private void NewPassword_Load(object sender, EventArgs e)
        {
            //btnSave.Enabled = IsEnable();
        }

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			btnSave.Enabled = IsEnable();//Maybe I should do this to all txtboxes to validate and make sure 
		}//the save btn wont' be enabled untill things are ok.

		private bool IsEnable()
        {
            if (Verify.Text(txtName.Text) && Verify.Text(txtPassword.Text) && Verify.Email(txtEmail.Text))
                return true;
            return false;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            PasswordGenerateOptions passwordGenerateOptionsForm = new PasswordGenerateOptions(user);
			passwordGenerateOptionsForm.ShowDialog();
                //txtPassword.Text = await PasswordsService.GeneratePasswordAsync(user);
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = await PasswordsService.GeneratePasswordAsync(user);
        }
        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            Password newPassword = new Password()
            {
                UserID = user.ID,
                Name = txtName.Text,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                Website = txtWebsite.Text,
                Text = txtPassword.Text,
                Notes = rtxtNotes.Text,

                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            try
            {//I should make sure there is not another password already saved for the same email on the same site
                if(! await PasswordsService.SaveNewUserPasswordAsync(user, newPassword))
				{
					Messenger.Show("Password or Email are not valid", "Error");
				}
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();//why close here and hide everywhere else?-I know why, because it appears as a dialog
			//over the dashboard.
        }
	}
}
