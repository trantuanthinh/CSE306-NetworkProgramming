using System;
using System.IO.Compression;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                    txtFolder.Text = selectedFolderPath;
                }
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "ZIP Files (*.zip)|*.zip";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string zipFilePath = saveFileDialog.FileName;
                    ZipFile.CreateFromDirectory(txtFolder.Text, zipFilePath);
                    MessageBox.Show("Success");
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select Folder";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = folderBrowserDialog.SelectedPath;
                    ZipFile.ExtractToDirectory(txtZip.Text, destinationPath);
                    MessageBox.Show("Success");
                }
            }
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ZIP Files (*.zip)|*.zip";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtZip.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
