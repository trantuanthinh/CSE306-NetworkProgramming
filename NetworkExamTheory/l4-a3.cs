﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Assignment_3
{
    public partial class Form1 : Form
    {
        FtpWebRequest request = null;
        string ftpServer = "";
        string username = "";
        string password = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get a list of the drives
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType) // set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }
                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;
                if (di.IsReady == true)
                {
                    node.Nodes.Add("...");
                }
                treeView.Nodes.Add(node);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listBoxFilesClient.Items.Clear();
            listBoxFoldersClient.Items.Clear();
            textPathClient.Text = e.Node.Tag.ToString();
            try
            {
                string[] fileEntries = Directory.GetFiles(e.Node.Tag.ToString());

                foreach (string fileName in fileEntries)
                {
                    int temp = listBoxFilesClient.Items.Add(Path.GetFileName(fileName));
                }
                fileEntries = Directory.GetDirectories(e.Node.Tag.ToString());
                foreach (string fileName in fileEntries)
                {
                    listBoxFoldersClient.Items.Add(Path.GetFileName(fileName));
                }
            }
            catch (Exception ex) { }
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the lít ò sub dỉrectories
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());
                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }

                }
            }
        }

        private void listBoxFoldersClient_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string s = listBoxFoldersClient.SelectedItem.ToString();
            if (listBoxFoldersClient.Items.Count > 0)
            {
                string path = textPathClient.Text + "\\" + listBoxFoldersClient.SelectedItem.ToString();
                try
                {
                    listBoxFilesClient.Items.Clear();
                    listBoxFoldersClient.Items.Clear();
                    string[] fileEntries = Directory.GetFiles(path);

                    foreach (string fileName in fileEntries)
                    {
                        listBoxFilesClient.Items.Add(Path.GetFileName(fileName));
                    }

                    fileEntries = Directory.GetDirectories(path);
                    foreach (string fileName in fileEntries)
                    {
                        listBoxFoldersClient.Items.Add(Path.GetFileName(fileName));
                    }
                }
                catch (Exception ex)
                {

                }
                textPathClient.Text = path;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            ftpServer = textServer.Text;
            username = textUsername.Text;
            password = textPassword.Text;
            RefreshServerDirectory($"Log In successful!");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                string uploadUrl = $"{ftpServer}/{fileName}";

                try
                {
                    request = (FtpWebRequest)WebRequest.Create(uploadUrl);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(username, password);

                    byte[] fileContents = File.ReadAllBytes(filePath);
                    using (Stream requestStream = request.GetRequestStream())
                    using (StreamWriter writer = new StreamWriter(requestStream, Encoding.UTF8))
                    {
                        writer.Write(fileContents);
                    }

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        RefreshServerDirectory($"Upload successful!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error uploading file: {ex.Message}");
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string selectedItem = listBoxFilesServer.SelectedItem?.ToString() ?? listBoxFoldersServer.SelectedItem?.ToString();
            textPathServer.Text = selectedItem;
            bool isFile = selectedItem.Contains(".");
            if (string.IsNullOrEmpty(selectedItem) || !isFile)
            {
                MessageBox.Show("Please select a file to delete.");
                return;
            }

            string downloadUrl = $"{ftpServer}/{selectedItem}";
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = selectedItem,
                Title = "Save As"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = saveFileDialog.FileName;

                try
                {
                    // Set up the FTP request to download the file
                    request = (FtpWebRequest)WebRequest.Create(downloadUrl);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential(username, password);

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    using (Stream ftpStream = response.GetResponseStream())
                    using (FileStream localFileStream = new FileStream(localFilePath, FileMode.Create))
                    {
                        ftpStream.CopyTo(localFileStream);
                        RefreshServerDirectory("Download Successful!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error downloading file: {ex.Message}");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedItem = listBoxFilesServer.SelectedItem?.ToString() ?? listBoxFoldersServer.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Please select a file or folder to delete.");
                return;
            }

            string deleteUrl = $"{ftpServer}/{selectedItem}";

            try
            {
                bool isFile = selectedItem.Contains(".");

                request = (FtpWebRequest)WebRequest.Create(deleteUrl);
                request.Method = isFile ? WebRequestMethods.Ftp.DeleteFile : WebRequestMethods.Ftp.RemoveDirectory;
                request.Credentials = new NetworkCredential(username, password);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    RefreshServerDirectory("Delete successful!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item: {ex.Message}");
            }
        }
       
        private void btnRename_Click(object sender, EventArgs e)
        {
            
        }

        private void RefreshServerDirectory(string message)
        {
            MessageBox.Show(message);
            try
            {
                FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(ftpServer);
                listRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                listRequest.Credentials = new NetworkCredential(username, password);

                using (FtpWebResponse response = (FtpWebResponse)listRequest.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    listBoxFoldersServer.Items.Clear();
                    listBoxFilesServer.Items.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("."))
                        {
                            listBoxFilesServer.Items.Add(line);
                        }
                        else
                        {
                            listBoxFoldersServer.Items.Add(line);
                        }
                    }
                }
                if (listBoxFilesServer.SelectedItem != null)
                {
                    textPathServer.Text = $"{ftpServer}/{listBoxFilesServer.SelectedItem.ToString()}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving server directory listing: {ex.Message}");
            }
        }
    }
}