using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace R4Analyzer
{
    public partial class frmMain : Form
    {
        private string strMDBFileName;
        private string strLocation;
        private OleDbConnection OleConnection;
        private OleDbCommand OleCmd;
        private OleDbDataReader OleReader;
        private string strADOConnectionString;
        
        private string strSQLiteDB;
        private SQLiteConnection sqliteCon;
        private SQLiteCommand sqliteCmd;
        private SQLiteDataReader sqliteReader;

        private OpenFileDialog oFileDialog;
        private ToolTip ttFileName;
        private ToolTip ttRecording;
        private ToolTip ttInj;
        private ToolTip ttSummary;
        private ToolTip ttRound;
        private ToolTip ttRaw;

        public frmMain()
        {
            InitializeComponent();
            this.strLocation = Directory.GetCurrentDirectory();
            this.oFileDialog = new OpenFileDialog();

            this.strMDBFileName = "";
            this.strADOConnectionString = "";
            this.OleConnection = new OleDbConnection();
            this.OleCmd = new OleDbCommand();
            
            this.setupToolTips();
            this.SQLiteInit();
        }

        private void setupToolTips()
        {
            this.ttFileName = new ToolTip();
            this.ttRecording = new ToolTip();
            this.ttInj = new ToolTip();
            this.ttSummary = new ToolTip();
            this.ttRound = new ToolTip();
            this.ttRaw = new ToolTip();

            this.ttFileName.IsBalloon = true;
            this.ttFileName.InitialDelay = 0;
            this.ttFileName.ShowAlways = true;
            this.ttFileName.SetToolTip(tbR4File, "Split Second R4 file with recordings");

            this.ttRecording.IsBalloon = true;
            this.ttRecording.InitialDelay = 0;
            this.ttRecording.ShowAlways = true;
            this.ttRecording.SetToolTip(cbxSessions, lblRecordingHelp.Text);

            this.ttInj.IsBalloon = true;
            this.ttInj.InitialDelay = 0;
            this.ttInj.ShowAlways = true;
            this.ttInj.SetToolTip(this.chkInjAActive, "Only export records where Injector/Map active");
            this.ttInj.SetToolTip(this.chkInjBActive, "Only export records where Injector/Map active");

            this.ttSummary.IsBalloon = true;
            this.ttSummary.InitialDelay = 0;
            this.ttSummary.ShowAlways = true;
            this.ttSummary.SetToolTip(this.chkSummary, "Summarizes and counts the occurences of the output fields");

            this.ttRound.IsBalloon = true;
            this.ttRound.InitialDelay = 0;
            this.ttRound.ShowAlways = true;            
            this.ttRound.SetToolTip(this.rbRoundRPM, "Rounds RPM to nearest 500 rpm and boost to nearest 0.5 psi");

            this.ttRaw.IsBalloon = true;
            this.ttRaw.InitialDelay = 0;
            this.ttRaw.ShowAlways = true;
            this.ttRaw.SetToolTip(this.chkExportRaw, "Exports R4 data with no conversions");
        }

        private void SQLiteInit()
        {
            this.strSQLiteDB = "r4analyzer.db";

            try { 
                this.sqliteCon = new SQLiteConnection("Data Source=" + this.strLocation + "\\" + this.strSQLiteDB);
                this.sqliteCon.Open();
                this.sqliteCmd = new SQLiteCommand(this.sqliteCon);

                this.toolStripStatusLabel.Text = "Analyzer database initialized";
            }
              catch (Exception ex)
              {
                this.errorToMessageBox(ex);
              }
        }

        private string SQLiteExecuteScalar(string pSQLQuery)
        {
            try
            {
                sqliteCmd.CommandText = pSQLQuery;
                return this.sqliteCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                this.errorToMessageBox(ex);
                return null;
            }
        }

        private void SQLiteExecuteNonQuery(string pSQLQuery)
        {
            try
            {
                sqliteCmd.CommandText = pSQLQuery;
                sqliteCmd.ExecuteNonQuery();
            } 
            catch (Exception ex)
            {
                this.errorToMessageBox(ex);
            }
        }

        private SQLiteDataReader SQLiteExecuteQuery(string pSQLQuery)
        {
            try
            {
                sqliteCmd.CommandText = pSQLQuery;
                return sqliteCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                this.errorToMessageBox(ex);
                return null;
            }
        }

        public DataTable SQLiteGetDataTable(string pSQLQuery)
        {
            DataTable dataTable = new DataTable();

            try
            {
                this.sqliteCmd.CommandText = pSQLQuery;
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(this.sqliteCmd.CommandText, this.sqliteCon);
                dataAdapter.Fill(dataTable);
                return dataTable;

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return null;
            }
        }

        private void SQLiteZap(string pTableName)
        {
            this.SQLiteExecuteNonQuery("delete from " + pTableName);
            this.SQLiteCompactDB();
        }
 
        private void SQLiteCompactDB()
        {
            this.SQLiteExecuteNonQuery("VACUUM");
        }
 
        private int ExportRaw(string pFileName)
        {
            string strWhere = "";
            int iLines = 0;

            if (this.cbxSessions.Text != "All")
            {
                strWhere = " WHERE recording_number = " + this.cbxSessions.Text ;
            }
            strWhere += ";";

            this.OleCmd.CommandText = "SELECT * FROM aquisition_data" + strWhere ;
            this.OleReader = OleCmd.ExecuteReader();

            iLines = this.SaveToCSV(this.OleReader, pFileName, true,",");
            this.OleReader.Close();

            return iLines;
        }

        private int ExportConverted(string pFileName)
        {
            string strWhereClause = "WHERE rpm > 0";
            string strOrderBy = "";
            string strGroupBy = "";
            string strRPM = "rpm";
            string strPressure;
            string strCount = "";
            int iLines = 0;

            
            if (chkInjAActive.Checked || chkInjBActive.Checked || cbxSessions.Text != "All") { strWhereClause += " AND "; }
            if (chkInjAActive.Checked) { strWhereClause += "inja_time > 0"; }
            if (chkInjAActive.Checked && chkInjBActive.Checked) { strWhereClause += " AND "; }
            if (chkInjBActive.Checked) { strWhereClause += "injb_time > 0"; }
            if (cbxSessions.Text != "All" && (chkInjAActive.Checked || chkInjBActive.Checked)) { strWhereClause += " AND "; }
            if (cbxSessions.Text != "All") { strWhereClause += "recording_number = " + cbxSessions.Text; }
            if (!String.IsNullOrEmpty(cbxSort1.Text)) { strOrderBy = "ORDER BY " + cbxSort1.Text; }
            if (!String.IsNullOrEmpty(cbxSort1.Text) && !String.IsNullOrEmpty(cbxSort2.Text)) { strOrderBy += ", " + cbxSort2.Text; }
            if (rbRoundRPM.Checked) 
            {
                strRPM = "(ROUND(ROUND((rpm/1000.0),1)*2)/2)*1000";
                strPressure = "CASE WHEN pressure < 10000 THEN ROUND(((pressure - 10000)*2.036)/1000,1) ELSE ROUND(round((pressure - 10000)/1000.0,1)*2)/2 END";
            }
            else 
            {
                strPressure = "CASE WHEN pressure< 10000 THEN ROUND((pressure - 10000)*2.036/1000,1) ELSE ROUND((pressure - 10000)/1000.0, 1) END";  

            }
            if (chkSummary.Checked) 
            {
                strCount = ", COUNT(*) as Hits";
                strGroupBy = "GROUP BY 1,2,3,4";
            }

            string strSQLQuery = string.Format(@"SELECT 
                                                    {0} as tmpRPM,
                                                    {1} Boost,
                                                    inja_time/10.0 AS InjA_Time,
                                                    injb_time/10.0 AS InjB_Time,
                                                    ROUND(((aux_in_c/255.0)*10+10),1) as AFR
                                                    {2}    
                                                FROM Sessions
                                                {3}
                                                {4}
                                                {5}
                                                ", strRPM, strPressure, strCount, strWhereClause, strGroupBy, strOrderBy);

            if (chkSummary.Checked) { strSQLQuery = "SELECT tmpRPM as RPM, Boost, InjA_Time, InjB_Time, AFR, Hits from (" + strSQLQuery + ")"; }
            else { strSQLQuery = "SELECT tmpRPM as RPM, Boost, InjA_Time, InjB_Time, AFR from (" + strSQLQuery + ")"; }

            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"sql.txt", true);
            //file.WriteLine(strSQLQuery + "\n\n");
            //file.Flush();
            //file.Close();

            this.sqliteCmd.CommandText = strSQLQuery;
            this.sqliteReader = sqliteCmd.ExecuteReader();

            iLines = this.SaveToCSV(this.sqliteReader, pFileName, true, ",");
            this.sqliteReader.Close();
            return iLines;
            //return 0;
        }

        private int SaveToCSV(IDataReader pReader, string pFileName, bool pIncludeHeadersAsFirstRow, string pSeparator)
        {

            StreamWriter outputFile = new StreamWriter(pFileName, false);
            int iLines = 0;
            string strBuffer = "";

            if (pIncludeHeadersAsFirstRow)
            {
                for (int index = 0; index < pReader.FieldCount; index++)
                {
                    if (pReader.GetName(index) != null) { strBuffer += pReader.GetName(index); }
                    if (index < pReader.FieldCount - 1) { strBuffer += pSeparator; }
                }
                outputFile.WriteLine(strBuffer);
                strBuffer = "";
            }

            while (pReader.Read())
            {
                for (int index = 0; index < pReader.FieldCount - 1; index++)
                {
                    if (!pReader.IsDBNull(index))
                    {
                        string value = pReader.GetValue(index).ToString();
                        if (pReader.GetFieldType(index) == typeof(String))
                        {
                            //If double quotes are used in value, ensure each are replaced but 2.
                            if (value.IndexOf("\"") >= 0) { value = value.Replace("\"", "\"\""); }

                            //If separtor are is in value, ensure it is put in double quotes.
                            if (value.IndexOf(pSeparator) >= 0) { value = "\"" + value + "\""; }
                        }
                        strBuffer += value;
                    }

                    if (index < pReader.FieldCount - 1) { strBuffer += pSeparator; }
                }

                if (!pReader.IsDBNull(pReader.FieldCount - 1)) { strBuffer += pReader.GetValue(pReader.FieldCount - 1).ToString().Replace(pSeparator, " "); }

                outputFile.WriteLine(strBuffer);
                strBuffer = "";
                iLines++;
            }
            outputFile.Close();
            return iLines;
            }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string message = "The following files were created:\n";
            string caption = "Export Complete";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            string strFileName = "";
            int iLines = 0;

            
            if (chkExportRaw.Checked)
            {
                strFileName = this.strMDBFileName + ".Session - " + this.cbxSessions.Text + ".raw.csv";
                iLines = this.ExportRaw(strFileName);
                message += " - " + strFileName + "\n" + iLines.ToString() + " records written";
            }
            if (chkExportConverted.Checked)
            {
                strFileName = this.strMDBFileName + ".Session - " + this.cbxSessions.Text + ".converted.csv";
                iLines = this.ExportConverted(strFileName);
                message += " - " + strFileName + "\n" + iLines.ToString() + " records written";
            }
            MessageBox.Show(message, caption, buttons);
        }

        private void ImportSessions()
        {
            this.Cursor = Cursors.WaitCursor;
            this.UseWaitCursor = true;
            this.gbActions.UseWaitCursor = true;

            string strLastSession = "";
            this.OleCmd = this.OleConnection.CreateCommand();
            this.OleCmd.CommandText = "SELECT * FROM capture_data;";
            this.OleReader = OleCmd.ExecuteReader();

            while (this.OleReader.Read())
            {
                cbxSessions.Items.Add(this.OleReader[0].ToString());
                strLastSession = this.OleReader[0].ToString();
            }

            this.cbxSessions.Items.Add("All");
            this.cbxSessions.Text = strLastSession;

            this.OleReader.Close();
            this.Cursor = Cursors.Default;
        }
        private void btnMDB_Click(object sender, EventArgs e)
        {
            this.oFileDialog.Filter = "All files (*.mdb)|*.mdb";
            this.oFileDialog.ShowDialog();
            this.strMDBFileName = this.oFileDialog.FileName;
            this.tbR4File.Text = this.strMDBFileName;
            string strShortMDBFileName = Path.GetFileName(this.strMDBFileName);

            Application.UseWaitCursor = true;
            this.cbxSessions.Items.Clear();

            if (!this.strMDBFileName.Equals(""))
            {
                this.strADOConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                       "Data Source= '" + this.strMDBFileName + "';";
                try
                {
                    this.OleConnection.ConnectionString = this.strADOConnectionString;
                    this.OleConnection.Open();
                }
                catch (Exception ex)
                {
                    this.errorToMessageBox(ex);
                }
                this.ImportSessions();
                this.ImportSessionData();
                this.OleConnection.Close();
            }
            Application.UseWaitCursor = false;
        }

        private void ImportSessionData()
        {
            int iCounter = 0;

            this.OleCmd = this.OleConnection.CreateCommand();
            this.OleCmd.CommandText = "SELECT * FROM aquisition_data ;";
            this.OleReader = OleCmd.ExecuteReader();

            this.SQLiteZap("Sessions");

            string strPreparedStatement =
                 @"INSERT into SESSIONS (rpm, pressure, inja_time, injb_time,
                     aux_in_a, aux_in_b, aux_in_c, aux_in_d, count, recording_number, sample_number)
                    VALUES 
                    (@rpm, @pressure, @inja_time, @injb_time,
                     @aux_in_a, @aux_in_b, @aux_in_c, @aux_in_d, @count, @recording_number, @sample_number)";

            this.sqliteCmd.CommandText = strPreparedStatement;
            this.sqliteCmd.Parameters.Add("@rpm", DbType.Int32);
            this.sqliteCmd.Parameters.Add("@pressure", DbType.Decimal);
            this.sqliteCmd.Parameters.Add("@inja_time", DbType.Decimal);
            this.sqliteCmd.Parameters.Add("@injb_time", DbType.Decimal);
            this.sqliteCmd.Parameters.Add("@aux_in_a", DbType.Int32);
            this.sqliteCmd.Parameters.Add("@aux_in_b", DbType.Int32);
            this.sqliteCmd.Parameters.Add("@aux_in_c", DbType.Int32);
            this.sqliteCmd.Parameters.Add("@aux_in_d", DbType.Int32);
            this.sqliteCmd.Parameters.Add("@count", DbType.Int32);
            this.sqliteCmd.Parameters.Add("@recording_number", DbType.Int32);
            this.sqliteCmd.Parameters.Add("@sample_number", DbType.Int32);

            this.sqliteCmd.Prepare();

            SQLiteTransaction transaction = this.sqliteCon.BeginTransaction();
            this.sqliteCmd.Transaction = transaction;

            while (this.OleReader.Read())
            {
                iCounter++;
                for (var i = 0; i < 11; i++)
                {
                    this.sqliteCmd.Parameters[i].Value = this.OleReader[i].ToString();
                }

                this.sqliteCmd.ExecuteNonQuery();

                if (iCounter % 10000 == 0)
                {
                    this.toolStripStatusLabel.Text = "Imported " + iCounter.ToString() + " records.";
                    this.Refresh();
                }
            }
            this.toolStripStatusLabel.Text = "Imported " + iCounter.ToString() + " records.";
            transaction.Commit();
            this.OleReader.Close();
            this.btnRun.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbxExportRaw_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkExportRaw.Checked)  { this.chkExportConverted.Checked = false; }
        }

        private void chkExportConverted_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkExportConverted.Checked) { this.chkExportRaw.Checked = false; }
        }

        private void chkAllRecords_CheckedChanged(object sender, EventArgs e)
        {
            this.chkInjAActive.Checked = false;
            this.chkInjBActive.Checked = false;
        }

        private void chkMapAActive_CheckedChanged(object sender, EventArgs e)
        {
            this.chkAllRecords.Checked = false;
        }

        private void chkMapBActive_CheckedChanged(object sender, EventArgs e)
        {
            this.chkAllRecords.Checked = false;
        }

        private void errorToMessageBox(Exception pEx)
        {
            string message = pEx.Message;
            string caption = "Application Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private void cbxSort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSort1.Text != "") { cbxSort2.Enabled = true; } 
            else { cbxSort2.Enabled = false; }
        }

        private void rbRoundRPM_CheckedChanged(object sender, EventArgs e)
        {
            chkSummary.Enabled = true;
        }

        private void rbNoRound_CheckedChanged(object sender, EventArgs e)
        {
            chkSummary.Checked = false;
            chkSummary.Enabled = false;
        }

    }
}
