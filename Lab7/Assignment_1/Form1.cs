using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;

                    txtPath.Text = selectedFolderPath;

                    var filters = new string[] { "*.jpg", "*.png" };

                    listBox1.Items.Clear();

                    var files = filters
                        .SelectMany(filter => Directory.GetFiles(selectedFolderPath, filter))
                        .ToArray();

                    foreach (string file in files)
                    {
                        listBox1.Items.Add(file);
                    }
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|All Files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    txtPath.Text = Directory.GetParent(selectedFilePath)?.FullName;
                    listBox1.Items.Clear();
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        listBox1.Items.Add(filePath);
                    }
                }
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            string prefix = txtPrefix.Text;
            long ratio = Int64.Parse(comboBox1.Text);
            foreach (var item in listBox1.Items)
            {
                using (Bitmap bitmap = new Bitmap(item.ToString()))
                {
                    string filePath = item.ToString();
                    string compressPath = Path.Combine(txtPath.Text, $"{txtPrefix.Text}{Path.GetFileName(filePath)}");

                    EncoderParameters encoderParameters = new EncoderParameters();
                    System.Drawing.Imaging.Encoder qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameter encoderParameter = new EncoderParameter(qualityEncoder, ratio);

                    //Save
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    encoderParameters.Param[0] = encoderParameter;
                    bitmap.Save(compressPath, jpgEncoder, encoderParameters);
                }
            }
            MessageBox.Show("Done!");
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
