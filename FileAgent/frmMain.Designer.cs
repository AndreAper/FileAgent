namespace FileAgent
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkWatcherEnabled = new System.Windows.Forms.CheckBox();
            this.gbxSource = new System.Windows.Forms.GroupBox();
            this.tbxSelectedSourcePath = new System.Windows.Forms.TextBox();
            this.btnSetSourcePath = new System.Windows.Forms.Button();
            this.gbxTarget = new System.Windows.Forms.GroupBox();
            this.btnClearTargetPathList = new System.Windows.Forms.Button();
            this.btnRemoveTargetPath = new System.Windows.Forms.Button();
            this.btnAddTargetPath = new System.Windows.Forms.Button();
            this.lstBxTargetPathList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBarLive = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTimerIntervall = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbxHistory = new System.Windows.Forms.GroupBox();
            this.lblCurrentTask = new System.Windows.Forms.Label();
            this.progressBarHistory = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHistoryTime = new System.Windows.Forms.DateTimePicker();
            this.btnCopyHistory = new System.Windows.Forms.Button();
            this.historyTimer = new System.Windows.Forms.Timer(this.components);
            this.gbxSource.SuspendLayout();
            this.gbxTarget.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerIntervall)).BeginInit();
            this.gbxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkWatcherEnabled
            // 
            this.chkWatcherEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkWatcherEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chkWatcherEnabled.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.chkWatcherEnabled.Location = new System.Drawing.Point(6, 35);
            this.chkWatcherEnabled.Name = "chkWatcherEnabled";
            this.chkWatcherEnabled.Size = new System.Drawing.Size(75, 24);
            this.chkWatcherEnabled.TabIndex = 0;
            this.chkWatcherEnabled.Text = "Disabled";
            this.chkWatcherEnabled.UseVisualStyleBackColor = false;
            this.chkWatcherEnabled.CheckedChanged += new System.EventHandler(this.chkWatcherEnabled_CheckedChanged);
            // 
            // gbxSource
            // 
            this.gbxSource.Controls.Add(this.tbxSelectedSourcePath);
            this.gbxSource.Controls.Add(this.btnSetSourcePath);
            this.gbxSource.Location = new System.Drawing.Point(12, 12);
            this.gbxSource.Name = "gbxSource";
            this.gbxSource.Size = new System.Drawing.Size(496, 53);
            this.gbxSource.TabIndex = 4;
            this.gbxSource.TabStop = false;
            this.gbxSource.Text = "Source";
            // 
            // tbxSelectedSourcePath
            // 
            this.tbxSelectedSourcePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSelectedSourcePath.Location = new System.Drawing.Point(56, 21);
            this.tbxSelectedSourcePath.Name = "tbxSelectedSourcePath";
            this.tbxSelectedSourcePath.ReadOnly = true;
            this.tbxSelectedSourcePath.Size = new System.Drawing.Size(434, 20);
            this.tbxSelectedSourcePath.TabIndex = 6;
            // 
            // btnSetSourcePath
            // 
            this.btnSetSourcePath.Location = new System.Drawing.Point(6, 19);
            this.btnSetSourcePath.Name = "btnSetSourcePath";
            this.btnSetSourcePath.Size = new System.Drawing.Size(44, 23);
            this.btnSetSourcePath.TabIndex = 5;
            this.btnSetSourcePath.Text = "Set";
            this.btnSetSourcePath.UseVisualStyleBackColor = true;
            this.btnSetSourcePath.Click += new System.EventHandler(this.btnSetSourcePath_Click);
            // 
            // gbxTarget
            // 
            this.gbxTarget.Controls.Add(this.btnClearTargetPathList);
            this.gbxTarget.Controls.Add(this.btnRemoveTargetPath);
            this.gbxTarget.Controls.Add(this.btnAddTargetPath);
            this.gbxTarget.Controls.Add(this.lstBxTargetPathList);
            this.gbxTarget.Location = new System.Drawing.Point(12, 71);
            this.gbxTarget.Name = "gbxTarget";
            this.gbxTarget.Size = new System.Drawing.Size(496, 124);
            this.gbxTarget.TabIndex = 5;
            this.gbxTarget.TabStop = false;
            this.gbxTarget.Text = "Target";
            // 
            // btnClearTargetPathList
            // 
            this.btnClearTargetPathList.Location = new System.Drawing.Point(168, 94);
            this.btnClearTargetPathList.Name = "btnClearTargetPathList";
            this.btnClearTargetPathList.Size = new System.Drawing.Size(75, 23);
            this.btnClearTargetPathList.TabIndex = 6;
            this.btnClearTargetPathList.Text = "Clear";
            this.btnClearTargetPathList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearTargetPathList.UseVisualStyleBackColor = true;
            this.btnClearTargetPathList.Click += new System.EventHandler(this.btnClearTargetPathList_Click);
            // 
            // btnRemoveTargetPath
            // 
            this.btnRemoveTargetPath.Location = new System.Drawing.Point(87, 94);
            this.btnRemoveTargetPath.Name = "btnRemoveTargetPath";
            this.btnRemoveTargetPath.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTargetPath.TabIndex = 6;
            this.btnRemoveTargetPath.Text = "Remove";
            this.btnRemoveTargetPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveTargetPath.UseVisualStyleBackColor = true;
            this.btnRemoveTargetPath.Click += new System.EventHandler(this.btnRemoveTargetPath_Click);
            // 
            // btnAddTargetPath
            // 
            this.btnAddTargetPath.Location = new System.Drawing.Point(6, 94);
            this.btnAddTargetPath.Name = "btnAddTargetPath";
            this.btnAddTargetPath.Size = new System.Drawing.Size(75, 23);
            this.btnAddTargetPath.TabIndex = 6;
            this.btnAddTargetPath.Text = "Add";
            this.btnAddTargetPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTargetPath.UseVisualStyleBackColor = true;
            this.btnAddTargetPath.Click += new System.EventHandler(this.btnAddTargetPath_Click);
            // 
            // lstBxTargetPathList
            // 
            this.lstBxTargetPathList.FormattingEnabled = true;
            this.lstBxTargetPathList.Location = new System.Drawing.Point(6, 19);
            this.lstBxTargetPathList.Name = "lstBxTargetPathList";
            this.lstBxTargetPathList.Size = new System.Drawing.Size(484, 69);
            this.lstBxTargetPathList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBarLive);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudTimerIntervall);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.chkWatcherEnabled);
            this.groupBox1.Location = new System.Drawing.Point(12, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Observe";
            // 
            // progressBarLive
            // 
            this.progressBarLive.Location = new System.Drawing.Point(393, 36);
            this.progressBarLive.Name = "progressBarLive";
            this.progressBarLive.Size = new System.Drawing.Size(97, 23);
            this.progressBarLive.Step = 1;
            this.progressBarLive.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time (ms):";
            // 
            // nudTimerIntervall
            // 
            this.nudTimerIntervall.Location = new System.Drawing.Point(168, 39);
            this.nudTimerIntervall.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.nudTimerIntervall.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTimerIntervall.Name = "nudTimerIntervall";
            this.nudTimerIntervall.Size = new System.Drawing.Size(75, 20);
            this.nudTimerIntervall.TabIndex = 4;
            this.nudTimerIntervall.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTimerIntervall.ValueChanged += new System.EventHandler(this.nudTimerIntervall_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Attention: All data will be overwritten automatically.";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(249, 36);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // timer
            // 
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // gbxHistory
            // 
            this.gbxHistory.Controls.Add(this.lblCurrentTask);
            this.gbxHistory.Controls.Add(this.progressBarHistory);
            this.gbxHistory.Controls.Add(this.label3);
            this.gbxHistory.Controls.Add(this.dtpHistoryTime);
            this.gbxHistory.Controls.Add(this.btnCopyHistory);
            this.gbxHistory.Location = new System.Drawing.Point(12, 201);
            this.gbxHistory.Name = "gbxHistory";
            this.gbxHistory.Size = new System.Drawing.Size(496, 49);
            this.gbxHistory.TabIndex = 7;
            this.gbxHistory.TabStop = false;
            this.gbxHistory.Text = "History folder";
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.Location = new System.Drawing.Point(208, 20);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentTask.TabIndex = 4;
            // 
            // progressBarHistory
            // 
            this.progressBarHistory.Location = new System.Drawing.Point(393, 15);
            this.progressBarHistory.Name = "progressBarHistory";
            this.progressBarHistory.Size = new System.Drawing.Size(97, 23);
            this.progressBarHistory.Step = 1;
            this.progressBarHistory.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Time";
            // 
            // dtpHistoryTime
            // 
            this.dtpHistoryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHistoryTime.Location = new System.Drawing.Point(42, 18);
            this.dtpHistoryTime.Name = "dtpHistoryTime";
            this.dtpHistoryTime.ShowUpDown = true;
            this.dtpHistoryTime.Size = new System.Drawing.Size(75, 20);
            this.dtpHistoryTime.TabIndex = 0;
            this.dtpHistoryTime.Value = new System.DateTime(2015, 2, 23, 6, 0, 1, 0);
            this.dtpHistoryTime.ValueChanged += new System.EventHandler(this.dtpHistoryTime_ValueChanged);
            // 
            // btnCopyHistory
            // 
            this.btnCopyHistory.Location = new System.Drawing.Point(123, 15);
            this.btnCopyHistory.Name = "btnCopyHistory";
            this.btnCopyHistory.Size = new System.Drawing.Size(75, 23);
            this.btnCopyHistory.TabIndex = 2;
            this.btnCopyHistory.Text = "Copy";
            this.btnCopyHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyHistory.UseVisualStyleBackColor = true;
            this.btnCopyHistory.Click += new System.EventHandler(this.btnCopyHistory_Click);
            // 
            // historyTimer
            // 
            this.historyTimer.Enabled = true;
            this.historyTimer.Interval = 1000;
            this.historyTimer.Tick += new System.EventHandler(this.historyTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(520, 340);
            this.Controls.Add(this.gbxHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxTarget);
            this.Controls.Add(this.gbxSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "FileAgent";
            this.gbxSource.ResumeLayout(false);
            this.gbxSource.PerformLayout();
            this.gbxTarget.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerIntervall)).EndInit();
            this.gbxHistory.ResumeLayout(false);
            this.gbxHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWatcherEnabled;
        private System.Windows.Forms.GroupBox gbxSource;
        private System.Windows.Forms.Button btnSetSourcePath;
        private System.Windows.Forms.TextBox tbxSelectedSourcePath;
        private System.Windows.Forms.GroupBox gbxTarget;
        private System.Windows.Forms.ListBox lstBxTargetPathList;
        private System.Windows.Forms.Button btnClearTargetPathList;
        private System.Windows.Forms.Button btnRemoveTargetPath;
        private System.Windows.Forms.Button btnAddTargetPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NumericUpDown nudTimerIntervall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbxHistory;
        private System.Windows.Forms.DateTimePicker dtpHistoryTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer historyTimer;
        private System.Windows.Forms.Button btnCopyHistory;
        private System.Windows.Forms.ProgressBar progressBarLive;
        private System.Windows.Forms.ProgressBar progressBarHistory;
        private System.Windows.Forms.Label lblCurrentTask;
    }
}

