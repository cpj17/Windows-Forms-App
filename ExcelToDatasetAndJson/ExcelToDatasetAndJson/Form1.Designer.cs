namespace ExcelToDatasetAndJson
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
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.btnBrowseExcel = new System.Windows.Forms.Button();
            this.btnBrowseConfig = new System.Windows.Forms.Button();
            this.txtConfigPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownloadSampleConfig = new System.Windows.Forms.Button();
            this.txtSheetName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel Path";
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(121, 47);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(477, 20);
            this.txtExcelPath.TabIndex = 1;
            this.txtExcelPath.TextChanged += new System.EventHandler(this.txtExcelPath_TextChanged);
            // 
            // btnBrowseExcel
            // 
            this.btnBrowseExcel.Location = new System.Drawing.Point(604, 46);
            this.btnBrowseExcel.Name = "btnBrowseExcel";
            this.btnBrowseExcel.Size = new System.Drawing.Size(116, 22);
            this.btnBrowseExcel.TabIndex = 2;
            this.btnBrowseExcel.Text = "Browse Excel";
            this.btnBrowseExcel.UseVisualStyleBackColor = true;
            this.btnBrowseExcel.Click += new System.EventHandler(this.btnBrowseExcel_Click);
            // 
            // btnBrowseConfig
            // 
            this.btnBrowseConfig.Location = new System.Drawing.Point(604, 167);
            this.btnBrowseConfig.Name = "btnBrowseConfig";
            this.btnBrowseConfig.Size = new System.Drawing.Size(116, 22);
            this.btnBrowseConfig.TabIndex = 5;
            this.btnBrowseConfig.Text = "Browse Config";
            this.btnBrowseConfig.UseVisualStyleBackColor = true;
            this.btnBrowseConfig.Click += new System.EventHandler(this.btnBrowseConfig_Click);
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.Location = new System.Drawing.Point(121, 168);
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.Size = new System.Drawing.Size(477, 20);
            this.txtConfigPath.TabIndex = 4;
            this.txtConfigPath.TextChanged += new System.EventHandler(this.txtConfigPath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Config Path";
            // 
            // btnDownloadSampleConfig
            // 
            this.btnDownloadSampleConfig.Location = new System.Drawing.Point(604, 203);
            this.btnDownloadSampleConfig.Name = "btnDownloadSampleConfig";
            this.btnDownloadSampleConfig.Size = new System.Drawing.Size(116, 22);
            this.btnDownloadSampleConfig.TabIndex = 6;
            this.btnDownloadSampleConfig.Text = "Download Sample Config";
            this.btnDownloadSampleConfig.UseVisualStyleBackColor = true;
            this.btnDownloadSampleConfig.Click += new System.EventHandler(this.btnDownloadSampleConfig_Click);
            // 
            // txtSheetName
            // 
            this.txtSheetName.Location = new System.Drawing.Point(121, 88);
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Size = new System.Drawing.Size(477, 20);
            this.txtSheetName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter sheet name";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(313, 237);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 9;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(483, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Note :- If sheet name is \"Sheet1\" no need to enter otherwise please enter the she" +
    "et\r\nname. Case sensitive";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(531, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "Made by CPJ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtSheetName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDownloadSampleConfig);
            this.Controls.Add(this.btnBrowseConfig);
            this.Controls.Add(this.txtConfigPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseExcel);
            this.Controls.Add(this.txtExcelPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Button btnBrowseExcel;
        private System.Windows.Forms.Button btnBrowseConfig;
        private System.Windows.Forms.TextBox txtConfigPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownloadSampleConfig;
        private System.Windows.Forms.TextBox txtSheetName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

