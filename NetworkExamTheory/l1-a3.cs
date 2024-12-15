using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Assignment_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Student
        {
            public string StudentID { get; set; }
            public string FullName { get; set; }
            public string Address { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string AvatarPath { get; set; } 
        }

        private string selectedImagePath = null;

        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    selectedImagePath = filePath;
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student
                {
                    StudentID = studentIDTextBox.Text,
                    FullName = fullNameTextBox.Text,
                    Address = addressText.Text,
                    DateOfBirth = dateTimePicker1.Value,
                    AvatarPath = selectedImagePath 
                };

                string jsonData = JsonSerializer.Serialize(student);
                File.WriteAllText("student.json", jsonData);
                MessageBox.Show("Data serialized and saved to file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error serializing data: " + ex.Message);
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("student.json"))
                {
                    string jsonData = File.ReadAllText("student.json");
                    var student = JsonSerializer.Deserialize<Student>(jsonData);

                    studentIDTextBox.Text = student.StudentID;
                    fullNameTextBox.Text = student.FullName;
                    addressText.Text = student.Address;
                    dateTimePicker1.Value = student.DateOfBirth;

                    if (!string.IsNullOrEmpty(student.AvatarPath) && File.Exists(student.AvatarPath))
                    {
                        pictureBox1.Image = Image.FromFile(student.AvatarPath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    MessageBox.Show("Data deserialized from file.");
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deserializing data: " + ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student
                {
                    StudentID = studentIDTextBox.Text,
                    FullName = fullNameTextBox.Text,
                    Address = addressText.Text,
                    DateOfBirth = dateTimePicker1.Value,
                    AvatarPath = selectedImagePath 
                };

                string rawData = $"{student.StudentID},{student.FullName},{student.Address},{student.DateOfBirth},{student.AvatarPath}";
                File.WriteAllText("student_raw.txt", rawData);
                MessageBox.Show("Data saved as raw text.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving raw data: " + ex.Message);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("student_raw.txt"))
                {
                    string rawData = File.ReadAllText("student_raw.txt");
                    string[] data = rawData.Split(',');

                    studentIDTextBox.Text = data[0];
                    fullNameTextBox.Text = data[1];
                    addressText.Text = data[2];
                    dateTimePicker1.Value = DateTime.Parse(data[3]);

                    if (!string.IsNullOrEmpty(data[4]) && File.Exists(data[4]))
                    {
                        pictureBox1.Image = Image.FromFile(data[4]);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    MessageBox.Show("Data loaded from raw text file.");
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading raw data: " + ex.Message);
            }
        }
    }
}
