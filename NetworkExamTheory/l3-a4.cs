using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace Assignment_4
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
                string param = paramText.Text;
                string value = valueText.Text;
                string requestBody = $"{param}={value}";
                Dictionary<string, string> values = new Dictionary<string, string>
                {
                    {param,value }
                };
                FormUrlEncodedContent content = new FormUrlEncodedContent(values);
                HttpResponseMessage res = await client.PostAsync(uri, content);
                string body = await res.Content.ReadAsStringAsync();
                Invoke(new Action(() => textBox1.AppendText(body)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
