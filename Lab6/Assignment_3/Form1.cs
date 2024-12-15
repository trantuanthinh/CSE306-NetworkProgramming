using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Assignment_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            string hashedPassword = ComputeSHA256Hash(pass);
            listBox1.Items.Add(hashedPassword);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string hashedKey = ComputeSHA256Hash(key);
            bool found = listBox1.Items.Cast<string>().Any(item => item == hashedKey);
            listBox1.Items.Clear();
            if (found)
            {
                listBox1.Items.Add(hashedKey);
            }
        }

        private string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
