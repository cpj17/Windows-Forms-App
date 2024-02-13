using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathTrigger
{
    public partial class AddEditPaths : Form
    {
        DataSet objDataSetPathDetails = null;

        string stringTableName = "t2";
        string stringKey = "";
        string stringDML = "";
        string stringTag = "";
        DataRow[] objDataRowSelected;

        public AddEditPaths()
        {
            InitializeComponent();
        }

        private void AddEditPaths_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void InitFunction()
        {
            try
            {
                txtDisplayName.Focus();
                objDataSetPathDetails = new DataSet();

                objDataSetPathDetails.ReadXml("pathDetails.xml");
                stringTag = (string)this.Tag.ToString();
                stringKey = stringTag.Split(',')[0];
                stringDML = stringTag.Split(',')[1];

                if (stringDML == "U")
                {
                    lblAddEdit.Text = "Edit Paths";
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;

                    objDataRowSelected = objDataSetPathDetails.Tables[stringTableName].Select("id = '" + stringKey + "'");
                    txtDisplayName.Text = objDataRowSelected[0]["display_name"].ToString();
                    txtPath.Text = objDataRowSelected[0]["path"].ToString();
                }
                else
                {
                    lblAddEdit.Text = "Add Paths";
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDisplayName.Text.Length <= 61)
                {
                    string stringUniqKey = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
                    DataRow objDataRow = objDataSetPathDetails.Tables[stringTableName].NewRow();
                    objDataRow["id"] = stringUniqKey;
                    objDataRow["path"] = txtPath.Text;
                    objDataRow["display_name"] = txtDisplayName.Text;
                    objDataSetPathDetails.Tables["t2"].Rows.Add(objDataRow);
                    objDataSetPathDetails.WriteXml("PathDetails.xml");

                    ShowMessage("Details added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BackToHome();
                }
                else
                {
                    ShowMessage("Display name must contain less than 61 charaters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackToHome()
        {
            try
            {
                this.Hide();
                TriggerForm triggerForm = new TriggerForm();
                triggerForm.Show();
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEditPaths_Load(object sender, EventArgs e)
        {
            InitFunction();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            TriggerForm triggerForm = new TriggerForm();
            triggerForm.Show();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            SummaryForm summaryForm = new SummaryForm();
            summaryForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objDataRowSelected[0]["display_name"] = txtDisplayName.Text;
                objDataRowSelected[0]["path"] = txtPath.Text;
                objDataSetPathDetails.AcceptChanges();
                objDataSetPathDetails.WriteXml("PathDetails.xml");

                ShowMessage("Details updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShowMessage("Do you want to delete", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    objDataRowSelected[0].Delete();
                    objDataSetPathDetails.AcceptChanges();
                    objDataSetPathDetails.WriteXml("PathDetails.xml");

                    ShowMessage("Deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BackToHome();
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
