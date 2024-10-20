using System;
using System.Threading;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"D:\CSE306-NetworkProgramming\Lab2";
                    openFileDialog.Filter = "Images (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
                    openFileDialog.Multiselect = true;
                    openFileDialog.Title = "Select Files to Upload";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string[] selectedFiles = openFileDialog.FileNames;
                        foreach (var item in selectedFiles)
                        {
                            uploadList.Items.Add(item);
                        }
                        int totalFiles = selectedFiles.Length;
                        int uploadedFiles = 0;
                        object lockObj = new object();

                        foreach (string file in selectedFiles)
                        {
                            Thread uploadThread = new Thread(() => Upload(file, lockObj, totalFiles, ref uploadedFiles));
                            uploadThread.IsBackground = true; 
                            uploadThread.Start();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Upload(string file, object lockObj, int totalFiles, ref int uploadedFiles)
        {
            try
            {
                int uploadTime = random.Next(2000, 5000);
                Invoke(new Action(() =>
                {
                    statusList.Items.Add($"Uploading...: {file}");
                })); 
                
                Thread.Sleep(uploadTime); 

                Invoke(new Action(() =>
                {
                    statusList.Items.Add($"Successfully uploaded: {file}");
                }));

                lock (lockObj)
                {
                    uploadedFiles++;
                    if (uploadedFiles == totalFiles)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("All files uploaded successfully.", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show($"Failed to upload file: {file}\nError: {ex.Message}", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }
    }
}
