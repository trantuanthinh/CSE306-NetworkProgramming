using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string content = chatTextBox.Text;

            if (!string.IsNullOrWhiteSpace(content))
            {
                contentListBox.Items.Add(content);

                chatTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter some text to send.");
            }
        }
    }
}
