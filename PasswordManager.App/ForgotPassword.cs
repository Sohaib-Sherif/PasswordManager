using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Services;
using PasswordManager.Entities;
using PasswordManager.DAO;

namespace PasswordManager.App
{
	public partial class ForgotPassword : Form
	{
		public ForgotPassword()
		{
			InitializeComponent();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			User user = UserDAO.GetRegisteredUser(EmailBox.Text);
			MailMessage message = new MailMessage("validation96@gmail.com", EmailBox.Text);
			message.Subject = "كلمة السر خاصتك";
			message.Body = "كلمة السر خاصتك هي: "+user.Master;
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl = true;
			client.Credentials = new System.Net.NetworkCredential("validation96@gmail.com", "hgjH;d]123");
			try
			{
				client.Send(message);
				successlbl.Text = "تم إرسال كلمة السر";

			}
			catch (Exception ex)
			{
				MessageBox.Show("فشلت عملية إعادة الإرسال\n\r" + ex.Message + ex.GetBaseException());
			}
		}
	}
}
