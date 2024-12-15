using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class Form1 : Form
    {
        static IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        static int port = 3000;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg",
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textText.Text = openFileDialog.FileName;
                byte[] fileContent = File.ReadAllBytes(openFileDialog.FileName);

                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(ipAddress, port);

                        using (NetworkStream stream = tcpClient.GetStream())
                        {
                            stream.Write(fileContent, 0, fileContent.Length);
                        }
                    }

                    MessageBox.Show("File sent successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
