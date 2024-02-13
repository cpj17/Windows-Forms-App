using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathTrigger
{
    public partial class TriggerForm : Form
    {
        DataSet objDataSetPathDetails = null;
        string stringTableName = "t2";
        public TriggerForm()
        {
            InitializeComponent();
            InitFunction();
            GetData();
        }

        private void InitFunction()
        {
            if (!File.Exists("pathDetails.xml"))
            {
                DataSet objDataSet = new DataSet();
                DataTable objDataTable = new DataTable("t2");

                objDataTable.Columns.Add("id", typeof(string));
                objDataTable.Columns.Add("path", typeof(string));
                objDataTable.Columns.Add("display_name", typeof(string)); ;
                objDataTable.Rows.Add(DateTime.Now.ToString("ddMMyyyyhhmmssffff"), "D:", "Drive D");

                objDataSet.Tables.Add(objDataTable);
                objDataSet.WriteXml("pathDetails.xml");
            }
        }

        private void GetData()
        {
            try
            {
                objDataSetPathDetails = new DataSet();
                objDataSetPathDetails.ReadXml("pathDetails.xml");

                Label myLabel = null;

                myLabel = new Label();

                pnlPaths.Refresh();

                // Loop through and create the labels
                for (int i = 0; i < objDataSetPathDetails.Tables[stringTableName].Rows.Count; i++)
                {
                    // Create a new label
                    myLabel = new Label();
                    myLabel.Text = i + 1 + ".  " + objDataSetPathDetails.Tables[stringTableName].Rows[i]["display_name"].ToString();
                    myLabel.Location = new Point(10, (i + 1) * 33); // Set the position
                    myLabel.AutoSize = true;

                    myLabel.Font = new Font(myLabel.Font.FontFamily, 16);
                    myLabel.TabIndex = 1;
                    myLabel.Cursor = Cursors.Hand;
                    myLabel.Tag = objDataSetPathDetails.Tables[stringTableName].Rows[i]["path"].ToString();
                    myLabel.Click += lblPath_Clicked;

                    myLabel.MouseEnter += lblPath_MouseEnter;
                    myLabel.MouseLeave += lblPath_MouseLeave;

                    //this.Controls.Add(myLabel);
                    pnlPaths.Controls.Add(myLabel);
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objDataSetPathDetails = null;
            }
        }

        private void lblPath_Clicked(object sender, EventArgs e)
        {
            try
            {
                Label objLabel = sender as Label;
                string stringPath = objLabel.Tag.ToString();
                
                Process.Start(stringPath);
            }
            catch (ArgumentNullException ex)
            {
                ShowMessage("Path not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                ShowMessage("Path not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // The event handler for the MouseEnter event
        void lblPath_MouseEnter(object sender, EventArgs e)
        {
            // Change the label's back color to indicate it's being hovered over
            Label hoveredLabel = sender as Label;
            hoveredLabel.BackColor = Color.LightGray;
            hoveredLabel.ForeColor = Color.Red;
        }

        // The event handler for the MouseLeave event
        void lblPath_MouseLeave(object sender, EventArgs e)
        {
            // Restore the label's original back color
            Label hoveredLabel = sender as Label;
            hoveredLabel.BackColor = SystemColors.Control;
            hoveredLabel.ForeColor = Color.Black;
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

        private void btnSummary_Click(object sender, EventArgs e)
        {
            SummaryForm summaryForm = new SummaryForm();
            summaryForm.Show();
            this.Hide();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddEditPaths addEditPaths = new AddEditPaths();
            addEditPaths.Tag = "000,I";
            addEditPaths.Show();
            this.Hide();
        }

        private void TriggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
