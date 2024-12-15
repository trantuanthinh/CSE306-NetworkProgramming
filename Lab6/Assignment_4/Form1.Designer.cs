namespace Assignment_4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtCompare = new System.Windows.Forms.TextBox();
            this.txtsha1 = new System.Windows.Forms.TextBox();
            this.txtmd5 = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "SHA1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "MD5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Compare";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(91, 36);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(350, 22);
            this.txtFile.TabIndex = 4;
            // 
            // txtCompare
            // 
            this.txtCompare.Location = new System.Drawing.Point(29, 273);
            this.txtCompare.Multiline = true;
            this.txtCompare.Name = "txtCompare";
            this.txtCompare.Size = new System.Drawing.Size(412, 62);
            this.txtCompare.TabIndex = 5;
            this.txtCompare.Text = "898068A238EB23D24D544ABCCD964C22";
            // 
            // txtsha1
            // 
            this.txtsha1.Location = new System.Drawing.Point(29, 118);
            this.txtsha1.Multiline = true;
            this.txtsha1.Name = "txtsha1";
            this.txtsha1.Size = new System.Drawing.Size(199, 102);
            this.txtsha1.TabIndex = 6;
            // 
            // txtmd5
            // 
            this.txtmd5.Location = new System.Drawing.Point(253, 118);
            this.txtmd5.Multiline = true;
            this.txtmd5.Name = "txtmd5";
            this.txtmd5.Size = new System.Drawing.Size(188, 102);
            this.txtmd5.TabIndex = 7;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(447, 35);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "Select File";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(466, 295);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 9;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 402);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtmd5);
            this.Controls.Add(this.txtsha1);
            this.Controls.Add(this.txtCompare);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtCompare;
        private System.Windows.Forms.TextBox txtsha1;
        private System.Windows.Forms.TextBox txtmd5;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCompare;
    }
}

