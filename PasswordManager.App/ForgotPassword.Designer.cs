namespace PasswordManager.App
{
	partial class ForgotPassword
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnSend = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblMassege = new System.Windows.Forms.Label();
			this.EmailBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.successlbl = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(518, 321);
			this.panel1.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.successlbl);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.EmailBox);
			this.panel3.Controls.Add(this.btnSend);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(60, 76);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(400, 192);
			this.panel3.TabIndex = 1;
			// 
			// btnSend
			// 
			this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
			this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSend.FlatAppearance.BorderSize = 0;
			this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSend.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSend.ForeColor = System.Drawing.Color.White;
			this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSend.Location = new System.Drawing.Point(185, 136);
			this.btnSend.Name = "btnSend";
			this.btnSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnSend.Size = new System.Drawing.Size(65, 42);
			this.btnSend.TabIndex = 25;
			this.btnSend.Text = "إرسال";
			this.btnSend.UseVisualStyleBackColor = false;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(117, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "إرسال كلمة المرور";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.panel2.Controls.Add(this.lblMassege);
			this.panel2.Location = new System.Drawing.Point(0, 122);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(518, 199);
			this.panel2.TabIndex = 0;
			// 
			// lblMassege
			// 
			this.lblMassege.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblMassege.Image = ((System.Drawing.Image)(resources.GetObject("lblMassege.Image")));
			this.lblMassege.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMassege.Location = new System.Drawing.Point(0, 135);
			this.lblMassege.Name = "lblMassege";
			this.lblMassege.Size = new System.Drawing.Size(518, 64);
			this.lblMassege.TabIndex = 15;
			this.lblMassege.Text = " ";
			this.lblMassege.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EmailBox
			// 
			this.EmailBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
			this.EmailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EmailBox.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.EmailBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.EmailBox.Location = new System.Drawing.Point(25, 87);
			this.EmailBox.Name = "EmailBox";
			this.EmailBox.Size = new System.Drawing.Size(225, 29);
			this.EmailBox.TabIndex = 26;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
			this.label2.Location = new System.Drawing.Point(268, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 21);
			this.label2.TabIndex = 27;
			this.label2.Text = "البريد الإلكتروني :";
			// 
			// successlbl
			// 
			this.successlbl.AutoSize = true;
			this.successlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
			this.successlbl.Location = new System.Drawing.Point(40, 152);
			this.successlbl.Name = "successlbl";
			this.successlbl.Size = new System.Drawing.Size(0, 13);
			this.successlbl.TabIndex = 28;
			// 
			// ForgotPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 321);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ForgotPassword";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.Text = "ForgotPassword";
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblMassege;
		private System.Windows.Forms.TextBox EmailBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label successlbl;
	}
}