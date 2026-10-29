namespace ABAH.Desktop
{
    partial class FormImpact
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
            this.lblLoggedInAs = new System.Windows.Forms.Label();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.lblWasteDivertedValue = new System.Windows.Forms.Label();
            this.lblWasteDivertedCaption = new System.Windows.Forms.Label();
            this.lblPointsValue = new System.Windows.Forms.Label();
            this.lblPointsCaption = new System.Windows.Forms.Label();
            this.lblTransactionCountValue = new System.Windows.Forms.Label();
            this.lblTransactionCountCaption = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.lblMaterialFilter = new System.Windows.Forms.Label();
            this.cbMaterialFilter = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeightKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPointsEarned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGoal = new System.Windows.Forms.Label();
            this.pbGoal = new System.Windows.Forms.ProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.gbSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Climate Impact Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblLoggedInAs
            // 
            this.lblLoggedInAs.AutoSize = true;
            this.lblLoggedInAs.Location = new System.Drawing.Point(20, 40);
            this.lblLoggedInAs.Name = "lblLoggedInAs";
            this.lblLoggedInAs.Size = new System.Drawing.Size(111, 15);
            this.lblLoggedInAs.TabIndex = 1;
            this.lblLoggedInAs.Text = "Logged in as : -";
            // 
            // gbSummary
            // 
            this.gbSummary.Location = new System.Drawing.Point(20, 65);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(680, 105);
            this.gbSummary.TabIndex = 2;
            this.gbSummary.Text = "Environmental Impact Summary";
            this.gbSummary.TabStop = false;
            this.gbSummary.Controls.Add(this.lblWasteDivertedValue);
            this.gbSummary.Controls.Add(this.lblWasteDivertedCaption);
            this.gbSummary.Controls.Add(this.lblPointsValue);
            this.gbSummary.Controls.Add(this.lblPointsCaption);
            this.gbSummary.Controls.Add(this.lblTransactionCountValue);
            this.gbSummary.Controls.Add(this.lblTransactionCountCaption);
            // 
            // lblWasteDivertedValue
            // 
            this.lblWasteDivertedValue.AutoSize = false;
            this.lblWasteDivertedValue.Location = new System.Drawing.Point(15, 25);
            this.lblWasteDivertedValue.Name = "lblWasteDivertedValue";
            this.lblWasteDivertedValue.Size = new System.Drawing.Size(200, 32);
            this.lblWasteDivertedValue.TabIndex = 3;
            this.lblWasteDivertedValue.Text = "- kg";
            this.lblWasteDivertedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWasteDivertedValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblWasteDivertedCaption
            // 
            this.lblWasteDivertedCaption.AutoSize = false;
            this.lblWasteDivertedCaption.Location = new System.Drawing.Point(15, 62);
            this.lblWasteDivertedCaption.Name = "lblWasteDivertedCaption";
            this.lblWasteDivertedCaption.Size = new System.Drawing.Size(200, 20);
            this.lblWasteDivertedCaption.TabIndex = 4;
            this.lblWasteDivertedCaption.Text = "Waste Diverted";
            this.lblWasteDivertedCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointsValue
            // 
            this.lblPointsValue.AutoSize = false;
            this.lblPointsValue.Location = new System.Drawing.Point(240, 25);
            this.lblPointsValue.Name = "lblPointsValue";
            this.lblPointsValue.Size = new System.Drawing.Size(200, 32);
            this.lblPointsValue.TabIndex = 5;
            this.lblPointsValue.Text = "-";
            this.lblPointsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPointsValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblPointsCaption
            // 
            this.lblPointsCaption.AutoSize = false;
            this.lblPointsCaption.Location = new System.Drawing.Point(240, 62);
            this.lblPointsCaption.Name = "lblPointsCaption";
            this.lblPointsCaption.Size = new System.Drawing.Size(200, 20);
            this.lblPointsCaption.TabIndex = 6;
            this.lblPointsCaption.Text = "Environmental Points";
            this.lblPointsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransactionCountValue
            // 
            this.lblTransactionCountValue.AutoSize = false;
            this.lblTransactionCountValue.Location = new System.Drawing.Point(465, 25);
            this.lblTransactionCountValue.Name = "lblTransactionCountValue";
            this.lblTransactionCountValue.Size = new System.Drawing.Size(200, 32);
            this.lblTransactionCountValue.TabIndex = 7;
            this.lblTransactionCountValue.Text = "-";
            this.lblTransactionCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTransactionCountValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblTransactionCountCaption
            // 
            this.lblTransactionCountCaption.AutoSize = false;
            this.lblTransactionCountCaption.Location = new System.Drawing.Point(465, 62);
            this.lblTransactionCountCaption.Name = "lblTransactionCountCaption";
            this.lblTransactionCountCaption.Size = new System.Drawing.Size(200, 20);
            this.lblTransactionCountCaption.TabIndex = 8;
            this.lblTransactionCountCaption.Text = "Completed Transactions";
            this.lblTransactionCountCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(20, 190);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(58, 15);
            this.lblPeriod.TabIndex = 9;
            this.lblPeriod.Text = "Period :";
            // 
            // cbPeriod
            // 
            this.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Items.AddRange(new object[] {
                "This Week",
                "This Month",
                "This Year",
                "All Time"
            });
            this.cbPeriod.Location = new System.Drawing.Point(75, 186);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(140, 23);
            this.cbPeriod.SelectedIndex = 0;
            this.cbPeriod.TabIndex = 10;
            // 
            // lblMaterialFilter
            // 
            this.lblMaterialFilter.AutoSize = true;
            this.lblMaterialFilter.Location = new System.Drawing.Point(240, 190);
            this.lblMaterialFilter.Name = "lblMaterialFilter";
            this.lblMaterialFilter.Size = new System.Drawing.Size(72, 15);
            this.lblMaterialFilter.TabIndex = 11;
            this.lblMaterialFilter.Text = "Material :";
            // 
            // cbMaterialFilter
            // 
            this.cbMaterialFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialFilter.FormattingEnabled = true;
            this.cbMaterialFilter.Items.AddRange(new object[] {
                "All",
                "Cardboard",
                "Paper",
                "Plastic (PET)",
                "Glass",
                "Aluminum Cans",
                "Used Cooking Oil"
            });
            this.cbMaterialFilter.Location = new System.Drawing.Point(305, 186);
            this.cbMaterialFilter.Name = "cbMaterialFilter";
            this.cbMaterialFilter.Size = new System.Drawing.Size(150, 23);
            this.cbMaterialFilter.SelectedIndex = 0;
            this.cbMaterialFilter.TabIndex = 12;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(475, 184);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 27);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDate,
                this.colTransactionId,
                this.colMaterialType,
                this.colWeightKg,
                this.colPointsEarned
            });
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Location = new System.Drawing.Point(20, 220);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.Size = new System.Drawing.Size(680, 190);
            this.dgvHistory.TabIndex = 14;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colTransactionId
            // 
            this.colTransactionId.HeaderText = "TransactionId";
            this.colTransactionId.Name = "colTransactionId";
            this.colTransactionId.ReadOnly = true;
            // 
            // colMaterialType
            // 
            this.colMaterialType.HeaderText = "MaterialType";
            this.colMaterialType.Name = "colMaterialType";
            this.colMaterialType.ReadOnly = true;
            // 
            // colWeightKg
            // 
            this.colWeightKg.HeaderText = "WeightKg";
            this.colWeightKg.Name = "colWeightKg";
            this.colWeightKg.ReadOnly = true;
            // 
            // colPointsEarned
            // 
            this.colPointsEarned.HeaderText = "PointsEarned";
            this.colPointsEarned.Name = "colPointsEarned";
            this.colPointsEarned.ReadOnly = true;
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.Location = new System.Drawing.Point(20, 428);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(171, 15);
            this.lblGoal.TabIndex = 15;
            this.lblGoal.Text = "Monthly Goal : - / 100 kg";
            // 
            // pbGoal
            // 
            this.pbGoal.Location = new System.Drawing.Point(230, 425);
            this.pbGoal.Name = "pbGoal";
            this.pbGoal.Size = new System.Drawing.Size(300, 22);
            this.pbGoal.TabIndex = 16;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(20, 460);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(600, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormImpact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(720, 510);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLoggedInAs);
            this.Controls.Add(this.gbSummary);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.lblMaterialFilter);
            this.Controls.Add(this.cbMaterialFilter);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lblGoal);
            this.Controls.Add(this.pbGoal);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Name = "FormImpact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Climate Impact";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoggedInAs;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.Label lblWasteDivertedValue;
        private System.Windows.Forms.Label lblWasteDivertedCaption;
        private System.Windows.Forms.Label lblPointsValue;
        private System.Windows.Forms.Label lblPointsCaption;
        private System.Windows.Forms.Label lblTransactionCountValue;
        private System.Windows.Forms.Label lblTransactionCountCaption;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.Label lblMaterialFilter;
        private System.Windows.Forms.ComboBox cbMaterialFilter;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeightKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPointsEarned;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.ProgressBar pbGoal;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}
