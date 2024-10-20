using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Assignment_5_Client
{
    public partial class Form1 : Form
    {
        private TcpClient tcpClient = null;
        private NetworkStream stream = null;

        public Form1()
        {
            InitializeComponent();
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);
            string ipv4Address = string.Empty;
            foreach (IPAddress ip in ipAddresses)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipv4Address = ip.ToString();
                    break;
                }
            }
            this.serverText.Text = ipv4Address;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(serverText.Text);
            int port = int.Parse(portText.Text);
            tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect(ipAddress, port);
                stream = tcpClient.GetStream();
                contentText.AppendText("Connected to server. \n");
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
            if (string.IsNullOrWhiteSpace(messageToSend))
            {
                MessageBox.Show("Please enter a message to send.");
                return;
            }

            try
            {
                if (tcpClient != null && tcpClient.Connected)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(messageToSend);
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                    stream.Close();
                    tcpClient.Close();
                    MessageBox.Show("Message sent to server.");
                }
                else
                {
                    MessageBox.Show("Not connected to a server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
