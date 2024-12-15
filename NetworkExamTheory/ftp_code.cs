using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Manager
{
    public partial class Form1 : Form
    {
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

                switch (di.DriveType)    //set the drive's icon
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
                    node.Nodes.Add("...");

                treeView.Nodes.Add(node);
            }

        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
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


        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listBoxFiles.Items.Clear();
            listBoxFolders.Items.Clear();
            txtPathClient.Text = e.Node.Tag.ToString();
            try
            {
                string[] fileEntries = Directory.GetFiles(e.Node.Tag.ToString());

                foreach (string fileName in fileEntries)
                {
                    int _temp = listBoxFiles.Items.Add(Path.GetFileName(fileName));
                }
                fileEntries = Directory.GetDirectories(e.Node.Tag.ToString());                
                foreach (string fileName in fileEntries)
                    listBoxFolders.Items.Add(Path.GetFileName(fileName));
            } catch { }
        }
 
     
        private void listBoxFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string s = listBoxFolders.SelectedItem.ToString();
            if (listBoxFolders.Items.Count > 0)
            {
                string _path = txtPathClient.Text + "\\" + listBoxFolders.SelectedItem.ToString();
                try
                {
                    listBoxFiles.Items.Clear();
                    listBoxFolders.Items.Clear();
                    string[] fileEntries = Directory.GetFiles(_path);

                    foreach (string fileName in fileEntries)
                        listBoxFiles.Items.Add(Path.GetFileName(fileName));

                    fileEntries = Directory.GetDirectories(_path);
                    foreach (string fileName in fileEntries)
                        listBoxFolders.Items.Add(Path.GetFileName(fileName));
                }
                catch { }
                txtPathClient.Text = _path;
            }
        }
    }
    
}
