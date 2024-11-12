using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        private string[] Emails; 

        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseList_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtEmailTo.Text = openFileDialog.FileName;
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pdf (*.pdf)|*.pdf|All files(*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string filePath = txtEmailTo.Text;
            if (File.Exists(filePath))
            {
                Emails = File.ReadAllLines(filePath);
            }

            string username = txtUsername.Text;
            string appPassword = txtPassword.Text;
            string host = txtGmail.Text;
            int port = int.Parse(txtPort.Text);

            NetworkCredential networkCredential = new NetworkCredential(username, appPassword);
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = networkCredential
                };

                MailAddress from = new MailAddress(txtEmailFrom.Text, "Mail Test");
                MailMessage message = new MailMessage
                {
                    From = from,
                    Subject = txtTitle.Text,
                    Body = txtMessage.Text,
                };

                foreach (string email in Emails)
                {
                    message.To.Add(new MailAddress(email));
                }

                if (!string.IsNullOrWhiteSpace(txtFile.Text) && File.Exists(txtFile.Text))
                {
                    message.Attachments.Add(new Attachment(txtFile.Text));
                }

                await client.SendMailAsync(message);
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
