namespace AquaTrack
{
    partial class AuthorizationForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.lblEmail2 = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.labelRegister = new System.Windows.Forms.LinkLabel();
            this.BtnChangeLanguage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(147, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(177, 32);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Авторизація";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(122, 155);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(59, 16);
            this.labelPassword.TabIndex = 13;
            this.labelPassword.Text = "Пароль:";
            this.labelPassword.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblEmail2
            // 
            this.lblEmail2.AutoSize = true;
            this.lblEmail2.Location = new System.Drawing.Point(122, 100);
            this.lblEmail2.Name = "lblEmail2";
            this.lblEmail2.Size = new System.Drawing.Size(52, 16);
            this.lblEmail2.TabIndex = 12;
            this.lblEmail2.Text = "Пошта:";
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(125, 174);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(225, 22);
            this.passwordtxt.TabIndex = 11;
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(125, 119);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(225, 22);
            this.emailtxt.TabIndex = 10;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnLogin.Location = new System.Drawing.Point(153, 234);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(167, 34);
            this.BtnLogin.TabIndex = 9;
            this.BtnLogin.Text = "Увійти";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.Location = new System.Drawing.Point(125, 203);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(80, 16);
            this.labelRegister.TabIndex = 14;
            this.labelRegister.TabStop = true;
            this.labelRegister.Text = "Реєстрація";
            this.labelRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelRegister_LinkClicked);
            // 
            // BtnChangeLanguage
            // 
            this.BtnChangeLanguage.Location = new System.Drawing.Point(358, 350);
            this.BtnChangeLanguage.Name = "BtnChangeLanguage";
            this.BtnChangeLanguage.Size = new System.Drawing.Size(95, 28);
            this.BtnChangeLanguage.TabIndex = 15;
            this.BtnChangeLanguage.Text = "Укр/Англ";
            this.BtnChangeLanguage.UseVisualStyleBackColor = true;
            this.BtnChangeLanguage.Click += new System.EventHandler(this.BtnChangeLanguage_Click);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 390);
            this.Controls.Add(this.BtnChangeLanguage);
            this.Controls.Add(this.labelRegister);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.lblEmail2);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.emailtxt);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.lblTitle);
            this.Name = "AuthorizationForm";
            this.Text = "AquaTrack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label lblEmail2;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.LinkLabel labelRegister;
        private System.Windows.Forms.Button BtnChangeLanguage;
    }
}