using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
                string filePath = textBox1.Text;
            if (File.Exists(filePath))
            {
                Encoding encoding = radioButton2.Checked ?   Encoding.Unicode:Encoding.UTF8;
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (StreamReader reader = new StreamReader(fs, encoding)) {
                        string fileContent = reader.ReadToEnd();
                        textBox2.Text = fileContent;
                    }
                }
                else
                {
                    MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File not found. Please provide a valid file path.");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = radioButton2.Checked ? Encoding.Unicode : Encoding.UTF8 ;
                string newFilePath = saveFileDialog.FileName;
                string newContent = textBox2.Text;
                byte[] newFileBytes = encoding.GetBytes(newContent);
                File.WriteAllBytes(newFilePath, newFileBytes);
                MessageBox.Show("Successful");
            }
        }
    }
}