using System;
using System.Security.Cryptography;
using System.Text;

namespace Demo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region
            //Uri uri = new Uri("http://example.com");

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

            //HttpClient client = new HttpClient();
            //Console.Write(client.GetStringAsync(uri.AbsoluteUri).Result);

            //HttpRequestMessage res = await client.GetAsync();

            //byte[] key;
            //byte[] iv;

            //string plainText = "content";

            //TripleDES tripleDES = TripleDES.Create();

            //key = tripleDES.Key;
            //iv = tripleDES.IV;

            //ICryptoTransform encrypter = tripleDES.CreateEncryptor(key, iv);

            //MemoryStream memoryStream = new MemoryStream();
            //CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypter, CryptoStreamMode.Write);

            //byte[] cipher = Encoding.UTF8.GetBytes(plainText);
            //cryptoStream.Write(cipher, 0, cipher.Length);
            //cryptoStream.FlushFinalBlock();

            //byte[] ecrypted = memoryStream.ToArray();

            //Console.WriteLine(Convert.ToBase64String(ecrypted));

            //ICryptoTransform decrypter = tripleDES.CreateDecryptor(key, iv);
            //memoryStream = new MemoryStream(ecrypted);
            //cryptoStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read);
            //StreamReader streamReader = new StreamReader(cryptoStream, Encoding.UTF8);
            //Console.WriteLine(streamReader.ReadToEnd());

            /*
            Console.OutputEncoding = Encoding.UTF8;
            String data = "content";
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] ecryptedData;
            RSAParameters rsaParameters;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsaParameters = rsa.ExportParameters(true);
                ecryptedData = rsa.Encrypt(bytes, true);
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParameters);
                decryptedData = rsa.Decrypt(ecryptedData, true);
            }

            Console.WriteLine(Encoding.UTF8.GetString(ecryptedData));
            Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
            */

            string pass = "content";
            byte[] bytes = Encoding.UTF8.GetBytes(pass);
            byte[] hashedData;

            using (SHA256 sha256 = SHA256.Create())
            {
                hashedData = sha256.ComputeHash(bytes);   
            }


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashedData.Length; i++)
            {
                sb.Append(hashedData[i].ToString("x2"));
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}