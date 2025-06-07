namespace AquaTrack
{
    partial class AdminForm
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
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.gbBackup = new System.Windows.Forms.GroupBox();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.labelrole = new System.Windows.Forms.Label();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.labelnumber = new System.Windows.Forms.Label();
            this.btnMakeAdmin = new System.Windows.Forms.Button();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.gbDevices = new System.Windows.Forms.GroupBox();
            this.labelstatus = new System.Windows.Forms.Label();
            this.labeltype = new System.Windows.Forms.Label();
            this.txtDeviceStatus = new System.Windows.Forms.TextBox();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            this.btnRefreshDevices = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.BtnChangeLanguage = new System.Windows.Forms.Button();
            this.gbUsers.SuspendLayout();
            this.gbBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.gbDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.gbBackup);
            this.gbUsers.Controls.Add(this.labelrole);
            this.gbUsers.Controls.Add(this.btnRefreshUsers);
            this.gbUsers.Controls.Add(this.labelnumber);
            this.gbUsers.Controls.Add(this.btnMakeAdmin);
            this.gbUsers.Controls.Add(this.txtUserRole);
            this.gbUsers.Controls.Add(this.btnDeleteUser);
            this.gbUsers.Controls.Add(this.dgvUsers);
            this.gbUsers.Controls.Add(this.txtUserId);
            this.gbUsers.Location = new System.Drawing.Point(16, 48);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(532, 568);
            this.gbUsers.TabIndex = 0;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Керування користувачами";
            // 
            // gbBackup
            // 
            this.gbBackup.Controls.Add(this.btnCreateBackup);
            this.gbBackup.Location = new System.Drawing.Point(7, 449);
            this.gbBackup.Name = "gbBackup";
            this.gbBackup.Size = new System.Drawing.Size(190, 100);
            this.gbBackup.TabIndex = 2;
            this.gbBackup.TabStop = false;
            this.gbBackup.Text = "Резервне копіювання";
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.BackColor = System.Drawing.Color.Gray;
            this.btnCreateBackup.Location = new System.Drawing.Point(17, 36);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(154, 47);
            this.btnCreateBackup.TabIndex = 0;
            this.btnCreateBackup.Text = "Створити резервну копію";
            this.btnCreateBackup.UseVisualStyleBackColor = false;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // labelrole
            // 
            this.labelrole.AutoSize = true;
            this.labelrole.Location = new System.Drawing.Point(217, 497);
            this.labelrole.Name = "labelrole";
            this.labelrole.Size = new System.Drawing.Size(42, 16);
            this.labelrole.TabIndex = 11;
            this.labelrole.Text = "Роль:";
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.BackColor = System.Drawing.SystemColors.Info;
            this.btnRefreshUsers.Location = new System.Drawing.Point(385, 400);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(140, 40);
            this.btnRefreshUsers.TabIndex = 3;
            this.btnRefreshUsers.Text = "Оновити список";
            this.btnRefreshUsers.UseVisualStyleBackColor = false;
            this.btnRefreshUsers.Click += new System.EventHandler(this.btnRefreshUsers_Click);
            // 
            // labelnumber
            // 
            this.labelnumber.AutoSize = true;
            this.labelnumber.Location = new System.Drawing.Point(217, 449);
            this.labelnumber.Name = "labelnumber";
            this.labelnumber.Size = new System.Drawing.Size(53, 16);
            this.labelnumber.TabIndex = 10;
            this.labelnumber.Text = "Номер:";
            // 
            // btnMakeAdmin
            // 
            this.btnMakeAdmin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMakeAdmin.Location = new System.Drawing.Point(220, 400);
            this.btnMakeAdmin.Name = "btnMakeAdmin";
            this.btnMakeAdmin.Size = new System.Drawing.Size(159, 40);
            this.btnMakeAdmin.TabIndex = 2;
            this.btnMakeAdmin.Text = "Змінити роль";
            this.btnMakeAdmin.UseVisualStyleBackColor = false;
            this.btnMakeAdmin.Click += new System.EventHandler(this.btnMakeAdmin_Click);
            // 
            // txtUserRole
            // 
            this.txtUserRole.Location = new System.Drawing.Point(220, 516);
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.Size = new System.Drawing.Size(159, 22);
            this.txtUserRole.TabIndex = 9;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteUser.Location = new System.Drawing.Point(6, 400);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(208, 40);
            this.btnDeleteUser.TabIndex = 1;
            this.btnDeleteUser.Text = "Видалити користувача";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(7, 22);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(519, 372);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(220, 468);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(159, 22);
            this.txtUserId.TabIndex = 8;
            // 
            // gbDevices
            // 
            this.gbDevices.Controls.Add(this.labelstatus);
            this.gbDevices.Controls.Add(this.labeltype);
            this.gbDevices.Controls.Add(this.txtDeviceStatus);
            this.gbDevices.Controls.Add(this.txtDeviceType);
            this.gbDevices.Controls.Add(this.btnRefreshDevices);
            this.gbDevices.Controls.Add(this.btnAddDevice);
            this.gbDevices.Controls.Add(this.btnDeleteDevice);
            this.gbDevices.Controls.Add(this.dgvDevices);
            this.gbDevices.Location = new System.Drawing.Point(554, 48);
            this.gbDevices.Name = "gbDevices";
            this.gbDevices.Size = new System.Drawing.Size(532, 568);
            this.gbDevices.TabIndex = 1;
            this.gbDevices.TabStop = false;
            this.gbDevices.Text = "Керування IoT-девайсами";
            // 
            // labelstatus
            // 
            this.labelstatus.AutoSize = true;
            this.labelstatus.Location = new System.Drawing.Point(186, 497);
            this.labelstatus.Name = "labelstatus";
            this.labelstatus.Size = new System.Drawing.Size(123, 16);
            this.labelstatus.TabIndex = 7;
            this.labelstatus.Text = "Статус пристрою:";
            // 
            // labeltype
            // 
            this.labeltype.AutoSize = true;
            this.labeltype.Location = new System.Drawing.Point(186, 447);
            this.labeltype.Name = "labeltype";
            this.labeltype.Size = new System.Drawing.Size(102, 16);
            this.labeltype.TabIndex = 6;
            this.labeltype.Text = "Тип пристрою:";
            // 
            // txtDeviceStatus
            // 
            this.txtDeviceStatus.Location = new System.Drawing.Point(186, 516);
            this.txtDeviceStatus.Name = "txtDeviceStatus";
            this.txtDeviceStatus.Size = new System.Drawing.Size(193, 22);
            this.txtDeviceStatus.TabIndex = 5;
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Location = new System.Drawing.Point(186, 468);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.Size = new System.Drawing.Size(193, 22);
            this.txtDeviceType.TabIndex = 4;
            // 
            // btnRefreshDevices
            // 
            this.btnRefreshDevices.BackColor = System.Drawing.SystemColors.Info;
            this.btnRefreshDevices.Location = new System.Drawing.Point(385, 400);
            this.btnRefreshDevices.Name = "btnRefreshDevices";
            this.btnRefreshDevices.Size = new System.Drawing.Size(140, 40);
            this.btnRefreshDevices.TabIndex = 3;
            this.btnRefreshDevices.Text = "Оновити список";
            this.btnRefreshDevices.UseVisualStyleBackColor = false;
            this.btnRefreshDevices.Click += new System.EventHandler(this.btnRefreshDevices_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddDevice.Location = new System.Drawing.Point(186, 400);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(193, 40);
            this.btnAddDevice.TabIndex = 2;
            this.btnAddDevice.Text = "Додати пристрій";
            this.btnAddDevice.UseVisualStyleBackColor = false;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteDevice.Location = new System.Drawing.Point(6, 400);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(174, 40);
            this.btnDeleteDevice.TabIndex = 1;
            this.btnDeleteDevice.Text = "Видалити пристрій";
            this.btnDeleteDevice.UseVisualStyleBackColor = false;
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Location = new System.Drawing.Point(7, 22);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.RowHeadersWidth = 51;
            this.dgvDevices.RowTemplate.Height = 24;
            this.dgvDevices.Size = new System.Drawing.Size(519, 372);
            this.dgvDevices.TabIndex = 0;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // BtnChangeLanguage
            // 
            this.BtnChangeLanguage.Location = new System.Drawing.Point(984, 12);
            this.BtnChangeLanguage.Name = "BtnChangeLanguage";
            this.BtnChangeLanguage.Size = new System.Drawing.Size(95, 28);
            this.BtnChangeLanguage.TabIndex = 12;
            this.BtnChangeLanguage.Text = "Укр/Англ";
            this.BtnChangeLanguage.UseVisualStyleBackColor = true;
            this.BtnChangeLanguage.Click += new System.EventHandler(this.BtnChangeLanguage_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 627);
            this.Controls.Add(this.BtnChangeLanguage);
            this.Controls.Add(this.gbDevices);
            this.Controls.Add(this.gbUsers);
            this.Name = "AdminForm";
            this.Text = "AquaTrack";
            this.gbUsers.ResumeLayout(false);
            this.gbUsers.PerformLayout();
            this.gbBackup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.gbDevices.ResumeLayout(false);
            this.gbDevices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnRefreshUsers;
        private System.Windows.Forms.Button btnMakeAdmin;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.GroupBox gbDevices;
        private System.Windows.Forms.Button btnRefreshDevices;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnDeleteDevice;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.GroupBox gbBackup;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.Label labelstatus;
        private System.Windows.Forms.Label labeltype;
        private System.Windows.Forms.TextBox txtDeviceStatus;
        private System.Windows.Forms.TextBox txtDeviceType;
        private System.Windows.Forms.Label labelrole;
        private System.Windows.Forms.Label labelnumber;
        private System.Windows.Forms.TextBox txtUserRole;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Button BtnChangeLanguage;
    }
}