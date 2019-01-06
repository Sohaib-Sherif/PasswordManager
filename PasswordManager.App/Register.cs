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
                    lblMassege.Text = "أدخل إسمك";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verify.Text(txtUsername.Text))
                {
                    lblMassege.Text = "أدخل إسم المستخدم";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verify.Email(txtEmail.Text))
                {
                    lblMassege.Text = "الرجاء إدخال بريد إلكتروني صحيح";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verify.Text(txtLoginPass.Text))
                {
                    lblMassege.Text = "أدخل كلمة السر. ستكون هذه كلمة السر الرئيسية خاصتك إفتراضيا";
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
                        await UsersService.RegisterUserAsync(userData);
						//this user has his passwords and everything set to null so initializing the dashboard
						//with it is a problem that's why I'm going to use the method loginUserAsync
						//to login the user and populate his data first.
						User user = await UsersService.LoginUserAsync(userData[2], userData[3]);


						if (user != null)
                        {
                            lblMassege.Text = "تم التسجيل بنجاح";

                            this.Hide();
                            Dashboard dashboard = new Dashboard(user);
                            dashboard.Show();
                        }
                    }
                    else
                    {
                        lblMassege.Text = "هناك مستخدم مسجل بهذه البيانات بالفعل.";
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
