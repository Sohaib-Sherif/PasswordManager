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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            picboxLoading.Hide();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                btnLogin.Enabled = false;

                if (!Verify.Email(txtEmail.Text))
                {
                    lblMassege.Text = "الرجاء إدخال بريد إلكتروني صحيح";
                    lblMassege.ForeColor = Color.Red;

                    txtEmail.Focus();
                }
                else if (!Verify.Text(txtLoginPass.Text))
                {
                    lblMassege.Text = "الرجاء إدخال كلمة السر";
                    lblMassege.ForeColor = Color.Red;

                    txtLoginPass.Focus();
                }
                else
                {
                    picboxLoading.Show();

                    User loginUser = await UsersService.LoginUserAsync(txtEmail.Text, txtLoginPass.Text);
                    if (loginUser != null)
                    {
                        lblMassege.Text = "تمت عملية تسجيل الدخول بنجاح";

                        this.Hide();
                        Dashboard dashboard = new Dashboard(loginUser);
                        dashboard.Show();
                    }
                    else
                    {
                        lblMassege.Text = "لا يوجد مستخدم بهذا البريد الإلكتروني";
                        lblMassege.ForeColor = Color.Red;

                        txtEmail.Focus();
                    }

                    picboxLoading.Hide();
                }
                btnLogin.Enabled = true;
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message +" "+ ex.HResult, "Error");
                ResetControls();
            }
        }

        public void ResetControls()
        {
            picboxLoading.Hide();
            lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
            lblMassege.Text = string.Empty;
            btnLogin.Enabled = true;
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {//should send the password to the person's email
			ForgotPassword forgotPassword = new ForgotPassword();
			forgotPassword.ShowDialog();
        }
    }
}
