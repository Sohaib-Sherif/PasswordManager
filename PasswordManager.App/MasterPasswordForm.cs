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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.App
{
    public partial class MasterPasswordForm : Form
    {
        public User user;

        public MasterPasswordForm(User user)
        {
            InitializeComponent();

            this.user = user;

            lblMasterNote.Text = Globals.Information.MasterPasswordNote;
            lblMasterNote.ForeColor = Color.FromArgb(255, 214, 0);

            picboxLoading.Hide();
        }

        private void MasterPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void chkShowMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtMaster.UseSystemPasswordChar = chkHideMaster.Checked;
        }

        private void chkShowNewMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtNewMaster.UseSystemPasswordChar = chkHideNewMaster.Checked;
        }

        private void chkShowConfirmMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmMaster.UseSystemPasswordChar = chkHideConfirmMaster.Checked;
        }
        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //check if the newly supplied passwords are same or not
                if (!PasswordsService.IsSame(txtNewMaster.Text, txtConfirmMaster.Text) && !Verify.Text(txtNewMaster.Text) && !Verify.Text(txtConfirmMaster.Text))
                {
                    lblMassege.Text = "حقل كلمة السر الرئيسية و حقل تأكيد كلمة السر الرئيسية غير متطابقان";
                    lblMassege.ForeColor = Color.FromArgb(244, 67, 54);

                }
                else //both new passwords are same. Dont match them again
                {
                    //match the current Master Password with the entered Master Password
                    if (Verify.Text(txtMaster.Text) && PasswordsService.IsSame(user.Master, txtMaster.Text))
                    {
                        if (MessageBox.Show("هل أنت متأكد أنك ترغب في تغيير كلمة السر الرئيسية؟", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                         {
                            picboxLoading.Show();
                            btnSave.Enabled = false;

                            //do some refactoring here like null etc exc -gul:1401171353
                            user = await PasswordsService.ChangeMasterEncryption(user, txtNewMaster.Text);

                            picboxLoading.Hide();
                            btnSave.Enabled = true;
                            lblMassege.Text = "تم تغيير كلمة السر الرئيسية";
                            lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
                        }
                    }
                    else //user entered a wrong master password
                    {
                        lblMassege.Text = "كلمة السر الرئيسية غير صحيحة";
                        lblMassege.ForeColor = Color.FromArgb(244, 67, 54);
                    }
                }
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
                picboxLoading.Hide();
                btnSave.Enabled = true;
            }
        }
		//TextChanged listener for the text boxes
        private void CheckSaveEnable(object sender, EventArgs e)
        {
            btnSave.Enabled = IsEnable();
        }

        private bool IsEnable()
        {
            if (PasswordsService.IsSame(txtNewMaster.Text, txtConfirmMaster.Text) && Verify.Text(txtNewMaster.Text) && Verify.Text(txtConfirmMaster.Text))
            {
                //now check if existing master match too
                if (Verify.Text(txtMaster.Text) && PasswordsService.IsSame(user.Master, txtMaster.Text))
                {
                    lblMassege.Text = "يمكنك أن تحفظ الأن.";
                    lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
                    return true;
                }//maybe I should check if new master is same as old master --soh
                else
                {
                    lblMassege.Text = "كلمة السر الرئيسية غير صحيحة";
                    lblMassege.ForeColor = Color.FromArgb(244, 67, 54);
                    return false;
                }
            }
            else
            {
                lblMassege.Text = "حقل كلمة السر الرئيسية الجديدة و حقل تأكيد كلمة السر الرئيسية غير متطابقان";
                lblMassege.ForeColor = Color.FromArgb(244, 67, 54);
                return false;
            }
        }
    }
}
