using PasswordManager.Entities;
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
    public partial class Dashboard : Form
    {
        User user;

        public Dashboard(User user)
        {
            InitializeComponent();
            
            this.user = user;

            LoadSettings(user.Settings);
        }

        public void LoadSettings(Settings settings)
        {
            if (settings != null)
            {
                PasswordsGridView.Columns["ColEmail"].Visible = settings.ShowEmailColumn;
                PasswordsGridView.Columns["ColUsername"].Visible = settings.ShowUsernameColumn;
                PasswordsGridView.Columns["ColPassword"].Visible = settings.ShowPasswordColumn;
                ShowPasswords(user.Passwords);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = user.Name + " - " + Globals.Information.AppName + " Dashboard";

            ShowPasswords(user.Passwords);
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            ShowPasswords(user);
        }

        private async void btnSearchPassword_Click(object sender, EventArgs e)
        {
            Search searchForm = new Search();

            if(searchForm.ShowDialog() == DialogResult.OK)
            {
                string SearchTerm = searchForm.txtSearchPassword.Text;

                string LooksFor = string.Empty;

                if(searchForm.rdbLookEmail.Checked)
                {
                    LooksFor = "Email";
                }
                else if (searchForm.rdbLookUsername.Checked)
                {
                    LooksFor = "Username";
                }
                else LooksFor = "Name";

                string Options = string.Empty;
                if (searchForm.rdbOptionContains.Checked)
                {
                    Options = "Contains";
                }
                else Options = "Equals";

                try
                {
                    ShowPasswords(await PasswordsService.SearchUserPasswordsAsync(user, SearchTerm, LooksFor, Options));
                }
                catch (Exception ex)
                {
                    Messenger.Show(ex.Message + " " + ex.HResult, "Error");
                }
            }
        }

        private async void btnNewPassword_Click(object sender, EventArgs e)
        {
            NewPassword newPasswordForm = new NewPassword(user);

            if (newPasswordForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    user.Passwords = await PasswordsService.GetAllUserPasswordsAsync(user);
                    ShowPasswords(user.Passwords);
                    PasswordsGridView.Focus();
                    PasswordsGridView.CurrentCell = PasswordsGridView.Rows[PasswordsGridView.Rows.Count - 1].Cells[2];
                }
                catch (Exception ex)
                {
                    Messenger.Show(ex.Message + " " + ex.HResult, "Error");
                }
            }
        }

        private async void btnMasterPassword_Click(object sender, EventArgs e)
        {
            MasterPasswordForm masterPasswordForm = new MasterPasswordForm(user);
            masterPasswordForm.ShowDialog();

            //weird but working :p
            try
            {
                ShowPasswords(await PasswordsService.GetAllUserPasswordsAsync(user));
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
            }
        }

		private void btnGuide_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();

            guide.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(user);

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadSettings(user.Settings);
                }
                catch (Exception ex)
                {
                    Messenger.Show(ex.Message + " " + ex.HResult, "Error");
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ShowPasswords()
        {
            ShowPasswords(user);
        }
        public async void ShowPasswords(User user)
        {
            ShowPasswords(await PasswordsService.GetAllUserPasswordsAsync(user));
        }
        public void ShowPasswords(List<Password> Passwords)
        {
            PasswordsGridView.Rows.Clear();

            foreach (Password password in Passwords)
            {
                PasswordsGridView.Rows.Add(password.ID, password.DateCreated.ToString(user.Settings.DateTimeFormat), password.Name, password.Email, password.Username, password.Text);
            }
        }

        private void PasswordsGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (sender as DataGridView);

            //Skip the Column and Row headers
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                dataGridView.Cursor = Cursors.Default;
            }
            else
            {
                if (e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
                    dataGridView.Cursor = Cursors.Hand;
                else
                    dataGridView.Cursor = Cursors.Default;
            }
        }

        private async void PasswordsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColCopy")
                {
                    Clipboard.Clear();
                    Clipboard.SetText(PasswordsGridView.Rows[e.RowIndex].Cells["ColPassword"].Value.ToString());
                    System.Media.SystemSounds.Exclamation.Play();
                    DisplayMassege(PasswordsGridView.Rows[e.RowIndex].Cells["ColName"].Value.ToString() + " Password Copied.");
                }
                else if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColUpdate")
                {
                    int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());

                    UpdatePassword updatePasswordForm = new UpdatePassword(user, user.Passwords.Where(i=>i.ID == ID).FirstOrDefault());

                    if (updatePasswordForm.ShowDialog() == DialogResult.OK)
                    {
                        user.Passwords = await PasswordsService.GetAllUserPasswordsAsync(user);
                        DisplayMassege("Password Updated.", Globals.Defaults.WarningColor);
                        ShowPasswords(user.Passwords);
                    }
                }
                else if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColDelete")
                {
                    if (Messenger.Confirm("Are you sure you want to delete this Password?\n\nTHIS TASK WILL NOT BE REVERTED."))
                    {
                        int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());

                        //this is necessary to get all passwords before deleting.
                        user.Passwords = await PasswordsService.GetAllUserPasswordsAsync(user);

                        Password passwordToDelete =  user.Passwords.Where(p => p.ID == ID).FirstOrDefault();

                        if (await PasswordsService.RemoveUserPasswordAsync(user, passwordToDelete))
                        {
                            PasswordsGridView.Rows.RemoveAt(e.RowIndex);
                            DisplayMassege("Password Deleted.", Globals.Defaults.WarningColor);
                            System.Media.SystemSounds.Hand.Play();
                        }
                        else
                        {
                            DisplayMassege("Password NOT Deleted.", Globals.Defaults.ErrorColor);
                            System.Media.SystemSounds.Exclamation.Play();
                        }
                    }
                }
            }
        }

        public void DisplayMassege(string Message)
        {
            DisplayMassege(Message, Globals.Defaults.DefaultColor);
        }

        public void DisplayMassege(string Message, Color FontColor)
        {
            lblMassege.Text = Message;
            lblMassege.ForeColor = FontColor;
        }
    }
}
