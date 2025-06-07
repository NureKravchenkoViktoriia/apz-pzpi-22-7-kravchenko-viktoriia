namespace AquaTrack
{
    partial class UserForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCheckAllLimits = new System.Windows.Forms.Button();
            this.btnRemoveLimit = new System.Windows.Forms.Button();
            this.dgvLimitRecords = new System.Windows.Forms.DataGridView();
            this.groupBoxLim = new System.Windows.Forms.GroupBox();
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.labelnumber = new System.Windows.Forms.Label();
            this.labelwater = new System.Windows.Forms.Label();
            this.txtLimitAmount = new System.Windows.Forms.TextBox();
            this.labelenddate = new System.Windows.Forms.Label();
            this.labelstartdate = new System.Windows.Forms.Label();
            this.dtpLimitEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddLimit = new System.Windows.Forms.Button();
            this.dtpLimitStartDate = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblRealTimeUsage = new System.Windows.Forms.Label();
            this.dgvWaterUsageHistory = new System.Windows.Forms.DataGridView();
            this.grpPeriodSelection = new System.Windows.Forms.GroupBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnShowData = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.tabControlPages = new System.Windows.Forms.TabControl();
            this.BtnChangeLanguage = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimitRecords)).BeginInit();
            this.groupBoxLim.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaterUsageHistory)).BeginInit();
            this.grpPeriodSelection.SuspendLayout();
            this.tabControlPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCheckAllLimits);
            this.tabPage2.Controls.Add(this.btnRemoveLimit);
            this.tabPage2.Controls.Add(this.dgvLimitRecords);
            this.tabPage2.Controls.Add(this.groupBoxLim);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCheckAllLimits
            // 
            this.btnCheckAllLimits.BackColor = System.Drawing.Color.Thistle;
            this.btnCheckAllLimits.Location = new System.Drawing.Point(311, 295);
            this.btnCheckAllLimits.Name = "btnCheckAllLimits";
            this.btnCheckAllLimits.Size = new System.Drawing.Size(168, 35);
            this.btnCheckAllLimits.TabIndex = 5;
            this.btnCheckAllLimits.Text = "Перевірити всі ліміти";
            this.btnCheckAllLimits.UseVisualStyleBackColor = false;
            this.btnCheckAllLimits.Click += new System.EventHandler(this.btnCheckAllLimits_Click);
            // 
            // btnRemoveLimit
            // 
            this.btnRemoveLimit.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveLimit.Location = new System.Drawing.Point(622, 295);
            this.btnRemoveLimit.Name = "btnRemoveLimit";
            this.btnRemoveLimit.Size = new System.Drawing.Size(131, 35);
            this.btnRemoveLimit.TabIndex = 3;
            this.btnRemoveLimit.Text = "Видалити ліміт";
            this.btnRemoveLimit.UseVisualStyleBackColor = false;
            this.btnRemoveLimit.Click += new System.EventHandler(this.btnRemoveLimit_Click);
            // 
            // dgvLimitRecords
            // 
            this.dgvLimitRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLimitRecords.Location = new System.Drawing.Point(311, 26);
            this.dgvLimitRecords.Name = "dgvLimitRecords";
            this.dgvLimitRecords.RowHeadersWidth = 51;
            this.dgvLimitRecords.RowTemplate.Height = 24;
            this.dgvLimitRecords.Size = new System.Drawing.Size(442, 254);
            this.dgvLimitRecords.TabIndex = 2;
            // 
            // groupBoxLim
            // 
            this.groupBoxLim.Controls.Add(this.txtDeviceId);
            this.groupBoxLim.Controls.Add(this.labelnumber);
            this.groupBoxLim.Controls.Add(this.labelwater);
            this.groupBoxLim.Controls.Add(this.txtLimitAmount);
            this.groupBoxLim.Controls.Add(this.labelenddate);
            this.groupBoxLim.Controls.Add(this.labelstartdate);
            this.groupBoxLim.Controls.Add(this.dtpLimitEndDate);
            this.groupBoxLim.Controls.Add(this.btnAddLimit);
            this.groupBoxLim.Controls.Add(this.dtpLimitStartDate);
            this.groupBoxLim.Location = new System.Drawing.Point(15, 16);
            this.groupBoxLim.Name = "groupBoxLim";
            this.groupBoxLim.Size = new System.Drawing.Size(277, 343);
            this.groupBoxLim.TabIndex = 1;
            this.groupBoxLim.TabStop = false;
            this.groupBoxLim.Text = "Ліміти";
            this.groupBoxLim.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Location = new System.Drawing.Point(6, 264);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(258, 22);
            this.txtDeviceId.TabIndex = 7;
            // 
            // labelnumber
            // 
            this.labelnumber.AutoSize = true;
            this.labelnumber.Location = new System.Drawing.Point(6, 232);
            this.labelnumber.Name = "labelnumber";
            this.labelnumber.Size = new System.Drawing.Size(171, 16);
            this.labelnumber.TabIndex = 6;
            this.labelnumber.Text = "Введіть номер пристрою:";
            // 
            // labelwater
            // 
            this.labelwater.AutoSize = true;
            this.labelwater.Location = new System.Drawing.Point(3, 165);
            this.labelwater.Name = "labelwater";
            this.labelwater.Size = new System.Drawing.Size(154, 16);
            this.labelwater.TabIndex = 5;
            this.labelwater.Text = "Введіть кількість води:";
            // 
            // txtLimitAmount
            // 
            this.txtLimitAmount.Location = new System.Drawing.Point(6, 195);
            this.txtLimitAmount.Name = "txtLimitAmount";
            this.txtLimitAmount.Size = new System.Drawing.Size(258, 22);
            this.txtLimitAmount.TabIndex = 4;
            // 
            // labelenddate
            // 
            this.labelenddate.AutoSize = true;
            this.labelenddate.Location = new System.Drawing.Point(6, 97);
            this.labelenddate.Name = "labelenddate";
            this.labelenddate.Size = new System.Drawing.Size(95, 16);
            this.labelenddate.TabIndex = 3;
            this.labelenddate.Text = "Кінцева дата:";
            // 
            // labelstartdate
            // 
            this.labelstartdate.AutoSize = true;
            this.labelstartdate.Location = new System.Drawing.Point(6, 27);
            this.labelstartdate.Name = "labelstartdate";
            this.labelstartdate.Size = new System.Drawing.Size(116, 16);
            this.labelstartdate.TabIndex = 2;
            this.labelstartdate.Text = "Початкова дата:";
            // 
            // dtpLimitEndDate
            // 
            this.dtpLimitEndDate.Location = new System.Drawing.Point(6, 128);
            this.dtpLimitEndDate.Name = "dtpLimitEndDate";
            this.dtpLimitEndDate.Size = new System.Drawing.Size(258, 22);
            this.dtpLimitEndDate.TabIndex = 2;
            // 
            // btnAddLimit
            // 
            this.btnAddLimit.BackColor = System.Drawing.Color.Aquamarine;
            this.btnAddLimit.Location = new System.Drawing.Point(6, 304);
            this.btnAddLimit.Name = "btnAddLimit";
            this.btnAddLimit.Size = new System.Drawing.Size(258, 33);
            this.btnAddLimit.TabIndex = 1;
            this.btnAddLimit.Text = "Створити ліміт";
            this.btnAddLimit.UseVisualStyleBackColor = false;
            this.btnAddLimit.Click += new System.EventHandler(this.btnAddLimit_Click);
            // 
            // dtpLimitStartDate
            // 
            this.dtpLimitStartDate.Location = new System.Drawing.Point(6, 57);
            this.dtpLimitStartDate.Name = "dtpLimitStartDate";
            this.dtpLimitStartDate.Size = new System.Drawing.Size(258, 22);
            this.dtpLimitStartDate.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblRealTimeUsage);
            this.tabPage1.Controls.Add(this.dgvWaterUsageHistory);
            this.tabPage1.Controls.Add(this.grpPeriodSelection);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblRealTimeUsage
            // 
            this.lblRealTimeUsage.AutoSize = true;
            this.lblRealTimeUsage.Location = new System.Drawing.Point(6, 271);
            this.lblRealTimeUsage.Name = "lblRealTimeUsage";
            this.lblRealTimeUsage.Size = new System.Drawing.Size(44, 16);
            this.lblRealTimeUsage.TabIndex = 2;
            this.lblRealTimeUsage.Text = "label1";
            // 
            // dgvWaterUsageHistory
            // 
            this.dgvWaterUsageHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaterUsageHistory.Location = new System.Drawing.Point(323, 19);
            this.dgvWaterUsageHistory.Name = "dgvWaterUsageHistory";
            this.dgvWaterUsageHistory.RowHeadersWidth = 51;
            this.dgvWaterUsageHistory.RowTemplate.Height = 24;
            this.dgvWaterUsageHistory.Size = new System.Drawing.Size(423, 359);
            this.dgvWaterUsageHistory.TabIndex = 1;
            // 
            // grpPeriodSelection
            // 
            this.grpPeriodSelection.Controls.Add(this.lblEndDate);
            this.grpPeriodSelection.Controls.Add(this.lblStartDate);
            this.grpPeriodSelection.Controls.Add(this.dtpEndDate);
            this.grpPeriodSelection.Controls.Add(this.btnShowData);
            this.grpPeriodSelection.Controls.Add(this.dtpStartDate);
            this.grpPeriodSelection.Location = new System.Drawing.Point(21, 19);
            this.grpPeriodSelection.Name = "grpPeriodSelection";
            this.grpPeriodSelection.Size = new System.Drawing.Size(277, 211);
            this.grpPeriodSelection.TabIndex = 0;
            this.grpPeriodSelection.TabStop = false;
            this.grpPeriodSelection.Text = "Історія використання води:";
            this.grpPeriodSelection.Enter += new System.EventHandler(this.grpPeriodSelection_Enter);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(6, 97);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(95, 16);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "Кінцева дата:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(6, 27);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(116, 16);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Початкова дата:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(6, 128);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(258, 22);
            this.dtpEndDate.TabIndex = 2;
            // 
            // btnShowData
            // 
            this.btnShowData.BackColor = System.Drawing.Color.Cyan;
            this.btnShowData.Location = new System.Drawing.Point(6, 173);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(258, 23);
            this.btnShowData.TabIndex = 1;
            this.btnShowData.Text = "Показати дані";
            this.btnShowData.UseVisualStyleBackColor = false;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(6, 57);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(258, 22);
            this.dtpStartDate.TabIndex = 0;
            // 
            // tabControlPages
            // 
            this.tabControlPages.Controls.Add(this.tabPage1);
            this.tabControlPages.Controls.Add(this.tabPage2);
            this.tabControlPages.Location = new System.Drawing.Point(12, 35);
            this.tabControlPages.Name = "tabControlPages";
            this.tabControlPages.SelectedIndex = 0;
            this.tabControlPages.Size = new System.Drawing.Size(776, 426);
            this.tabControlPages.TabIndex = 0;
            // 
            // BtnChangeLanguage
            // 
            this.BtnChangeLanguage.Location = new System.Drawing.Point(686, 12);
            this.BtnChangeLanguage.Name = "BtnChangeLanguage";
            this.BtnChangeLanguage.Size = new System.Drawing.Size(95, 28);
            this.BtnChangeLanguage.TabIndex = 11;
            this.BtnChangeLanguage.Text = "Укр/Англ";
            this.BtnChangeLanguage.UseVisualStyleBackColor = true;
            this.BtnChangeLanguage.Click += new System.EventHandler(this.BtnChangeLanguage_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.BtnChangeLanguage);
            this.Controls.Add(this.tabControlPages);
            this.Name = "UserForm";
            this.Text = "AquaTrack";
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimitRecords)).EndInit();
            this.groupBoxLim.ResumeLayout(false);
            this.groupBoxLim.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaterUsageHistory)).EndInit();
            this.grpPeriodSelection.ResumeLayout(false);
            this.grpPeriodSelection.PerformLayout();
            this.tabControlPages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblRealTimeUsage;
        private System.Windows.Forms.DataGridView dgvWaterUsageHistory;
        private System.Windows.Forms.GroupBox grpPeriodSelection;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TabControl tabControlPages;
        private System.Windows.Forms.GroupBox groupBoxLim;
        private System.Windows.Forms.Label labelenddate;
        private System.Windows.Forms.Label labelstartdate;
        private System.Windows.Forms.DateTimePicker dtpLimitEndDate;
        private System.Windows.Forms.Button btnAddLimit;
        private System.Windows.Forms.DateTimePicker dtpLimitStartDate;
        private System.Windows.Forms.Button btnRemoveLimit;
        private System.Windows.Forms.DataGridView dgvLimitRecords;
        private System.Windows.Forms.Label labelwater;
        private System.Windows.Forms.TextBox txtLimitAmount;
        private System.Windows.Forms.Label labelnumber;
        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.Button btnCheckAllLimits;
        private System.Windows.Forms.Button BtnChangeLanguage;
    }
}