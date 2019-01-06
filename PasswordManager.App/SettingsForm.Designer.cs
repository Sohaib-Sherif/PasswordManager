namespace PasswordManager.App
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnChangeMaster = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbDateFormat = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.chkDisplayPassword = new System.Windows.Forms.CheckBox();
			this.chkDisplayUsername = new System.Windows.Forms.CheckBox();
			this.chkDisplayEmail = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnPasswordOptions = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TitlePanel = new System.Windows.Forms.Panel();
			this.lblFormTitle = new System.Windows.Forms.Label();
			this.TitlePictureBox = new System.Windows.Forms.PictureBox();
			this.lblAppMotto = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.TitlePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoSize = true;
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.panel2.Controls.Add(this.btnChangeMaster);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.cmbDateFormat);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.chkDisplayPassword);
			this.panel2.Controls.Add(this.chkDisplayUsername);
			this.panel2.Controls.Add(this.chkDisplayEmail);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Controls.Add(this.btnPasswordOptions);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.panel2.Location = new System.Drawing.Point(0, 194);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(484, 282);
			this.panel2.TabIndex = 60;
			// 
			// btnChangeMaster
			// 
			this.btnChangeMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.btnChangeMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnChangeMaster.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnChangeMaster.FlatAppearance.BorderSize = 0;
			this.btnChangeMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnChangeMaster.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChangeMaster.ForeColor = System.Drawing.Color.White;
			this.btnChangeMaster.Image = global::PasswordManager.App.Properties.Resources.password_master_save_40;
			this.btnChangeMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnChangeMaster.Location = new System.Drawing.Point(95, 134);
			this.btnChangeMaster.Name = "btnChangeMaster";
			this.btnChangeMaster.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btnChangeMaster.Size = new System.Drawing.Size(227, 42);
			this.btnChangeMaster.TabIndex = 35;
			this.btnChangeMaster.Text = "تغيير كلمة السر الرئيسية";
			this.btnChangeMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChangeMaster.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnChangeMaster.UseVisualStyleBackColor = false;
			this.btnChangeMaster.Click += new System.EventHandler(this.btnChangeMaster_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(329, 190);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(126, 21);
			this.label8.TabIndex = 34;
			this.label8.Text = "خيارات كلمة السر :";
			// 
			// cmbDateFormat
			// 
			this.cmbDateFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
			this.cmbDateFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.cmbDateFormat.FormattingEnabled = true;
			this.cmbDateFormat.Items.AddRange(new object[] {
            "2/27/2000",
            "Friday, February 27, 2000",
            "Friday, February 27, 2000 12:11 PM",
            "Friday, February 27, 2000 12:12:22 PM",
            "2/27/2000 12:12 PM",
            "2/27/2000 12:12:22 PM",
            "2000-02-27T12:12:22",
            "2000-02-27 12:12:22Z"});
			this.cmbDateFormat.Location = new System.Drawing.Point(98, 7);
			this.cmbDateFormat.Name = "cmbDateFormat";
			this.cmbDateFormat.Size = new System.Drawing.Size(225, 29);
			this.cmbDateFormat.TabIndex = 33;
			this.cmbDateFormat.SelectedIndexChanged += new System.EventHandler(this.cmbDateFormat_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(335, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(99, 21);
			this.label6.TabIndex = 30;
			this.label6.Text = "صيغة التاريخ :";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(328, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(134, 21);
			this.label7.TabIndex = 29;
			this.label7.Text = "كلمة السر الرئيسية :";
			// 
			// chkDisplayPassword
			// 
			this.chkDisplayPassword.AutoSize = true;
			this.chkDisplayPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDisplayPassword.Location = new System.Drawing.Point(204, 103);
			this.chkDisplayPassword.Name = "chkDisplayPassword";
			this.chkDisplayPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkDisplayPassword.Size = new System.Drawing.Size(128, 25);
			this.chkDisplayPassword.TabIndex = 26;
			this.chkDisplayPassword.Text = "عرض كلمة السر";
			this.chkDisplayPassword.UseVisualStyleBackColor = true;
			this.chkDisplayPassword.CheckedChanged += new System.EventHandler(this.chkDisplayPassword_CheckedChanged);
			// 
			// chkDisplayUsername
			// 
			this.chkDisplayUsername.AutoSize = true;
			this.chkDisplayUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDisplayUsername.Location = new System.Drawing.Point(174, 73);
			this.chkDisplayUsername.Name = "chkDisplayUsername";
			this.chkDisplayUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkDisplayUsername.Size = new System.Drawing.Size(158, 25);
			this.chkDisplayUsername.TabIndex = 25;
			this.chkDisplayUsername.Text = "عرض إسم المستخدم";
			this.chkDisplayUsername.UseVisualStyleBackColor = true;
			this.chkDisplayUsername.CheckedChanged += new System.EventHandler(this.chkDisplayUsername_CheckedChanged);
			// 
			// chkDisplayEmail
			// 
			this.chkDisplayEmail.AutoSize = true;
			this.chkDisplayEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDisplayEmail.Location = new System.Drawing.Point(164, 42);
			this.chkDisplayEmail.Name = "chkDisplayEmail";
			this.chkDisplayEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkDisplayEmail.Size = new System.Drawing.Size(168, 25);
			this.chkDisplayEmail.TabIndex = 24;
			this.chkDisplayEmail.Text = "عرض البريد الإلكتروني";
			this.chkDisplayEmail.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.chkDisplayEmail.UseVisualStyleBackColor = true;
			this.chkDisplayEmail.CheckedChanged += new System.EventHandler(this.chkDisplayEmail_CheckedChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
			this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatAppearance.BorderSize = 0;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.ForeColor = System.Drawing.Color.White;
			this.btnCancel.Image = global::PasswordManager.App.Properties.Resources.settings_cancel_40;
			this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new System.Drawing.Point(162, 225);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(110, 42);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "إلغاء";
			this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnCancel.UseVisualStyleBackColor = false;
			// 
			// btnPasswordOptions
			// 
			this.btnPasswordOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.btnPasswordOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnPasswordOptions.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPasswordOptions.FlatAppearance.BorderSize = 0;
			this.btnPasswordOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPasswordOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPasswordOptions.ForeColor = System.Drawing.Color.White;
			this.btnPasswordOptions.Image = global::PasswordManager.App.Properties.Resources.password_options;
			this.btnPasswordOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPasswordOptions.Location = new System.Drawing.Point(95, 180);
			this.btnPasswordOptions.Name = "btnPasswordOptions";
			this.btnPasswordOptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btnPasswordOptions.Size = new System.Drawing.Size(227, 42);
			this.btnPasswordOptions.TabIndex = 9;
			this.btnPasswordOptions.Text = "خيارات تكوين كلمة السر";
			this.btnPasswordOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPasswordOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnPasswordOptions.UseVisualStyleBackColor = false;
			this.btnPasswordOptions.Click += new System.EventHandler(this.btnPasswordOptions_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(335, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 21);
			this.label4.TabIndex = 22;
			this.label4.Text = "العرض :";
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
			this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.FlatAppearance.BorderSize = 0;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.ForeColor = System.Drawing.Color.White;
			this.btnSave.Image = global::PasswordManager.App.Properties.Resources.settings_save_40;
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.Location = new System.Drawing.Point(278, 225);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(110, 42);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "حفظ";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.panel1.Controls.Add(this.txtUsername);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtEmail);
			this.panel1.Controls.Add(this.txtName);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.TitlePanel);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(484, 461);
			this.panel1.TabIndex = 51;
			// 
			// txtUsername
			// 
			this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
			this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.txtUsername.Location = new System.Drawing.Point(104, 142);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(225, 29);
			this.txtUsername.TabIndex = 3;
			this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(335, 144);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 21);
			this.label1.TabIndex = 16;
			this.label1.Text = "إسم المستخدم :";
			// 
			// txtEmail
			// 
			this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
			this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.txtEmail.Location = new System.Drawing.Point(103, 108);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(225, 29);
			this.txtEmail.TabIndex = 2;
			this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
			// 
			// txtName
			// 
			this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
			this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.txtName.Location = new System.Drawing.Point(103, 73);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(225, 29);
			this.txtName.TabIndex = 1;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(335, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 21);
			this.label3.TabIndex = 13;
			this.label3.Text = "البريد الإلكتروني :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(335, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 21);
			this.label2.TabIndex = 12;
			this.label2.Text = "الإسم :";
			// 
			// TitlePanel
			// 
			this.TitlePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.TitlePanel.Controls.Add(this.lblFormTitle);
			this.TitlePanel.Controls.Add(this.TitlePictureBox);
			this.TitlePanel.Controls.Add(this.lblAppMotto);
			this.TitlePanel.Cursor = System.Windows.Forms.Cursors.Cross;
			this.TitlePanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.TitlePanel.Location = new System.Drawing.Point(95, 2);
			this.TitlePanel.Name = "TitlePanel";
			this.TitlePanel.Size = new System.Drawing.Size(321, 70);
			this.TitlePanel.TabIndex = 77;
			// 
			// lblFormTitle
			// 
			this.lblFormTitle.AutoSize = true;
			this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
			this.lblFormTitle.Location = new System.Drawing.Point(120, 5);
			this.lblFormTitle.Name = "lblFormTitle";
			this.lblFormTitle.Size = new System.Drawing.Size(107, 32);
			this.lblFormTitle.TabIndex = 34;
			this.lblFormTitle.Text = "الإعدادات";
			this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// TitlePictureBox
			// 
			this.TitlePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("TitlePictureBox.Image")));
			this.TitlePictureBox.Location = new System.Drawing.Point(3, 5);
			this.TitlePictureBox.Name = "TitlePictureBox";
			this.TitlePictureBox.Size = new System.Drawing.Size(60, 60);
			this.TitlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.TitlePictureBox.TabIndex = 10;
			this.TitlePictureBox.TabStop = false;
			// 
			// lblAppMotto
			// 
			this.lblAppMotto.AutoSize = true;
			this.lblAppMotto.Cursor = System.Windows.Forms.Cursors.Cross;
			this.lblAppMotto.Location = new System.Drawing.Point(67, 38);
			this.lblAppMotto.Name = "lblAppMotto";
			this.lblAppMotto.Size = new System.Drawing.Size(236, 17);
			this.lblAppMotto.TabIndex = 89;
			this.lblAppMotto.Text = "Celeste - Personal Password Manager";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 476);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(500, 515);
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "SettingsForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "الإعدادات";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.TitlePanel.ResumeLayout(false);
			this.TitlePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPasswordOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox TitlePictureBox;
        private System.Windows.Forms.Label lblAppMotto;
        private System.Windows.Forms.CheckBox chkDisplayPassword;
        private System.Windows.Forms.CheckBox chkDisplayUsername;
        private System.Windows.Forms.CheckBox chkDisplayEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDateFormat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChangeMaster;
    }
}