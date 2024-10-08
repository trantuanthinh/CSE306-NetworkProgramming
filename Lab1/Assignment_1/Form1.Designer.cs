namespace Assignment_1
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
            this.sendBtn = new System.Windows.Forms.Button();
            this.chatLabel = new System.Windows.Forms.Label();
            this.showLabel = new System.Windows.Forms.Label();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.contentListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(387, 55);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 0;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // chatLabel
            // 
            this.chatLabel.AutoSize = true;
            this.chatLabel.Location = new System.Drawing.Point(47, 35);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(83, 16);
            this.chatLabel.TabIndex = 1;
            this.chatLabel.Text = "Your Content";
            // 
            // showLabel
            // 
            this.showLabel.AutoSize = true;
            this.showLabel.Location = new System.Drawing.Point(50, 92);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(82, 16);
            this.showLabel.TabIndex = 2;
            this.showLabel.Text = "Chat Content";
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(53, 56);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(328, 22);
            this.chatTextBox.TabIndex = 3;
            // 
            // contentListBox
            // 
            this.contentListBox.FormattingEnabled = true;
            this.contentListBox.ItemHeight = 16;
            this.contentListBox.Location = new System.Drawing.Point(53, 126);
            this.contentListBox.Name = "contentListBox";
            this.contentListBox.Size = new System.Drawing.Size(328, 228);
            this.contentListBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 366);
            this.Controls.Add(this.contentListBox);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.showLabel);
            this.Controls.Add(this.chatLabel);
            this.Controls.Add(this.sendBtn);
            this.Name = "Form1";
            this.Text = "Chat App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label chatLabel;
        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.ListBox contentListBox;
    }
}

