using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        Aes myAes = Aes.Create();
        byte[] Key;
        byte[] IV;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string text = txtPlain.Text;
            Key = myAes.Key;
            IV = myAes.IV;
            byte[] encrypted = StringEncrypt(text, Key, IV);
            txtEncrypt.Text = Encoding.Unicode.GetString(encrypted); 
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] encrypted = Encoding.Unicode.GetBytes(txtEncrypt.Text);
                string decrypted = StringDecrypt(encrypted, Key, IV);
                txtDecrypt.Text = decrypted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Decryption failed: {ex.Message}");
            }
        }

        private byte[] StringEncrypt(string text, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return encrypted;
        }

        private string StringDecrypt(byte[] cipher, byte[] Key, byte[] IV)
        {
            string decrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipher))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return decrypted;
        }
    }
}
