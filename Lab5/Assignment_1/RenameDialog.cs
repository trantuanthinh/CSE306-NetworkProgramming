using System;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class RenameDialog : Form
    {
        public string NewName { get; set; }

        public RenameDialog(string currentName)
        {
            InitializeComponent();
            txtRename.Text = currentName;
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            NewName = txtRename.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
