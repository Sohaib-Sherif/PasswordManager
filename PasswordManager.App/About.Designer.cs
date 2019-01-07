namespace PasswordManager.App
{
    partial class About
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.panel1 = new System.Windows.Forms.Panel();
			this.TitlePanel = new System.Windows.Forms.Panel();
			this.lblFormTitle = new System.Windows.Forms.Label();
			this.TitlePictureBox = new System.Windows.Forms.PictureBox();
			this.lblAppMotto = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblDetails1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblDetails2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.TitlePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.panel1.Controls.Add(this.TitlePanel);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.lblDetails1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(584, 641);
			this.panel1.TabIndex = 0;
			// 
			// TitlePanel
			// 
			this.TitlePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.TitlePanel.Controls.Add(this.lblFormTitle);
			this.TitlePanel.Controls.Add(this.TitlePictureBox);
			this.TitlePanel.Controls.Add(this.lblAppMotto);
			this.TitlePanel.Cursor = System.Windows.Forms.Cursors.Cross;
			this.TitlePanel.Location = new System.Drawing.Point(150, 2);
			this.TitlePanel.Name = "TitlePanel";
			this.TitlePanel.Size = new System.Drawing.Size(321, 70);
			this.TitlePanel.TabIndex = 12;
			// 
			// lblFormTitle
			// 
			this.lblFormTitle.AutoSize = true;
			this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
			this.lblFormTitle.Location = new System.Drawing.Point(63, 8);
			this.lblFormTitle.Name = "lblFormTitle";
			this.lblFormTitle.Size = new System.Drawing.Size(185, 32);
			this.lblFormTitle.TabIndex = 11;
			this.lblFormTitle.Text = "About BearPass";
			// 
			// TitlePictureBox
			// 
			this.TitlePictureBox.Image = global::PasswordManager.App.Properties.Resources.flag_bear;
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
			this.lblAppMotto.Size = new System.Drawing.Size(247, 17);
			this.lblAppMotto.TabIndex = 9;
			this.lblAppMotto.Text = "BearPass - Personal Password Manager";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Transparent;
			this.panel3.Location = new System.Drawing.Point(13, 80);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(258, 436);
			this.panel3.TabIndex = 17;
			// 
			// lblDetails1
			// 
			this.lblDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDetails1.BackColor = System.Drawing.Color.Transparent;
			this.lblDetails1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblDetails1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDetails1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDetails1.Location = new System.Drawing.Point(278, 77);
			this.lblDetails1.Name = "lblDetails1";
			this.lblDetails1.Size = new System.Drawing.Size(296, 276);
			this.lblDetails1.TabIndex = 16;
			this.lblDetails1.Text = " ";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.panel2.Controls.Add(this.lblDetails2);
			this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.panel2.Location = new System.Drawing.Point(0, 356);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(584, 285);
			this.panel2.TabIndex = 0;
			// 
			// lblDetails2
			// 
			this.lblDetails2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDetails2.BackColor = System.Drawing.Color.Transparent;
			this.lblDetails2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblDetails2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDetails2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDetails2.Location = new System.Drawing.Point(279, 10);
			this.lblDetails2.Name = "lblDetails2";
			this.lblDetails2.Size = new System.Drawing.Size(295, 250);
			this.lblDetails2.TabIndex = 17;
			this.lblDetails2.Text = " ";
			// 
			// About
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(584, 641);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 700);
			this.Name = "About";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.Load += new System.EventHandler(this.About_Load);
			this.panel1.ResumeLayout(false);
			this.TitlePanel.ResumeLayout(false);
			this.TitlePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDetails1;
        private System.Windows.Forms.Label lblDetails2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox TitlePictureBox;
        private System.Windows.Forms.Label lblAppMotto;
    }
}