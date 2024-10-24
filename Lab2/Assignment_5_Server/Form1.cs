using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Assignment_5_Server
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        private TcpClient connectedClient = null;
        private NetworkStream clientStream = null;
        private bool isListening = true;

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
                isListening = true;
                contentText.AppendText("Waiting for a connection... \r\n");

                Thread listenThread = new Thread(ListenClient);
                listenThread.IsBackground = true;
                listenThread.Start();
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

        private void ListenClient()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            while (isListening)
            {
                try
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    connectedClient = client; 
                    clientStream = client.GetStream();
                    contentText.Invoke(new Action(() =>
                    {
                        contentText.AppendText("Client Connected. \r\n");
                    }));

                    NetworkStream stream = client.GetStream();
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        contentText.Invoke(new Action(() =>
                        {
                            contentText.AppendText("Client: " + received + "\r\n");
                        }));
                    }
                }
                catch (Exception e)
                {
                    if (isListening)
                    {
                        Invoke(new Action(() => MessageBox.Show("Error: " + e.Message)));
                    }
                }
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string messageToSend = textText.Text;

            if (connectedClient != null && connectedClient.Connected && clientStream != null)
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(messageToSend);
                    clientStream.Write(buffer, 0, buffer.Length);
                    contentText.AppendText("Message sent to client: " + messageToSend + "\r\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message to client: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No client connected.");
            }
        }
    }
}
