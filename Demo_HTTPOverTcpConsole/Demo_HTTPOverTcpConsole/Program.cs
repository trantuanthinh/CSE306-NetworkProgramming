using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace Demo_HTTPOverTcpConsole
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            #region
            Uri uri = new Uri("http://example.com");
            //string httpRequest = $"GET {uri.AbsolutePath} HTTP/1.0\r\nHost: {uri.Host}\r\nConnection: Close\r\n\r\n";
            //byte[] requestBytes = Encoding.ASCII.GetBytes(httpRequest);

            //using (TcpClient tcpClient = new TcpClient(uri.Host, 80))
            //using (NetworkStream stream = tcpClient.GetStream())
            //{
            //    stream.Write(requestBytes, 0, requestBytes.Length);

            //    byte[] buffer = new byte[4096];
            //    int bytesRead;
            //    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            //    {
            //        Console.Write(Encoding.ASCII.GetString(buffer, 0, bytesRead));
            //    }
            //}
            #endregion

            HttpClient client = new HttpClient();
            //Console.Write(client.GetStringAsync(uri.AbsoluteUri).Result);

            HttpRequestMessage res = await client.GetAsync();

            Console.ReadKey();


        }
    }
}
