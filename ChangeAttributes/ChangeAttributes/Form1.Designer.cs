namespace ChangeAttributes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtPath = new TextBox();
            label1 = new Label();
            btnFile = new Button();
            btnFolder = new Button();
            label2 = new Label();
            txtDateModified = new TextBox();
            txtCreationTime = new TextBox();
            label3 = new Label();
            txtLastAccess = new TextBox();
            label4 = new Label();
            btnModify = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtPath
            // 
            txtPath.Location = new Point(183, 34);
            txtPath.Name = "txtPath";
            txtPath.PlaceholderText = "Enter or Paste a Path";
            txtPath.Size = new Size(556, 23);
            txtPath.TabIndex = 0;
            txtPath.TextChanged += txtPath_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 37);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 1;
            label1.Text = "Path";
            // 
            // btnFile
            // 
            btnFile.Location = new Point(541, 72);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(96, 23);
            btnFile.TabIndex = 2;
            btnFile.Text = "Choose File";
            btnFile.UseVisualStyleBackColor = true;
            btnFile.Click += btnFile_Click;
            // 
            // btnFolder
            // 
            btnFolder.Location = new Point(643, 72);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(96, 23);
            btnFolder.TabIndex = 3;
            btnFolder.Text = "Choose Folder";
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 136);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 4;
            label2.Text = "Date Modified";
            // 
            // txtDateModified
            // 
            txtDateModified.Location = new Point(183, 132);
            txtDateModified.Name = "txtDateModified";
            txtDateModified.Size = new Size(556, 23);
            txtDateModified.TabIndex = 5;
            // 
            // txtCreationTime
            // 
            txtCreationTime.Location = new Point(183, 183);
            txtCreationTime.Name = "txtCreationTime";
            txtCreationTime.Size = new Size(556, 23);
            txtCreationTime.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 187);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 6;
            label3.Text = "Creation Time";
            // 
            // txtLastAccess
            // 
            txtLastAccess.Location = new Point(183, 231);
            txtLastAccess.Name = "txtLastAccess";
            txtLastAccess.Size = new Size(556, 23);
            txtLastAccess.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 234);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 8;
            label4.Text = "Last Access Time";
            // 
            // btnModify
            // 
            btnModify.Location = new Point(396, 288);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 10;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 28F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(523, 382);
            label5.Name = "label5";
            label5.Size = new Size(255, 47);
            label5.TabIndex = 11;
            label5.Text = "Made By CPJ";
            label5.TextAlign = ContentAlignment.BottomRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(btnModify);
            Controls.Add(txtLastAccess);
            Controls.Add(label4);
            Controls.Add(txtCreationTime);
            Controls.Add(label3);
            Controls.Add(txtDateModified);
            Controls.Add(label2);
            Controls.Add(btnFolder);
            Controls.Add(btnFile);
            Controls.Add(label1);
            Controls.Add(txtPath);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Attributes App By CPJ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPath;
        private Label label1;
        private Button btnFile;
        private Button btnFolder;
        private Label label2;
        private TextBox txtDateModified;
        private TextBox txtCreationTime;
        private Label label3;
        private TextBox txtLastAccess;
        private Label label4;
        private Button btnModify;
        private Label label5;
    }
}