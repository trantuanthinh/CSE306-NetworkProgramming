using System;
using System.Net;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void resolveBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string address = urlText.Text;
            try {
                IPAddress[] iPAddresses = Dns.GetHostAddresses(address);
                foreach (var item in iPAddresses)
                {
                    Invoke(new Action(() => listBox1.Items.Add(item)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
