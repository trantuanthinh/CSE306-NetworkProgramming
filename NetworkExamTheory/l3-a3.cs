using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Assignment_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void getBtn_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(urlText.Text);

                string httpRequest = $"GET {uri.AbsoluteUri} HTTP.1.0 Host:{uri.Host} Connection: Close";
                byte[] requestByte = Encoding.ASCII.GetBytes(httpRequest);
                TcpClient tcpClient = new TcpClient(uri.Host, 80);
                string content = client.GetStringAsync(uri.AbsoluteUri).Result;
                Invoke(new Action(() => textBox1.AppendText(content)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
