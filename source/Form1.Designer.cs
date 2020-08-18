namespace R4Analyzer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbR4File = new System.Windows.Forms.TextBox();
            this.btnMDB = new System.Windows.Forms.Button();
            this.cbxSessions = new System.Windows.Forms.ComboBox();
            this.lblMDBFile = new System.Windows.Forms.Label();
            this.lblR4Recording = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbxReUseMap = new System.Windows.Forms.CheckBox();
            this.gbSplitSecond = new System.Windows.Forms.GroupBox();
            this.lblRecordingHelp = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.chkSummary = new System.Windows.Forms.CheckBox();
            this.chkAllRecords = new System.Windows.Forms.CheckBox();
            this.rbRoundRPM = new System.Windows.Forms.RadioButton();
            this.rbNoRound = new System.Windows.Forms.RadioButton();
            this.lblBy = new System.Windows.Forms.Label();
            this.cbxSort2 = new System.Windows.Forms.ComboBox();
            this.lblThen = new System.Windows.Forms.Label();
            this.lblSort = new System.Windows.Forms.Label();
            this.chkInjBActive = new System.Windows.Forms.CheckBox();
            this.chkInjAActive = new System.Windows.Forms.CheckBox();
            this.cbxSort1 = new System.Windows.Forms.ComboBox();
            this.chkExportConverted = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.chkExportRaw = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStripActions = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSplitSecond.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStripActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbR4File
            // 
            this.tbR4File.Location = new System.Drawing.Point(9, 35);
            this.tbR4File.Name = "tbR4File";
            this.tbR4File.ReadOnly = true;
            this.tbR4File.Size = new System.Drawing.Size(582, 20);
            this.tbR4File.TabIndex = 0;
            // 
            // btnMDB
            // 
            this.btnMDB.Location = new System.Drawing.Point(597, 33);
            this.btnMDB.Name = "btnMDB";
            this.btnMDB.Size = new System.Drawing.Size(56, 23);
            this.btnMDB.TabIndex = 1;
            this.btnMDB.Text = "Open";
            this.btnMDB.UseVisualStyleBackColor = true;
            this.btnMDB.Click += new System.EventHandler(this.btnMDB_Click);
            // 
            // cbxSessions
            // 
            this.cbxSessions.FormattingEnabled = true;
            this.cbxSessions.Location = new System.Drawing.Point(9, 74);
            this.cbxSessions.Name = "cbxSessions";
            this.cbxSessions.Size = new System.Drawing.Size(121, 21);
            this.cbxSessions.TabIndex = 2;
            // 
            // lblMDBFile
            // 
            this.lblMDBFile.AutoSize = true;
            this.lblMDBFile.Location = new System.Drawing.Point(6, 19);
            this.lblMDBFile.Name = "lblMDBFile";
            this.lblMDBFile.Size = new System.Drawing.Size(92, 13);
            this.lblMDBFile.TabIndex = 3;
            this.lblMDBFile.Text = "Open R4 .mdb file";
            // 
            // lblR4Recording
            // 
            this.lblR4Recording.AutoSize = true;
            this.lblR4Recording.Location = new System.Drawing.Point(6, 58);
            this.lblR4Recording.Name = "lblR4Recording";
            this.lblR4Recording.Size = new System.Drawing.Size(111, 13);
            this.lblR4Recording.TabIndex = 4;
            this.lblR4Recording.Text = "Select R4 recording #";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(611, 260);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbxReUseMap
            // 
            this.cbxReUseMap.AutoSize = true;
            this.cbxReUseMap.Location = new System.Drawing.Point(23, 176);
            this.cbxReUseMap.Name = "cbxReUseMap";
            this.cbxReUseMap.Size = new System.Drawing.Size(174, 17);
            this.cbxReUseMap.TabIndex = 6;
            this.cbxReUseMap.Text = "Import updated target AFR map";
            this.cbxReUseMap.UseVisualStyleBackColor = true;
            // 
            // gbSplitSecond
            // 
            this.gbSplitSecond.Controls.Add(this.lblRecordingHelp);
            this.gbSplitSecond.Controls.Add(this.lblR4Recording);
            this.gbSplitSecond.Controls.Add(this.lblMDBFile);
            this.gbSplitSecond.Controls.Add(this.cbxSessions);
            this.gbSplitSecond.Controls.Add(this.btnMDB);
            this.gbSplitSecond.Controls.Add(this.tbR4File);
            this.gbSplitSecond.Location = new System.Drawing.Point(14, 13);
            this.gbSplitSecond.Name = "gbSplitSecond";
            this.gbSplitSecond.Size = new System.Drawing.Size(665, 121);
            this.gbSplitSecond.TabIndex = 7;
            this.gbSplitSecond.TabStop = false;
            this.gbSplitSecond.Text = "Split Second Data";
            // 
            // lblRecordingHelp
            // 
            this.lblRecordingHelp.AutoSize = true;
            this.lblRecordingHelp.Location = new System.Drawing.Point(136, 74);
            this.lblRecordingHelp.Name = "lblRecordingHelp";
            this.lblRecordingHelp.Size = new System.Drawing.Size(441, 39);
            this.lblRecordingHelp.TabIndex = 5;
            this.lblRecordingHelp.Text = resources.GetString("lblRecordingHelp.Text");
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.chkSummary);
            this.gbActions.Controls.Add(this.chkAllRecords);
            this.gbActions.Controls.Add(this.rbRoundRPM);
            this.gbActions.Controls.Add(this.rbNoRound);
            this.gbActions.Controls.Add(this.lblBy);
            this.gbActions.Controls.Add(this.cbxSort2);
            this.gbActions.Controls.Add(this.lblThen);
            this.gbActions.Controls.Add(this.lblSort);
            this.gbActions.Controls.Add(this.chkInjBActive);
            this.gbActions.Controls.Add(this.chkInjAActive);
            this.gbActions.Controls.Add(this.cbxSort1);
            this.gbActions.Controls.Add(this.chkExportConverted);
            this.gbActions.Location = new System.Drawing.Point(16, 141);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(475, 142);
            this.gbActions.TabIndex = 10;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Conversion";
            // 
            // chkSummary
            // 
            this.chkSummary.AutoSize = true;
            this.chkSummary.Enabled = false;
            this.chkSummary.Location = new System.Drawing.Point(7, 115);
            this.chkSummary.Name = "chkSummary";
            this.chkSummary.Size = new System.Drawing.Size(134, 17);
            this.chkSummary.TabIndex = 24;
            this.chkSummary.Text = "Summarise with counts";
            this.chkSummary.UseVisualStyleBackColor = true;
            // 
            // chkAllRecords
            // 
            this.chkAllRecords.AutoSize = true;
            this.chkAllRecords.Checked = true;
            this.chkAllRecords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllRecords.Location = new System.Drawing.Point(23, 82);
            this.chkAllRecords.Name = "chkAllRecords";
            this.chkAllRecords.Size = new System.Drawing.Size(75, 17);
            this.chkAllRecords.TabIndex = 23;
            this.chkAllRecords.Text = "All records";
            this.chkAllRecords.UseVisualStyleBackColor = true;
            this.chkAllRecords.CheckedChanged += new System.EventHandler(this.chkAllRecords_CheckedChanged);
            // 
            // rbRoundRPM
            // 
            this.rbRoundRPM.AutoSize = true;
            this.rbRoundRPM.Location = new System.Drawing.Point(242, 94);
            this.rbRoundRPM.Name = "rbRoundRPM";
            this.rbRoundRPM.Size = new System.Drawing.Size(135, 17);
            this.rbRoundRPM.TabIndex = 22;
            this.rbRoundRPM.TabStop = true;
            this.rbRoundRPM.Text = "Round RPM and Boost";
            this.rbRoundRPM.UseVisualStyleBackColor = true;
            this.rbRoundRPM.CheckedChanged += new System.EventHandler(this.rbRoundRPM_CheckedChanged);
            // 
            // rbNoRound
            // 
            this.rbNoRound.AutoSize = true;
            this.rbNoRound.Checked = true;
            this.rbNoRound.Location = new System.Drawing.Point(242, 115);
            this.rbNoRound.Name = "rbNoRound";
            this.rbNoRound.Size = new System.Drawing.Size(157, 17);
            this.rbNoRound.TabIndex = 21;
            this.rbNoRound.TabStop = true;
            this.rbNoRound.Text = "Don\'t round RPM and boost";
            this.rbNoRound.UseVisualStyleBackColor = true;
            this.rbNoRound.CheckedChanged += new System.EventHandler(this.rbNoRound_CheckedChanged);
            // 
            // lblBy
            // 
            this.lblBy.AutoSize = true;
            this.lblBy.Location = new System.Drawing.Point(239, 36);
            this.lblBy.Name = "lblBy";
            this.lblBy.Size = new System.Drawing.Size(19, 13);
            this.lblBy.TabIndex = 20;
            this.lblBy.Text = "By";
            // 
            // cbxSort2
            // 
            this.cbxSort2.DisplayMember = "1,2,3";
            this.cbxSort2.Enabled = false;
            this.cbxSort2.FormattingEnabled = true;
            this.cbxSort2.Items.AddRange(new object[] {
            "",
            "RPM",
            "Pressure",
            "InjA_Time",
            "InjB_Time",
            "AFR"});
            this.cbxSort2.Location = new System.Drawing.Point(277, 57);
            this.cbxSort2.Name = "cbxSort2";
            this.cbxSort2.Size = new System.Drawing.Size(121, 21);
            this.cbxSort2.TabIndex = 19;
            this.cbxSort2.ValueMember = "1,2,3";
            // 
            // lblThen
            // 
            this.lblThen.AutoSize = true;
            this.lblThen.Location = new System.Drawing.Point(239, 60);
            this.lblThen.Name = "lblThen";
            this.lblThen.Size = new System.Drawing.Size(32, 13);
            this.lblThen.TabIndex = 18;
            this.lblThen.Text = "Then";
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSort.Location = new System.Drawing.Point(231, 17);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(30, 13);
            this.lblSort.TabIndex = 17;
            this.lblSort.Text = "Sort";
            // 
            // chkInjBActive
            // 
            this.chkInjBActive.AutoSize = true;
            this.chkInjBActive.Location = new System.Drawing.Point(24, 62);
            this.chkInjBActive.Name = "chkInjBActive";
            this.chkInjBActive.Size = new System.Drawing.Size(112, 17);
            this.chkInjBActive.TabIndex = 16;
            this.chkInjBActive.Text = "When Inj B Active";
            this.chkInjBActive.UseVisualStyleBackColor = true;
            this.chkInjBActive.CheckedChanged += new System.EventHandler(this.chkMapBActive_CheckedChanged);
            // 
            // chkInjAActive
            // 
            this.chkInjAActive.AutoSize = true;
            this.chkInjAActive.Location = new System.Drawing.Point(24, 40);
            this.chkInjAActive.Name = "chkInjAActive";
            this.chkInjAActive.Size = new System.Drawing.Size(111, 17);
            this.chkInjAActive.TabIndex = 15;
            this.chkInjAActive.Text = "When Inj A active";
            this.chkInjAActive.UseVisualStyleBackColor = true;
            this.chkInjAActive.CheckedChanged += new System.EventHandler(this.chkMapAActive_CheckedChanged);
            // 
            // cbxSort1
            // 
            this.cbxSort1.DisplayMember = "1,2,3";
            this.cbxSort1.FormattingEnabled = true;
            this.cbxSort1.Items.AddRange(new object[] {
            "",
            "RPM",
            "Pressure",
            "InjA_Time",
            "InjB_Time",
            "AFR"});
            this.cbxSort1.Location = new System.Drawing.Point(277, 31);
            this.cbxSort1.Name = "cbxSort1";
            this.cbxSort1.Size = new System.Drawing.Size(121, 21);
            this.cbxSort1.TabIndex = 14;
            this.cbxSort1.ValueMember = "1,2,3";
            this.cbxSort1.SelectedIndexChanged += new System.EventHandler(this.cbxSort1_SelectedIndexChanged);
            // 
            // chkExportConverted
            // 
            this.chkExportConverted.AutoSize = true;
            this.chkExportConverted.Checked = true;
            this.chkExportConverted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportConverted.Location = new System.Drawing.Point(7, 17);
            this.chkExportConverted.Name = "chkExportConverted";
            this.chkExportConverted.Size = new System.Drawing.Size(134, 17);
            this.chkExportConverted.TabIndex = 12;
            this.chkExportConverted.Text = "Export Converted Logs";
            this.chkExportConverted.UseVisualStyleBackColor = true;
            this.chkExportConverted.CheckedChanged += new System.EventHandler(this.chkExportConverted_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(549, 260);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(56, 23);
            this.btnRun.TabIndex = 13;
            this.btnRun.Text = "Export";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chkExportRaw
            // 
            this.chkExportRaw.AutoSize = true;
            this.chkExportRaw.Location = new System.Drawing.Point(19, 19);
            this.chkExportRaw.Name = "chkExportRaw";
            this.chkExportRaw.Size = new System.Drawing.Size(107, 17);
            this.chkExportRaw.TabIndex = 9;
            this.chkExportRaw.Text = "Export Raw Logs";
            this.chkExportRaw.UseVisualStyleBackColor = true;
            this.chkExportRaw.CheckedChanged += new System.EventHandler(this.cbxExportRaw_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkExportRaw);
            this.groupBox1.Location = new System.Drawing.Point(506, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raw";
            // 
            // statusStripActions
            // 
            this.statusStripActions.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStripActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStripActions.Location = new System.Drawing.Point(0, 297);
            this.statusStripActions.Name = "statusStripActions";
            this.statusStripActions.Size = new System.Drawing.Size(693, 22);
            this.statusStripActions.TabIndex = 20;
            this.statusStripActions.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel.Text = "Starting...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 319);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.statusStripActions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbSplitSecond);
            this.Controls.Add(this.cbxReUseMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(709, 358);
            this.MinimumSize = new System.Drawing.Size(709, 358);
            this.Name = "frmMain";
            this.Text = "SplitSecond R4 Log Exporter";
            this.gbSplitSecond.ResumeLayout(false);
            this.gbSplitSecond.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.gbActions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStripActions.ResumeLayout(false);
            this.statusStripActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbR4File;
        private System.Windows.Forms.Button btnMDB;
        private System.Windows.Forms.ComboBox cbxSessions;
        private System.Windows.Forms.Label lblMDBFile;
        private System.Windows.Forms.Label lblR4Recording;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cbxReUseMap;
        private System.Windows.Forms.GroupBox gbSplitSecond;
        private System.Windows.Forms.Label lblRecordingHelp;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.CheckBox chkExportConverted;
        private System.Windows.Forms.CheckBox chkExportRaw;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox cbxSort1;
        private System.Windows.Forms.CheckBox chkInjAActive;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.CheckBox chkInjBActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblThen;
        private System.Windows.Forms.Label lblBy;
        private System.Windows.Forms.ComboBox cbxSort2;
        private System.Windows.Forms.StatusStrip statusStripActions;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.RadioButton rbRoundRPM;
        private System.Windows.Forms.RadioButton rbNoRound;
        private System.Windows.Forms.CheckBox chkAllRecords;
        private System.Windows.Forms.CheckBox chkSummary;
    }
}

