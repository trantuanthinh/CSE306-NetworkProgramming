﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Executable files (*.dic)|*.dic|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;

                byte[] fileBytes = File.ReadAllBytes(ofd.FileName);
                txtsha1.Text = ComputeSHA1Hash(fileBytes);
                txtmd5.Text = ComputeMD5Hash(fileBytes);
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string providedHash = txtCompare.Text.Trim(); 
            string computedHashSHA1 = txtsha1.Text.Trim();
            string computedHashMD5 = txtmd5.Text.Trim();

            if (providedHash.Equals(computedHashSHA1, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("SHA1 hash matches!", "Integrity Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (providedHash.Equals(computedHashMD5, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("MD5 hash matches!", "Integrity Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No matching hash found!", "Integrity Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ComputeSHA1Hash(byte[] fileBytes)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(fileBytes);
                return ConvertToHexString(hashBytes);
            }
        }

        private string ComputeMD5Hash(byte[] fileBytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(fileBytes);
                return ConvertToHexString(hashBytes);
            }
        }

        private string ConvertToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2")); 
            }
            return sb.ToString();
        }
    }
}
