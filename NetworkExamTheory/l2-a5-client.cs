using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Assignment_5_Client
{
    public partial class Form1 : Form
    {
        private TcpClient tcpClient = null;
        private NetworkStream stream = null;
        private bool isListenServer = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(serverText.Text);
            int port = int.Parse(portText.Text);
            tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect(ipAddress, port);
                Thread listenThread = new Thread(ListenServer);
                listenThread.IsBackground = true;
                listenThread.Start();
                contentText.AppendText("Connected to server. \r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string messageToSend = textText.Text;

            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(messageToSend);
                stream.Write(buffer, 0, buffer.Length);
                MessageBox.Show("Message sent to server. \r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ListenServer()
        {
            isListenServer = true;
            stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            while (isListenServer)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;

                    string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    contentText.Invoke(
                        new Action(() =>
                        {
                            contentText.AppendText("Server: " + received + "\r\n");
                        })
                    );
                }
                catch (Exception ex)
                {
                    if (true)
                    {
                        Invoke(new Action(() => MessageBox.Show("Error: " + ex.Message)));
                    }
                    break;
                }
            }
        }
    }
}
