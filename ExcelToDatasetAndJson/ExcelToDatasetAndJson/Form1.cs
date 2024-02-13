using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ExcelToDatasetAndJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select Excel File";

                //openFileDialog1.InitialDirectory = @"C:\";//--"C:\\";
                //openFileDialog1.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";

                openFileDialog1.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    txtExcelPath.Text = openFileDialog1.FileName;
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

        private void txtExcelPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtExcelPath.TextLength > 0)
                {
                    if (!ValidatePath(txtExcelPath.Text))
                    {
                        ShowMessage("Please select valid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtExcelPath.Text = string.Empty;
                    }
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePath(string stringPath)
        {
            try
            {
                if (File.Exists(stringPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private DataSet ConvertExcelToDataSet(string stringPath, string stringSheetName)
        {
            DataSet objDataSetReturn = new DataSet();
            stringSheetName = stringSheetName + "$";
            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + stringPath + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;\"";
                // The "HDR=YES" option indicates that the first row of the worksheet contains column headers.
                // The "IMEX=1" option tells the provider to always read intermixed data types as text.

                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                bool found = false;
                foreach (DataRow row in schemaTable.Rows)
                {
                    if (row["TABLE_NAME"].ToString() == stringSheetName)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + stringSheetName + "]", connection);
                    adapter.Fill(objDataSetReturn);

                    connection.Close();
                    return objDataSetReturn;
                }
                else
                {
                    ShowMessage("GIven sheet name " + stringSheetName + " , not exist in the selected excel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnBrowseConfig_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Select XML File";

                openFileDialog1.Filter = "XML Files|*.xml;";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    txtConfigPath.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownloadSampleConfig_Click(object sender, EventArgs e)
        {
            string stringSaveFile = "";
            byte[] bytes = null;
            try
            {
                SaveFileDialog objSaveFileDialog = new SaveFileDialog();
                objSaveFileDialog.Filter = "XML File|*.xml";
                objSaveFileDialog.FileName = "Sample Config";
                DialogResult result = objSaveFileDialog.ShowDialog();
                stringSaveFile = objSaveFileDialog.FileName;
                if (stringSaveFile.Length > 0)
                {
                    if (result != DialogResult.Cancel)
                    {
                        bytes = File.ReadAllBytes("Data/Config.xml");
                        File.WriteAllBytes(stringSaveFile, bytes);
                        ShowMessage("Sample config saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConfigPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtConfigPath.TextLength > 0)
                {
                    if (!ValidatePath(txtConfigPath.Text))
                    {
                        ShowMessage("Please select valid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtConfigPath.Text = string.Empty;
                    }
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DataSet objDataSetInput = new DataSet();
            DataSet objDataSetConfig = new DataSet();
            DataTable objDataTableTemp = new DataTable();
            DataSet objDataSetFinal = new DataSet();
            string stringSheetName = "";
            try
            {
                if (txtExcelPath.TextLength > 0 && txtConfigPath.TextLength > 0)
                {
                    objDataSetFinal.Tables.Add(new DataTable());
                    stringSheetName = txtSheetName.Text.Trim().Length == 0 ? "Sheet1" : txtSheetName.Text.Trim();
                    objDataSetInput = ConvertExcelToDataSet(txtExcelPath.Text, stringSheetName);

                    if (objDataSetInput != null && objDataSetInput.Tables[0] != null && objDataSetInput.Tables[0].Rows.Count > 0)
                    {
                        objDataSetConfig.ReadXml(txtConfigPath.Text, XmlReadMode.Auto);
                        objDataTableTemp = objDataSetConfig.Tables["t2"].Select("", "list_view_position asc").CopyToDataTable();

                        for (int i = 0; i < objDataTableTemp.Rows.Count; i++)
                        {
                            if (objDataTableTemp.Rows[i]["target_data_type"].ToString().ToUpper() == "DOUBLE")
                            {
                                if (!objDataSetFinal.Tables[0].Columns.Contains(objDataTableTemp.Rows[i]["excel_column_name"].ToString().ToUpper()))
                                {
                                    objDataSetFinal.Tables[0].Columns.Add(objDataTableTemp.Rows[i]["excel_column_name"].ToString().ToUpper(), typeof(double));
                                }
                            }
                            else
                            {
                                if (!objDataSetFinal.Tables[0].Columns.Contains(objDataTableTemp.Rows[i]["excel_column_name"].ToString().ToUpper()))
                                {
                                    objDataSetFinal.Tables[0].Columns.Add(objDataTableTemp.Rows[i]["excel_column_name"].ToString().ToUpper(), typeof(string));
                                }
                            }
                        }

                        objDataSetFinal.Tables[0].Merge(objDataSetInput.Tables[0], true, MissingSchemaAction.Ignore);

                        for (int i = 0; i < objDataTableTemp.Rows.Count; i++)
                        {
                            string stringColumnName = objDataTableTemp.Rows[i]["excel_column_name"].ToString();
                            string stringTargetName = objDataTableTemp.Rows[i]["target_name"].ToString();

                            objDataSetFinal.Tables[0].Columns[stringColumnName].ColumnName = stringTargetName;
                        }

                        bool boolAskSaveAsXML = ShowMessage("Do you want to save as xml file", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (boolAskSaveAsXML)
                            SaveXmlFile(objDataSetFinal);

                        bool boolAskSaveAsJson = ShowMessage("Do you want to save as json file", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (boolAskSaveAsJson)
                        {
                            var settings = new JsonSerializerSettings
                            {
                                ContractResolver = new DefaultContractResolver
                                {
                                    NamingStrategy = new DefaultNamingStrategy() // Or use another naming strategy that suits your needs
                                },
                                Formatting = Formatting.Indented,
                            };
                            string stringJson = JsonConvert.SerializeObject(objDataSetFinal.Tables[0], settings);
                            SaveJsonFile(stringJson);
                        }
                    }
                    else
                    {
                        ShowMessage("Excel is null or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ShowMessage("Select excel and config xml", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveXmlFile(DataSet objDataSetInput)
        {
            string stringSaveFile = "";
            try
            {
                SaveFileDialog objSaveFileDialog = new SaveFileDialog();
                objSaveFileDialog.Filter = "XML File|*.xml";
                objSaveFileDialog.FileName = "Output";
                DialogResult result = objSaveFileDialog.ShowDialog();
                stringSaveFile = objSaveFileDialog.FileName;
                if (stringSaveFile.Length > 0)
                {
                    if (result != DialogResult.Cancel)
                    {
                        objDataSetInput.WriteXml(stringSaveFile, XmlWriteMode.WriteSchema);
                        ShowMessage("Output saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveJsonFile(string stringInput)
        {
            string stringSaveFile = "";
            try
            {
                SaveFileDialog objSaveFileDialog = new SaveFileDialog();
                objSaveFileDialog.Filter = "JSON File|*.json";
                objSaveFileDialog.FileName = "Json string";
                DialogResult result = objSaveFileDialog.ShowDialog();
                stringSaveFile = objSaveFileDialog.FileName;
                if (stringSaveFile.Length > 0)
                {
                    if (result != DialogResult.Cancel)
                    {
                        File.WriteAllText(stringSaveFile, stringInput);
                        ShowMessage("Json string saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception objException)
            {
                ShowMessage(objException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
