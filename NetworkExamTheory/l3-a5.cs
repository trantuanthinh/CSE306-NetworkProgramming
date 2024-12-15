using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace Assignment_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void downloadBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileUrl = textBox1.Text;

                        using (WebClient webClient = new WebClient())
                        {
                            string fileName = Path.GetFileName(fileUrl);
                            string filePath = Path.Combine(folderBrowserDialog.SelectedPath, fileName);
                            webClient.DownloadFile(fileUrl, filePath);
                            MessageBox.Show("File downloaded successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
