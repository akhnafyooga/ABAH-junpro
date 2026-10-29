namespace ABAH.Desktop
{
    partial class FormRegister
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.gbRoles = new System.Windows.Forms.GroupBox();
            this.chkProducer = new System.Windows.Forms.CheckBox();
            this.chkCollector = new System.Windows.Forms.CheckBox();
            this.chkProcessor = new System.Windows.Forms.CheckBox();
            this.chkPartner = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(490, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Create Account";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(40, 63);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Full Name :";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(180, 60);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(270, 23);
            this.tbName.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(40, 98);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 15);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email :";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(180, 95);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(270, 23);
            this.tbEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 133);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(72, 15);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password :";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(180, 130);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(270, 23);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(40, 168);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(124, 15);
            this.lblConfirmPassword.TabIndex = 7;
            this.lblConfirmPassword.Text = "Confirm Password :";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(180, 165);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(270, 23);
            this.tbConfirmPassword.TabIndex = 8;
            this.tbConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(40, 203);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(98, 15);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Phone Number :";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(180, 200);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(270, 23);
            this.tbPhone.TabIndex = 10;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(40, 238);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 15);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Address :";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(180, 235);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(270, 50);
            this.tbAddress.TabIndex = 12;
            this.tbAddress.Multiline = true;
            // 
            // gbRoles
            // 
            this.gbRoles.Location = new System.Drawing.Point(40, 300);
            this.gbRoles.Name = "gbRoles";
            this.gbRoles.Size = new System.Drawing.Size(410, 85);
            this.gbRoles.TabIndex = 13;
            this.gbRoles.Text = "Select Role(s)";
            this.gbRoles.TabStop = false;
            this.gbRoles.Controls.Add(this.chkProducer);
            this.gbRoles.Controls.Add(this.chkCollector);
            this.gbRoles.Controls.Add(this.chkProcessor);
            this.gbRoles.Controls.Add(this.chkPartner);
            // 
            // chkProducer
            // 
            this.chkProducer.Location = new System.Drawing.Point(15, 25);
            this.chkProducer.Name = "chkProducer";
            this.chkProducer.Size = new System.Drawing.Size(180, 19);
            this.chkProducer.TabIndex = 14;
            this.chkProducer.Text = "Waste Producer";
            this.chkProducer.UseVisualStyleBackColor = true;
            // 
            // chkCollector
            // 
            this.chkCollector.Location = new System.Drawing.Point(210, 25);
            this.chkCollector.Name = "chkCollector";
            this.chkCollector.Size = new System.Drawing.Size(180, 19);
            this.chkCollector.TabIndex = 15;
            this.chkCollector.Text = "Collector";
            this.chkCollector.UseVisualStyleBackColor = true;
            // 
            // chkProcessor
            // 
            this.chkProcessor.Location = new System.Drawing.Point(15, 52);
            this.chkProcessor.Name = "chkProcessor";
            this.chkProcessor.Size = new System.Drawing.Size(180, 19);
            this.chkProcessor.TabIndex = 16;
            this.chkProcessor.Text = "Processor";
            this.chkProcessor.UseVisualStyleBackColor = true;
            // 
            // chkPartner
            // 
            this.chkPartner.Location = new System.Drawing.Point(210, 52);
            this.chkPartner.Name = "chkPartner";
            this.chkPartner.Size = new System.Drawing.Size(180, 19);
            this.chkPartner.TabIndex = 17;
            this.chkPartner.Text = "Community Partner";
            this.chkPartner.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(120, 405);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(110, 30);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AcceptButton = this.btnRegister;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(490, 455);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.gbRoles);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Register";
            this.gbRoles.ResumeLayout(false);
            this.gbRoles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.GroupBox gbRoles;
        private System.Windows.Forms.CheckBox chkProducer;
        private System.Windows.Forms.CheckBox chkCollector;
        private System.Windows.Forms.CheckBox chkProcessor;
        private System.Windows.Forms.CheckBox chkPartner;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
    }
}
