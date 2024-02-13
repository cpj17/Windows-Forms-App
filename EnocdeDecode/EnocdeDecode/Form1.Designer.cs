namespace EnocdeDecode
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
            openFileDialog1 = new OpenFileDialog();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowPreview = true;
            openFileDialog1.Title = "Open File Dialog";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(195, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(432, 217);
            panel1.TabIndex = 0;
            panel1.DragDrop += panel1_DragDrop;
            panel1.DragEnter += panel1_DragEnter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Panel panel1;
    }
}