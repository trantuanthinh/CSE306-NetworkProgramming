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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textServer = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textPathClient = new System.Windows.Forms.TextBox();
            this.textPathServer = new System.Windows.Forms.TextBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.listBoxFoldersClient = new System.Windows.Forms.ListBox();
            this.listBoxFilesClient = new System.Windows.Forms.ListBox();
            this.listBoxFoldersServer = new System.Windows.Forms.ListBox();
            this.listBoxFilesServer = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Folders";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Files";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(617, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Folders";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tree View";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(257, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Port";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(615, 377);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Files";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Password";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Path";
            // 
            // textServer
            // 
            this.textServer.Location = new System.Drawing.Point(91, 20);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(364, 22);
            this.textServer.TabIndex = 12;
            this.textServer.Text = "ftp://127.0.0.1";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(91, 50);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(160, 22);
            this.textUsername.TabIndex = 13;
            this.textUsername.Text = "anonymous";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(91, 78);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(160, 22);
            this.textPassword.TabIndex = 14;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(295, 48);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(160, 22);
            this.textPort.TabIndex = 15;
            this.textPort.Text = "21";
            // 
            // textPathClient
            // 
            this.textPathClient.Location = new System.Drawing.Point(62, 167);
            this.textPathClient.Name = "textPathClient";
            this.textPathClient.Size = new System.Drawing.Size(403, 22);
            this.textPathClient.TabIndex = 16;
            // 
            // textPathServer
            // 
            this.textPathServer.Location = new System.Drawing.Point(657, 167);
            this.textPathServer.Name = "textPathServer";
            this.textPathServer.Size = new System.Drawing.Size(234, 22);
            this.textPathServer.TabIndex = 17;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(20, 222);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(231, 298);
            this.treeView.TabIndex = 18;
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // listBoxFoldersClient
            // 
            this.listBoxFoldersClient.FormattingEnabled = true;
            this.listBoxFoldersClient.ItemHeight = 16;
            this.listBoxFoldersClient.Location = new System.Drawing.Point(274, 222);
            this.listBoxFoldersClient.Name = "listBoxFoldersClient";
            this.listBoxFoldersClient.Size = new System.Drawing.Size(181, 116);
            this.listBoxFoldersClient.TabIndex = 19;
            this.listBoxFoldersClient.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFoldersClient_MouseDoubleClick);
            // 
            // listBoxFilesClient
            // 
            this.listBoxFilesClient.FormattingEnabled = true;
            this.listBoxFilesClient.ItemHeight = 16;
            this.listBoxFilesClient.Location = new System.Drawing.Point(272, 404);
            this.listBoxFilesClient.Name = "listBoxFilesClient";
            this.listBoxFilesClient.Size = new System.Drawing.Size(181, 116);
            this.listBoxFilesClient.TabIndex = 20;
            // 
            // listBoxFoldersServer
            // 
            this.listBoxFoldersServer.FormattingEnabled = true;
            this.listBoxFoldersServer.ItemHeight = 16;
            this.listBoxFoldersServer.Location = new System.Drawing.Point(620, 222);
            this.listBoxFoldersServer.Name = "listBoxFoldersServer";
            this.listBoxFoldersServer.Size = new System.Drawing.Size(271, 116);
            this.listBoxFoldersServer.TabIndex = 21;
            // 
            // listBoxFilesServer
            // 
            this.listBoxFilesServer.FormattingEnabled = true;
            this.listBoxFilesServer.ItemHeight = 16;
            this.listBoxFilesServer.Location = new System.Drawing.Point(620, 404);
            this.listBoxFilesServer.Name = "listBoxFilesServer";
            this.listBoxFilesServer.Size = new System.Drawing.Size(269, 116);
            this.listBoxFilesServer.TabIndex = 22;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(622, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(269, 100);
            this.listBox1.TabIndex = 23;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBack.Location = new System.Drawing.Point(712, 344);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(481, 58);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(104, 42);
            this.btnLogIn.TabIndex = 25;
            this.btnLogIn.Text = "Log in";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(481, 243);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(104, 42);
            this.btnUpload.TabIndex = 26;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(481, 300);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(104, 38);
            this.btnDownload.TabIndex = 27;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(481, 353);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 40);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(481, 404);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(104, 46);
            this.btnRename.TabIndex = 29;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 551);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listBoxFilesServer);
            this.Controls.Add(this.listBoxFoldersServer);
            this.Controls.Add(this.listBoxFilesClient);
            this.Controls.Add(this.listBoxFoldersClient);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.textPathServer);
            this.Controls.Add(this.textPathClient);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.textServer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textServer;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textPathClient;
        private System.Windows.Forms.TextBox textPathServer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListBox listBoxFoldersClient;
        private System.Windows.Forms.ListBox listBoxFilesClient;
        private System.Windows.Forms.ListBox listBoxFoldersServer;
        private System.Windows.Forms.ListBox listBoxFilesServer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRename;
    }
}

