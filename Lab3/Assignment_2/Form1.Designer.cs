namespace Assignment_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlText = new System.Windows.Forms.TextBox();
            this.resolveBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(39, 50);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(281, 22);
            this.urlText.TabIndex = 0;
            // 
            // resolveBtn
            // 
            this.resolveBtn.Location = new System.Drawing.Point(326, 49);
            this.resolveBtn.Name = "resolveBtn";
            this.resolveBtn.Size = new System.Drawing.Size(75, 23);
            this.resolveBtn.TabIndex = 1;
            this.resolveBtn.Text = "Resolve";
            this.resolveBtn.UseVisualStyleBackColor = true;
            this.resolveBtn.Click += new System.EventHandler(this.resolveBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(39, 94);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(281, 180);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 313);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.resolveBtn);
            this.Controls.Add(this.urlText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.Button resolveBtn;
        private System.Windows.Forms.ListBox listBox1;
    }
}

