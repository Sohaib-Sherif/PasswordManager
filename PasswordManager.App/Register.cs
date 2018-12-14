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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                btnRegister.Enabled = false;

                if (!Verify.Text(txtName.Text))
                {
                    lblMassege.Text = "Enter Your Name";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verify.Text(txtUsername.Text))
                {
                    lblMassege.Text = "Enter Your Username";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verify.Email(txtEmail.Text))
                {
                    lblMassege.Text = "Plaese Enter a Valid Email Address.";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verify.Text(txtLoginPass.Text))
                {
                    lblMassege.Text = "Enter Your Password. This will be used as your Master Password by default.";
                    lblMassege.BackColor = Color.Yellow;
                    lblMassege.ForeColor = Color.Red;
                }
                else
                {
                    if (!await UsersService.UserExistAsync(txtEmail.Text))
                    {
						string[] userData = new string[] 
						{
							txtName.Text,
							txtUsername.Text,
							txtEmail.Text,
							txtLoginPass.Text
						};
                        User user = await UsersService.RegisterUserAsync(userData);
						
                        if (user != null)
                        {
                            lblMassege.Text = "User Registered.";

                            this.Hide();
                            Dashboard dashboard = new Dashboard(user);
                            dashboard.Show();
                        }
                    }
                    else
                    {
                        lblMassege.Text = "A user with these credentials is already registered. Please Login or use different Email and Username.";
                        lblMassege.ForeColor = Color.Red;
                    }
                    picboxLoading.Hide();
                }
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
                ResetControls();
            }
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        public void ResetControls()
        {
            picboxLoading.Show();
            lblMassege.BackColor = Color.Transparent;
            lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
            lblMassege.Text = string.Empty;
            btnRegister.Enabled = true;
        }
    }
}
