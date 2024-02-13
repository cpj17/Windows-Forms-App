using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileToText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select Excel File";

                //openFileDialog1.InitialDirectory = @"C:\";//--"C:\\";
                //openFileDialog1.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
                openFileDialog1.Filter = "All files (*.*)|*.*";

                //openFileDialog1.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    textBox1.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ShowMessage(string stringMsg, string stringTitle, MessageBoxButtons objMsgButtons, MessageBoxIcon objMsgIcon)
        {
            DialogResult result = MessageBox.Show(stringMsg, stringTitle, objMsgButtons, objMsgIcon);
            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox1.Text;
                byte[] bytes = File.ReadAllBytes(path);

                string byteString = Convert.ToBase64String(bytes);

                int count = 10500000; //10MB
                //int count = 500000; //488KB

                List<string> stringList = new List<string>();
                for (int i = 0; i < byteString.Length; i += count)
                {
                    int length = Math.Min(count, byteString.Length - i);
                    string substring = byteString.Substring(i, length);
                    stringList.Add(substring);
                }

                FolderBrowserDialog diag = new FolderBrowserDialog();
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < stringList.Count; i++)
                    {
                        File.WriteAllText(diag.SelectedPath + "/" + i.ToString("d8") + ".txt", stringList[i]);
                    }
                    ShowMessage("ok", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] bytes;
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                string path = diag.SelectedPath;
                string[] list = Directory.GetFiles(path);
                string byteString = "";

                for (int i = 0; i < list.Length; i++)
                {
                    byteString += File.ReadAllText(list[i]);
                }
                bytes = Convert.FromBase64String(byteString);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // Set the initial directory and filename
                //saveFileDialog1.InitialDirectory = "C:\\";
                saveFileDialog1.FileName = "file.mp4";

                // Set the file filters
                //saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.Filter = "All files (*.*)|*.*";

                // Show the dialog box and wait for the user to select a file
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected filename and do something with it
                    string filename = saveFileDialog1.FileName;
                    File.WriteAllBytes(filename, bytes);
                    ShowMessage("ok", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
