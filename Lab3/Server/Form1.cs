using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
        TcpClient tcpClient;
        NetworkStream stream;
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 3000;

        public Form1()
        {
            InitializeComponent();
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(serverText.Text);
            int port = int.Parse(portText.Text);
            tcpListener = new TcpListener(ipAddress, port);
            try
            {
                tcpListener.Start();
                contentText.AppendText("Waiting for a connection... \r\n");

                Thread listenThread = new Thread(ListenClient);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }
        }

        private void ListenClient()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            while (true)
            {
                try
                {
                    string directoryPath = @"D:\CSE306-NetworkProgramming\Lab3\Server";
                    DateTime now = DateTime.Now;
                    string formattedDateTime = now.ToString("yyyyMMdd-HHmmss");
                    string fileName = $"{formattedDateTime}.jpg";
                    string filePath = Path.Combine(directoryPath, fileName);

                    tcpClient = tcpListener.AcceptTcpClient();
                    stream = tcpClient.GetStream();
                    contentText.Invoke(
                        new Action(() =>
                        {
                            contentText.AppendText("Client Connected. \r\n");
                        })
                    );

                    byte[] fileContent = new byte[1024 * 4];
                    string received = "";
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        received = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }

                    DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                    File.WriteAllText(filePath, received);

                    contentText.Invoke(
                        new Action(() =>
                        {
                            contentText.AppendText("Received Image: " + fileName);
                        })
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: ", ex.Message);
                }
            }
        }
    }
}
