using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Assignment_5_Server
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        private int Port = 3000;

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
            
        private void listenBtn_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(serverText.Text);
            int port = int.Parse(portText.Text);
            tcpListener = new TcpListener(ipAddress, port);

            try
            {
                tcpListener.Start();
                contentText.AppendText("Waiting for a connection... \n");

                byte[] buffer = new byte[1024];
                int bytesRead = 0;

                using (TcpClient client = tcpListener.AcceptTcpClient())
                {
                    while (true)
                    {
                        contentText.AppendText("Client Connected. \n");
                        NetworkStream networkStream = client.GetStream();
                        bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0) {
                            break;
                        }
                        string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        contentText.AppendText(receivedData);
                    }
                }
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
    }
}
