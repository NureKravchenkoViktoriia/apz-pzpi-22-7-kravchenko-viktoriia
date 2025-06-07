namespace AquaTrack
{
    partial class RegistrationForm
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
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.labelRegister = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.BtnChangeLanguage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(120, 99);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(225, 22);
            this.usernameTextBox.TabIndex = 0;
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRegister.Location = new System.Drawing.Point(155, 32);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(160, 32);
            this.labelRegister.TabIndex = 2;
            this.labelRegister.Text = "Реєстрація";
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RegisterButton.Location = new System.Drawing.Point(148, 260);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(167, 34);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.Text = "Зареєструватись";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(120, 155);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(225, 22);
            this.emailTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(120, 210);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(225, 22);
            this.passwordTextBox.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(117, 80);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(120, 16);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Ім\'я користувача:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(117, 136);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(52, 16);
            this.labelEmail.TabIndex = 7;
            this.labelEmail.Text = "Пошта:";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(117, 191);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(59, 16);
            this.labelPass.TabIndex = 8;
            this.labelPass.Text = "Пароль:";
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(148, 313);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(167, 34);
            this.buttonReturn.TabIndex = 9;
            this.buttonReturn.Text = "Повернутись";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnChangeLanguage
            // 
            this.BtnChangeLanguage.Location = new System.Drawing.Point(356, 379);
            this.BtnChangeLanguage.Name = "BtnChangeLanguage";
            this.BtnChangeLanguage.Size = new System.Drawing.Size(95, 28);
            this.BtnChangeLanguage.TabIndex = 10;
            this.BtnChangeLanguage.Text = "Укр/Англ";
            this.BtnChangeLanguage.UseVisualStyleBackColor = true;
            this.BtnChangeLanguage.Click += new System.EventHandler(this.BtnChangeLanguage_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 420);
            this.Controls.Add(this.BtnChangeLanguage);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.labelRegister);
            this.Controls.Add(this.usernameTextBox);
            this.Name = "RegistrationForm";
            this.Text = "AquaTrack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.Button BtnChangeLanguage;
    }
}