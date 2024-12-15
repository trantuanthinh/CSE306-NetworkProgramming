using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string avatarPath = "";

        private void readBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (
                        FileStream fileStream = new FileStream(
                            filePath,
                            FileMode.Open,
                            FileAccess.Read
                        )
                    )
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fileStream))
                        {
                            try
                            {
                                string studentID = binaryReader.ReadString();
                                string fullName = binaryReader.ReadString();
                                string address = binaryReader.ReadString();
                                string avatarPath = binaryReader.ReadString();
                                string dateOfBirth = binaryReader.ReadString();

                                studentIDTextBox.Text = studentID;
                                fullNameTextBox.Text = fullName;
                                addressText.Text = address;
                                this.avatarPath = avatarPath;
                                pictureBox1.Image = Image.FromFile(avatarPath);
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                dateTimePicker1.Value = DateTime.Parse(dateOfBirth);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(
                                    $"An error occurred while reading the file: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                        {
                            binaryWriter.Write(studentIDTextBox.Text);
                            binaryWriter.Write(fullNameTextBox.Text);
                            binaryWriter.Write(addressText.Text);
                            binaryWriter.Write(avatarPath);
                            binaryWriter.Write(dateTimePicker1.Value.ToString());
                        }
                    }

                    MessageBox.Show(
                        "Student data saved successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void readAndDeserializeBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt| All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        using (
                            FileStream fileStream = new FileStream(
                                filePath,
                                FileMode.Open,
                                FileAccess.Read
                            )
                        )
                        {
                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                var json = reader.ReadToEnd();
                                Student student = JsonSerializer.Deserialize<Student>(json);
                                if (student != null)
                                {
                                    studentIDTextBox.Text = student.Id;
                                    fullNameTextBox.Text = student.Name;
                                    addressText.Text = student.Address;
                                    avatarPath = student.AvatarPath;
                                    pictureBox1.Image = Image.FromFile(avatarPath);
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    dateTimePicker1.Value = student.DateofBirth;

                                    MessageBox.Show(
                                        "Student data loaded successfully.",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Failed to deserialize the student data.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"An error occurred while saving the file: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void serializeAndSaveBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt| All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    Student student = new Student();
                    student.Id = studentIDTextBox.Text;
                    student.Name = fullNameTextBox.Text;
                    student.Address = addressText.Text;
                    student.AvatarPath = avatarPath;
                    student.DateofBirth = dateTimePicker1.Value;

                    try
                    {
                        var jsonData = JsonSerializer.Serialize(student);
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            using (StreamWriter writer = new StreamWriter(fileStream))
                            {
                                writer.Write(jsonData);
                            }
                        }
                        MessageBox.Show(
                            "Student data saved successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"An error occurred while saving the file: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"D:\CSE306-NetworkProgramming\Lab2";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    avatarPath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(avatarPath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
