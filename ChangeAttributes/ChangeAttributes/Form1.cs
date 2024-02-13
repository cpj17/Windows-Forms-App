using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChangeAttributes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select File";
                //openFileDialog1.InitialDirectory = @"C:\";//--"C:\\";
                //openFileDialog1.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    txtPath.Text = openFileDialog1.FileName;
                }
                else
                { txtPath.Text = "You didn't select the file!"; }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog diag = new FolderBrowserDialog();
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtPath.Text = diag.SelectedPath;
                }
                else
                { txtPath.Text = "You didn't select the folder!"; }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttributeData()
        {
            try
            {
                txtDateModified.Text = Directory.GetLastWriteTime(txtPath.Text).ToString();
                txtCreationTime.Text = Directory.GetCreationTime(txtPath.Text).ToString();
                txtLastAccess.Text = Directory.GetLastAccessTime(txtPath.Text).ToString();
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string stringPath = txtPath.Text;
            bool boolConfiramation = false;

            try
            {
                if (!string.IsNullOrEmpty(stringPath))
                {
                    boolConfiramation = ShowMessage("Do you want to change?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (boolConfiramation)
                    {
                        if (File.Exists(stringPath))
                        {
                            File.SetLastWriteTime(stringPath, DateTime.Parse(txtDateModified.Text));
                            File.SetCreationTime(stringPath, DateTime.Parse(txtCreationTime.Text));
                            File.SetLastAccessTime(stringPath, DateTime.Parse(txtLastAccess.Text));

                            ShowMessage("Values are changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearValues();
                        }
                        else if (Directory.Exists(stringPath))
                        {
                            Directory.SetLastWriteTime(stringPath, DateTime.Parse(txtDateModified.Text));
                            Directory.SetCreationTime(stringPath, DateTime.Parse(txtCreationTime.Text));
                            Directory.SetLastAccessTime(stringPath, DateTime.Parse(txtLastAccess.Text));

                            ShowMessage("Values are changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearValues();
                        }
                        else
                        {
                            ShowMessage("Please choose valid file or folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    ShowMessage("Please choose file or folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else if (result == DialogResult.OK && objMsgIcon == MessageBoxIcon.Warning)
            {
                txtPath.Clear();
                txtPath.Focus();
            }
            else
            {

            }

            return false;
        }

        private void ClearValues()
        {
            txtPath.Clear();
            txtDateModified.Clear();
            txtCreationTime.Clear();
            txtLastAccess.Clear();

            txtPath.Focus();
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (txtPath.TextLength > 0)
            {
                if (ValidatePath())
                {
                    AttributeData();
                }
            }
        }

        private bool ValidatePath()
        {
            string stringPath = string.Empty;
            try
            {
                stringPath = txtPath.Text;
                if (File.Exists(stringPath))
                {
                    return true;
                }
                else if (Directory.Exists(stringPath))
                {
                    return true;
                }
                else
                {
                    ShowMessage("Please choose valid file or folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearValues();
                    return false;
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}