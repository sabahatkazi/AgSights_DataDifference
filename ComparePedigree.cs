using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgSights
{
    public partial class ComparePedigree : Form
    {
        DataSet dataSource = new DataSet();
        DataSet dataBioTrack = new DataSet();
        int iCompare = 0;
        DataTable dtOutputTable = null;
        DataRow drOutputRow = null;
        DataTable dtNewDataOutputTable = null;

        StringBuilder strMessage = new StringBuilder(string.Empty);
        StringBuilder strNewMessage = new StringBuilder(string.Empty);

        public ComparePedigree()
        {
            InitializeComponent();
        }

        void CreateOutputTable()
        {
            dtOutputTable = new DataTable();
            dtOutputTable.Columns.Add("Message");
            dtOutputTable.Columns.Add("tattoo");
            dtOutputTable.Columns.Add("birthdate");
            dtOutputTable.Columns.Add("siretattoo");
            dtOutputTable.Columns.Add("btsiretattoo");
            dtOutputTable.Columns.Add("damtattoo");
            dtOutputTable.Columns.Add("btdamtattoo");
            dtOutputTable.Columns.Add("donortattoo");
            dtOutputTable.Columns.Add("btdonortattoo");
            dtOutputTable.Columns.Add("registrationid");
            dtOutputTable.Columns.Add("btregistrationid");
            dtOutputTable.Columns.Add("registrationname");
            dtOutputTable.Columns.Add("btregistrationname");

            dtOutputTable.AcceptChanges();
        }

        void CreateNewDataOutputTable()
        {
            dtNewDataOutputTable = new DataTable();
            dtNewDataOutputTable.Columns.Add("currentownerid");
            dtNewDataOutputTable.Columns.Add("currentowner");
            dtNewDataOutputTable.Columns.Add("calvingseason");
            dtNewDataOutputTable.Columns.Add("eartag");
            dtNewDataOutputTable.Columns.Add("biotattoo");
            dtNewDataOutputTable.Columns.Add("location");
            dtNewDataOutputTable.Columns.Add("birthdate");
            dtNewDataOutputTable.Columns.Add("bornthroughai");
            dtNewDataOutputTable.Columns.Add("colour");
            dtNewDataOutputTable.Columns.Add("sex");
            dtNewDataOutputTable.Columns.Add("calvingease");
            dtNewDataOutputTable.Columns.Add("birthweight");
            dtNewDataOutputTable.Columns.Add("bornas");
            dtNewDataOutputTable.Columns.Add("raisedas");
            dtNewDataOutputTable.Columns.Add("horns");
            dtNewDataOutputTable.Columns.Add("registrationid");
            dtNewDataOutputTable.Columns.Add("registrationname");
            dtNewDataOutputTable.Columns.Add("breed1");
            dtNewDataOutputTable.Columns.Add("composition1");
            dtNewDataOutputTable.Columns.Add("breed2");
            dtNewDataOutputTable.Columns.Add("composition2");
            dtNewDataOutputTable.Columns.Add("breed3");
            dtNewDataOutputTable.Columns.Add("composition3");
            dtNewDataOutputTable.Columns.Add("breed4");
            dtNewDataOutputTable.Columns.Add("composition4");
            dtNewDataOutputTable.Columns.Add("totalbreedcomp");
            dtNewDataOutputTable.Columns.Add("weaningdate");
            dtNewDataOutputTable.Columns.Add("weaningweight");
            dtNewDataOutputTable.Columns.Add("myostatingene");
            dtNewDataOutputTable.Columns.Add("tattoo");
            dtNewDataOutputTable.Columns.Add("siretattoo");
            dtNewDataOutputTable.Columns.Add("damtattoo");
            dtNewDataOutputTable.Columns.Add("donortattoo");

            dtNewDataOutputTable.AcceptChanges();
        }

        private void btnSourceFile_Click(object sender, EventArgs e)
        {
            lblMessageSource.Text = "";
            lblMessageSource.Visible = false;
            dgvCompare.Visible = false;
            dgvNewCompare.Visible = false;
            try
            {
                //ofdOtherSourceFile openFileDialog = new OpenFileDialog();
                ofdOtherSourceFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                ofdOtherSourceFile.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                if (ofdOtherSourceFile.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = ofdOtherSourceFile.FileName;
                    
                    using (var stream = File.Open(FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                        {
                            dataSource = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                        }
                    }

                    ChangeColumnName(ref dataSource);

                    lblMessageSource.Text = "Success";
                    lblMessageSource.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                lblMessageSource.Text = "Error";
                lblMessageSource.Visible = true;
                ex.ToString();
            }
        }

        private void btnUploadBioTrack_Click(object sender, EventArgs e)
        {
            lblMessageBioTrack.Text = "";
            lblMessageBioTrack.Visible = false;
            dgvCompare.Visible = false;
            dgvNewCompare.Visible = false;

            try
            {
                ofdBioTrackFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                ofdBioTrackFile.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                if (ofdBioTrackFile.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = ofdBioTrackFile.FileName;

                    using (var stream = File.Open(FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                        {
                            dataBioTrack = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                        }
                    }

                    ChangeColumnName(ref dataBioTrack);

                    foreach (DataRow drRow in dataBioTrack.Tables[0].Rows)
                    {
                        drRow["tattoo"] = Convert.ToString(drRow["tattoo"]).Substring(2, Convert.ToString(drRow["tattoo"]).Length - 3);
                        drRow["siretattoo"] = Convert.ToString(drRow["siretattoo"]) == "NULL" ? string.Empty : Convert.ToString(drRow["siretattoo"]).Substring(2, Convert.ToString(drRow["siretattoo"]).Length - 3);
                        drRow["damtattoo"] = Convert.ToString(drRow["damtattoo"]) == "NULL" ? string.Empty : Convert.ToString(drRow["damtattoo"]).Substring(2, Convert.ToString(drRow["damtattoo"]).Length - 3);
                        drRow["donortattoo"] = Convert.ToString(drRow["donortattoo"]) == "NULL" ? string.Empty : Convert.ToString(drRow["donortattoo"]).Substring(2, Convert.ToString(drRow["donortattoo"]).Length - 3);
                    }

                    lblMessageBioTrack.Text = "Success";
                    lblMessageBioTrack.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                lblMessageBioTrack.Text = "Error";
                lblMessageBioTrack.Visible = true;
                ex.ToString();
            }
        }

        public void ChangeColumnName(ref DataSet dsOut)
        {
            foreach (DataColumn col in dsOut.Tables[0].Columns)
            {
                col.ColumnName = col.ColumnName.ToLower();
                if (col.ColumnName == "birth date" || col.ColumnName == "bd" || col.ColumnName == "birthdate" || col.ColumnName == "b d")
                {
                    col.ColumnName = "birthdate";
                }

                if (col.ColumnName == "sire tattoo" || col.ColumnName == "siretattoo")
                {
                    col.ColumnName = "siretattoo";
                }

                if (col.ColumnName == "dam tattoo" || col.ColumnName == "damtattoo")
                {
                    col.ColumnName = "damtattoo";
                }

                if (col.ColumnName == "donor tattoo" || col.ColumnName == "donortattoo")
                {
                    col.ColumnName = "donortattoo";
                }

                if (col.ColumnName == "registration id" || col.ColumnName == "registrationid")
                {
                    col.ColumnName = "registrationid";
                }

                if (col.ColumnName == "registration name" || col.ColumnName == "registrationname")
                {
                    col.ColumnName = "registrationname";
                }
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                btnCompare.Enabled = false;
                btnExport.Enabled = false;
                dgvCompare.Visible = false;
                btnNewExport.Enabled = false;
                dgvNewCompare.Visible = false;
                strNewMessage = new StringBuilder(string.Empty);

                CreateOutputTable();
                CreateNewDataOutputTable();

                if (dataSource.Tables.Count > 0 && dataBioTrack.Tables.Count > 0)
                {
                    if (dataSource.Tables[0].Rows.Count > 0 && dataBioTrack.Tables[0].Rows.Count > 0)
                    {
                        if (dataSource.Tables[0].Columns.Contains("tattoo") && dataSource.Tables[0].Columns.Contains("birthdate")
                                    && dataSource.Tables[0].Columns.Contains("damtattoo") && dataSource.Tables[0].Columns.Contains("siretattoo")
                                    // && dataSource.Tables[0].Columns.Contains("donortattoo")
                                    && dataSource.Tables[0].Columns.Contains("registrationid") && dataSource.Tables[0].Columns.Contains("registrationname")
                                    && dataBioTrack.Tables[0].Columns.Contains("tattoo") && dataBioTrack.Tables[0].Columns.Contains("birthdate")
                                    && dataBioTrack.Tables[0].Columns.Contains("damtattoo") && dataBioTrack.Tables[0].Columns.Contains("siretattoo")
                                    && dataBioTrack.Tables[0].Columns.Contains("donortattoo")
                                    && dataBioTrack.Tables[0].Columns.Contains("registrationid") && dataBioTrack.Tables[0].Columns.Contains("registrationname"))
                        {
                            for (int iCount = 0; iCount < dataSource.Tables[0].Rows.Count - 1; iCount++)
                            {
                                DataRow[] arrRow = dataBioTrack.Tables[0].Select("tattoo='" + Convert.ToString(dataSource.Tables[0].Rows[iCount]["tattoo"]) + "' and birthdate='" + Convert.ToString(dataSource.Tables[0].Rows[iCount]["birthdate"]) + "'");

                                strMessage = strMessage = new StringBuilder(string.Empty);

                                iCompare++;
                                if (arrRow.Length > 0)
                                {
                                    if (Convert.ToString(dataSource.Tables[0].Rows[iCount]["siretattoo"]) != Convert.ToString(arrRow[0]["siretattoo"]))
                                    {
                                        strMessage.Append("Sire Tattoo Mismatch. ");
                                    }

                                    if (Convert.ToString(dataSource.Tables[0].Rows[iCount]["damtattoo"]) != Convert.ToString(arrRow[0]["damtattoo"]))
                                    {
                                        strMessage.Append("Dam Tattoo Mismatch. ");
                                    }

                                    if (dataSource.Tables[0].Columns.Contains("donortattoo"))
                                    {
                                        if (Convert.ToString(dataSource.Tables[0].Rows[iCount]["donortattoo"]) != Convert.ToString(arrRow[0]["donortattoo"]))
                                        {
                                            strMessage.Append("Donor Tattoo Mismatch. ");
                                        }
                                    }

                                    if (Convert.ToString(dataSource.Tables[0].Rows[iCount]["registrationid"]) != Convert.ToString(arrRow[0]["registrationid"]))
                                    {
                                        strMessage.Append("Registration Id Mismatch. ");
                                    }

                                    if (Convert.ToString(dataSource.Tables[0].Rows[iCount]["registrationname"]) != Convert.ToString(arrRow[0]["registrationname"]))
                                    {
                                        strMessage.Append("Registration Name Mismatch. ");
                                    }

                                    if (strMessage.Length > 0)
                                    {
                                        drOutputRow = dtOutputTable.NewRow();
                                        drOutputRow["Message"] = strMessage.ToString();
                                        drOutputRow["tattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["tattoo"]);
                                        drOutputRow["birthdate"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["birthdate"]);
                                        drOutputRow["siretattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["siretattoo"]);
                                        drOutputRow["damtattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["damtattoo"]);
                                        drOutputRow["btsiretattoo"] = Convert.ToString(arrRow[0]["siretattoo"]);
                                        drOutputRow["btdamtattoo"] = Convert.ToString(arrRow[0]["damtattoo"]);
                                        if (dataSource.Tables[0].Columns.Contains("donortattoo"))
                                        {
                                            drOutputRow["donortattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["donortattoo"]);
                                        }

                                        drOutputRow["btdonortattoo"] = Convert.ToString(arrRow[0]["donortattoo"]);

                                        drOutputRow["registrationid"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["registrationid"]);
                                        drOutputRow["registrationname"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["registrationname"]);
                                        drOutputRow["btregistrationid"] = Convert.ToString(arrRow[0]["registrationid"]);
                                        drOutputRow["btregistrationname"] = Convert.ToString(arrRow[0]["registrationname"]);

                                        dtOutputTable.Rows.Add(drOutputRow);
                                        dtOutputTable.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    strNewMessage.Append("New Data Available");
                                    drOutputRow = dtNewDataOutputTable.NewRow();


                                    drOutputRow["currentownerid"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Current Owner Member ID"]); 
                                    drOutputRow["currentowner"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Current Owner Name and Address"]);
                                    drOutputRow["calvingseason"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Calving Season"]);
                                    drOutputRow["eartag"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Eag Tag"]);
                                    drOutputRow["biotattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["BIO Tattoo"]);
                                    drOutputRow["location"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Location"]);
                                    drOutputRow["birthdate"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["birthdate"]);
                                    drOutputRow["bornthroughai"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born Through AI"]);
                                    drOutputRow["colour"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Colour"]);
                                    drOutputRow["sex"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Sex"]);
                                    drOutputRow["calvingease"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Calving Ease"]);
                                    drOutputRow["birthweight"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Birth Weight"]);
                                    drOutputRow["bornas"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "S" || Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "Single" ? "Single" : Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "T" || Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "Twin" ? "Twin" : Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "TR" || Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "Triplet" ? "Triplet" : Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "QA" || Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "Quadruplet" ? "Quadruplet" : Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "ET" || Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]) == "EmbryoTransfer" ? "Embryo Transfer" : "ERROR"; //Convert.ToString(dataSource.Tables[0].Rows[iCount]["Born As"]);
                                    drOutputRow["raisedas"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Raised As"]);
                                    drOutputRow["horns"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Horn"]) == "H" ? "Horns" : Convert.ToString(dataSource.Tables[0].Rows[iCount]["Horn"]) == "P" ? "Polled" : Convert.ToString(dataSource.Tables[0].Rows[iCount]["Horn"]) == "S"? "Scoured" : "ERROR";
                                    drOutputRow["registrationid"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Registration ID"]);
                                    drOutputRow["registrationname"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Registration Name"]);
                                    drOutputRow["breed1"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Breed 1"]);
                                    drOutputRow["composition1"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 1"]);
                                    drOutputRow["breed2"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Breed 2"]);
                                    drOutputRow["composition2"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 2"]);
                                    drOutputRow["breed3"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Breed 3"]);
                                    drOutputRow["composition3"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 3"]);
                                    drOutputRow["breed4"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Breed 4"]);
                                    drOutputRow["composition4"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 4"]);
                                    double comp1 = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 1"]) == "" ? 0 : Convert.ToDouble(dataSource.Tables[0].Rows[iCount]["Comp 1"]);
                                    double comp2 = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 2"]) == "" ? 0 : Convert.ToDouble(dataSource.Tables[0].Rows[iCount]["Comp 2"]);
                                    double comp3 = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 3"]) == "" ? 0 : Convert.ToDouble(dataSource.Tables[0].Rows[iCount]["Comp 3"]);
                                    double comp4 = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Comp 4"]) == "" ? 0 : Convert.ToDouble(dataSource.Tables[0].Rows[iCount]["Comp 4"]);
                                    drOutputRow["totalbreedcomp"] = Convert.ToString(comp1 + comp2 + comp3 + comp4); 
                                    drOutputRow["weaningdate"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Weaning Date"]);
                                    drOutputRow["weaningweight"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["Weaning Weight"]);
                                    drOutputRow["myostatingene"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["MyOstatin Gene"]);
                                    drOutputRow["tattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["tattoo"]);
                                    drOutputRow["siretattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["siretattoo"]);
                                    drOutputRow["damtattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["damtattoo"]);
                                    if (dataSource.Tables[0].Columns.Contains("donortattoo"))
                                    {
                                        drOutputRow["donortattoo"] = Convert.ToString(dataSource.Tables[0].Rows[iCount]["donortattoo"]);
                                    }

                                    dtNewDataOutputTable.Rows.Add(drOutputRow);
                                    dtNewDataOutputTable.AcceptChanges();
                                }
                            }
                        }
                    }
                }

                //MessageBox.Show(Convert.ToString(iCompare));

                if (dtOutputTable.Rows.Count > 0)
                {
                    dgvCompare.DataSource = dtOutputTable;

                    dgvCompare.Height = this.Height - 250 - dgvCompare.Location.Y;
                    dgvCompare.Width = this.Width - 50 - dgvCompare.Location.X;
                    dgvCompare.Show();
                    dgvCompare.Visible = true;  
                    btnExport.Enabled = true;
                }

                if (dtNewDataOutputTable.Rows.Count > 0)
                {
                    dgvNewCompare.DataSource = dtNewDataOutputTable;

                    dgvNewCompare.Location = new Point(dgvCompare.Location.X, dgvCompare.Location.Y + dgvCompare.Height + 75);
                    btnNewExport.Location = new Point(dgvNewCompare.Location.X, dgvNewCompare.Location.Y - 30);
                    dgvNewCompare.Height = dgvCompare.Height;
                    dgvNewCompare.Width = this.Width - 50 - dgvNewCompare.Location.X;
                    
                    dgvNewCompare.Show();
                    dgvNewCompare.Visible = true;
                    btnNewExport.Enabled = true;
                }

                btnCompare.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                ex.ToString();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            StringBuilder data = ConvertDataTableToCsvFile(dtOutputTable);
            sfdOutput.DefaultExt = "csv";
            sfdOutput.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (sfdOutput.ShowDialog() == DialogResult.OK)
            {
                //string strFilename = sfdOutput.FileName;
                SaveData(data, sfdOutput.FileName);
            }   
        }

        //This method saves the data to the csv file. 
        public void SaveData(StringBuilder data, string filePath)
        {
            using (StreamWriter objWriter = new StreamWriter(filePath))
            {
                objWriter.WriteLine(data);
            }
        }

        //This method convertrs the DataTable to Csv (in the form of StringBuilder instance).
        public StringBuilder ConvertDataTableToCsvFile(DataTable dtData)
        {
            StringBuilder data = new StringBuilder();

            //Taking the column names.
            for (int column = 0; column < dtData.Columns.Count; column++)
            {
                //Making sure that end of the line, shoould not have comma delimiter.
                if (column == dtData.Columns.Count - 1)
                    data.Append(dtData.Columns[column].ColumnName.ToString().Replace(",", ";"));
                else
                    data.Append(dtData.Columns[column].ColumnName.ToString().Replace(",", ";") + ',');
            }

            data.Append(Environment.NewLine);//New line after appending columns.

            for (int row = 0; row < dtData.Rows.Count; row++)
            {
                for (int column = 0; column < dtData.Columns.Count; column++)
                {
                    ////Making sure that end of the line, shoould not have comma delimiter.
                    if (column == dtData.Columns.Count - 1)
                        data.Append(dtData.Rows[row][column].ToString().Replace(",", ";"));
                    else
                        data.Append(dtData.Rows[row][column].ToString().Replace(",", ";") + ',');
                }

                //Making sure that end of the file, should not have a new line.
                if (row != dtData.Rows.Count - 1)
                    data.Append(Environment.NewLine);
            }
            return data;
        }

        private void ComparePedigree_Resize(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            dgvCompare.Height = this.Height - 250 - dgvCompare.Location.Y;
            dgvCompare.Width = this.Width - 50 - dgvCompare.Location.X;

            dgvNewCompare.Location = new Point(dgvCompare.Location.X, dgvCompare.Location.Y + dgvCompare.Height + 75);
            btnNewExport.Location = new Point(dgvNewCompare.Location.X, dgvNewCompare.Location.Y - 30);
            dgvNewCompare.Height = dgvCompare.Height;
            dgvNewCompare.Width = this.Width - 50 - dgvNewCompare.Location.X;
        }

        private void btnNewExport_Click(object sender, EventArgs e)
        {
            StringBuilder data = ConvertDataTableToCsvFile(dtNewDataOutputTable);
            sfdOutput.DefaultExt = "csv";
            sfdOutput.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (sfdOutput.ShowDialog() == DialogResult.OK)
            {
                //string strFilename = sfdOutput.FileName;
                SaveData(data, sfdOutput.FileName);
            }
        }
    }
}
