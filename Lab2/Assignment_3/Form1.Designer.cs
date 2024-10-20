namespace Assignment_3
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
            this.label5 = new System.Windows.Forms.Label();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.studentIDTextBox = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.selectBtn = new System.Windows.Forms.Button();
            this.serializeAndSaveBtn = new System.Windows.Forms.Button();
            this.readAndDeserializeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.readBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Avatar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Full Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date of Birth";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(15, 86);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(200, 22);
            this.fullNameTextBox.TabIndex = 5;
            this.fullNameTextBox.Text = "trantuanthinh";
            // 
            // studentIDTextBox
            // 
            this.studentIDTextBox.Location = new System.Drawing.Point(15, 28);
            this.studentIDTextBox.Name = "studentIDTextBox";
            this.studentIDTextBox.Size = new System.Drawing.Size(200, 22);
            this.studentIDTextBox.TabIndex = 6;
            this.studentIDTextBox.Text = "012570";
            // 
            // addressText
            // 
            this.addressText.Location = new System.Drawing.Point(15, 212);
            this.addressText.Multiline = true;
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(200, 47);
            this.addressText.TabIndex = 7;
            this.addressText.Text = "BinhDuong";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 148);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Value = new System.DateTime(2002, 11, 5, 0, 0, 0, 0);
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(292, 28);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(125, 23);
            this.selectBtn.TabIndex = 9;
            this.selectBtn.Text = "Select/ Change";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // serializeAndSaveBtn
            // 
            this.serializeAndSaveBtn.Location = new System.Drawing.Point(158, 294);
            this.serializeAndSaveBtn.Name = "serializeAndSaveBtn";
            this.serializeAndSaveBtn.Size = new System.Drawing.Size(259, 23);
            this.serializeAndSaveBtn.TabIndex = 10;
            this.serializeAndSaveBtn.Text = "Serialize and Save to a file";
            this.serializeAndSaveBtn.UseVisualStyleBackColor = true;
            this.serializeAndSaveBtn.Click += new System.EventHandler(this.serializeAndSaveBtn_Click);
            // 
            // readAndDeserializeBtn
            // 
            this.readAndDeserializeBtn.Location = new System.Drawing.Point(158, 265);
            this.readAndDeserializeBtn.Name = "readAndDeserializeBtn";
            this.readAndDeserializeBtn.Size = new System.Drawing.Size(259, 23);
            this.readAndDeserializeBtn.TabIndex = 11;
            this.readAndDeserializeBtn.Text = "Read from a file and Deserialize";
            this.readAndDeserializeBtn.UseVisualStyleBackColor = true;
            this.readAndDeserializeBtn.Click += new System.EventHandler(this.readAndDeserializeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(16, 294);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(136, 23);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Save to a file";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // readBtn
            // 
            this.readBtn.Location = new System.Drawing.Point(16, 265);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(136, 23);
            this.readBtn.TabIndex = 13;
            this.readBtn.Text = "Read from a file";
            this.readBtn.UseVisualStyleBackColor = true;
            this.readBtn.Click += new System.EventHandler(this.readBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(292, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 123);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.readBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.readAndDeserializeBtn);
            this.Controls.Add(this.serializeAndSaveBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.studentIDTextBox);
            this.Controls.Add(this.fullNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Student Management";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.TextBox studentIDTextBox;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button serializeAndSaveBtn;
        private System.Windows.Forms.Button readAndDeserializeBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button readBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
