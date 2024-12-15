using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        RSA myRsa= RSA.Create();
        RSAParameters publicKey;
        RSAParameters privateKey;
        byte[] IV;
        public Form1()
        {
            InitializeComponent();
            publicKey = myRsa.ExportParameters(false);
            privateKey = myRsa.ExportParameters(true);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text;
            string encrypted = StringEncrypt(text, publicKey);
            txtCipher.Text = encrypted;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string encrypted = txtCipher.Text;
                string decrypted = StringDecrypt(encrypted, privateKey);
                txtOut.Text = decrypted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Decryption failed: {ex.Message}");
            }
        }

        public static string StringEncrypt(string plainText, RSAParameters publicKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = rsa.Encrypt(plainBytes, RSAEncryptionPadding.Pkcs1);
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string StringDecrypt(string cipherText, RSAParameters privateKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] decryptedBytes = rsa.Decrypt(cipherBytes, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
