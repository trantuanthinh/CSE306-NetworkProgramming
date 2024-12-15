using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class Form1 : Form
    {
        private HttpListener httpListener;
        private WebSocket webSocket;
        private string ipAddress;
        private int port;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            ipAddress = textIp.Text;
            port = int.Parse(textPort.Text);
            httpListener = new HttpListener();
            httpListener.Prefixes.Add($"http://{ipAddress}:{port}/");

            try
            {
                httpListener.Start();
                textList.AppendText("Waiting for connection... \r\n");
                ListenClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private async void ListenClient()
        {
            while (httpListener.IsListening)
            {
                try
                {
                    var context = await httpListener.GetContextAsync();
                    if (context.Request.IsWebSocketRequest)
                    {
                        await HandleWebSocketConnection(context);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
            }
        }

        private async Task HandleWebSocketConnection(HttpListenerContext context)
        {
            var webSocketContext = await context.AcceptWebSocketAsync(null);
            webSocket = webSocketContext.WebSocket;
            textList.AppendText("Client connected.\r\n");

            var receiveBuffer = new byte[1024];
            while (webSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                        textList.Invoke((Action)(() => textList.AppendText("Client: " + receivedMessage + "\r\n")));
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                        textList.AppendText("Client disconnected.\r\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error receiving data: " + ex.Message);
                    break;
                }
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (webSocket == null || webSocket.State != WebSocketState.Open)
            {
                MessageBox.Show("No active WebSocket connection.");
                return;
            }

            string message = textMessage.Text;
            byte[] data = Encoding.UTF8.GetBytes(message);

            try
            {
                await webSocket.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Text, true, CancellationToken.None);
                textList.AppendText("Server: " + message + "\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception while sending message: " + ex.Message);
            }
        }
    }
}
