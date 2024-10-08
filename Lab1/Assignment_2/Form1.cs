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
                    textBox1.Text = openFileDialog.FileName; // Set the file path in the textbox
                }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                Encoding encoding = radioButton1.Checked ? Encoding.UTF8 : Encoding.Unicode; 

                try
                {
                    string[] lines = File.ReadAllLines(textBox1.Text, encoding);
                    listBox1.Items.Clear(); 
                    foreach (var line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
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
                Encoding encoding = radioButton1.Checked ? Encoding.UTF8 : Encoding.Unicode;

                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, encoding))
                    {
                        foreach (var item in listBox1.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                    MessageBox.Show("Content saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message);
                }
            }
        }
    }
}
