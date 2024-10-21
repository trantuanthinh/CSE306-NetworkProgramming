using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        int numberofFiles = 0;
        Thread[] threadArray;

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
                        numberofFiles = selectedFiles.Length;
                        threadArray = new Thread[numberofFiles];
                        for (int i = 0; i < numberofFiles; i++)
                        {
                            uploadList.Items.Add(selectedFiles[i]);
                            threadArray[i] = new Thread(Upload);
                            threadArray[i].Start(selectedFiles[i]);
                        }

                        Thread finalThread = new Thread(JoinAllThread);
                        finalThread.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Upload(object _filePath)
        {
            string filePath = (string)_filePath;
            string fileName = Path.GetFileName(filePath);
            try
            {
                int uploadTime = random.Next(2000, 5000);
                Invoke(new Action(() =>
                {
                    statusList.Items.Add($"Uploading...: {fileName}");
                }));

                Thread.Sleep(uploadTime);

                Invoke(new Action(() =>
                {
                    statusList.Items.Add($"Successfully uploaded: {fileName}");
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show($"Failed to upload file: {fileName}\nError: {ex.Message}", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void JoinAllThread(object _filePath)
        {
            for (int i = 0; i < numberofFiles; i++)
            {
                threadArray[i].Join();
            }
            Invoke(new Action(() =>
            {
                MessageBox.Show("All files uploaded successfully.", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }
    }
}
