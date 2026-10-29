namespace ABAH.Desktop
{
    partial class FormTransaction
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
            this.gbReceipt = new System.Windows.Forms.GroupBox();
            this.lblTransactionId = new System.Windows.Forms.Label();
            this.lblTransactionStatus = new System.Windows.Forms.Label();
            this.lblOfferId = new System.Windows.Forms.Label();
            this.lblFinalWeight = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.colTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.gbReceipt.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Transactions";
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
            // gbReceipt
            // 
            this.gbReceipt.Location = new System.Drawing.Point(20, 65);
            this.gbReceipt.Name = "gbReceipt";
            this.gbReceipt.Size = new System.Drawing.Size(680, 140);
            this.gbReceipt.TabIndex = 2;
            this.gbReceipt.Text = "Transaction Receipt";
            this.gbReceipt.TabStop = false;
            this.gbReceipt.Controls.Add(this.lblTransactionId);
            this.gbReceipt.Controls.Add(this.lblTransactionStatus);
            this.gbReceipt.Controls.Add(this.lblOfferId);
            this.gbReceipt.Controls.Add(this.lblFinalWeight);
            this.gbReceipt.Controls.Add(this.lblPaymentMethod);
            this.gbReceipt.Controls.Add(this.cbPaymentMethod);
            this.gbReceipt.Controls.Add(this.lblTotalPayment);
            // 
            // lblTransactionId
            // 
            this.lblTransactionId.AutoSize = true;
            this.lblTransactionId.Location = new System.Drawing.Point(15, 30);
            this.lblTransactionId.Name = "lblTransactionId";
            this.lblTransactionId.Size = new System.Drawing.Size(124, 15);
            this.lblTransactionId.TabIndex = 3;
            this.lblTransactionId.Text = "Transaction ID : -";
            // 
            // lblTransactionStatus
            // 
            this.lblTransactionStatus.AutoSize = true;
            this.lblTransactionStatus.Location = new System.Drawing.Point(360, 30);
            this.lblTransactionStatus.Name = "lblTransactionStatus";
            this.lblTransactionStatus.Size = new System.Drawing.Size(72, 15);
            this.lblTransactionStatus.TabIndex = 4;
            this.lblTransactionStatus.Text = "Status : -";
            // 
            // lblOfferId
            // 
            this.lblOfferId.AutoSize = true;
            this.lblOfferId.Location = new System.Drawing.Point(15, 62);
            this.lblOfferId.Name = "lblOfferId";
            this.lblOfferId.Size = new System.Drawing.Size(85, 15);
            this.lblOfferId.TabIndex = 5;
            this.lblOfferId.Text = "Offer ID : -";
            // 
            // lblFinalWeight
            // 
            this.lblFinalWeight.AutoSize = true;
            this.lblFinalWeight.Location = new System.Drawing.Point(360, 62);
            this.lblFinalWeight.Name = "lblFinalWeight";
            this.lblFinalWeight.Size = new System.Drawing.Size(131, 15);
            this.lblFinalWeight.TabIndex = 6;
            this.lblFinalWeight.Text = "Final Weight : - kg";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(15, 100);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(111, 15);
            this.lblPaymentMethod.TabIndex = 7;
            this.lblPaymentMethod.Text = "Payment Method :";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Items.AddRange(new object[] {
                "Cash",
                "Bank Transfer",
                "E-Wallet"
            });
            this.cbPaymentMethod.Location = new System.Drawing.Point(125, 96);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(150, 23);
            this.cbPaymentMethod.SelectedIndex = 0;
            this.cbPaymentMethod.TabIndex = 8;
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.AutoSize = true;
            this.lblTotalPayment.Location = new System.Drawing.Point(360, 100);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(138, 15);
            this.lblTotalPayment.TabIndex = 9;
            this.lblTotalPayment.Text = "Total Payment : Rp -";
            this.lblTotalPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(20, 218);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(131, 15);
            this.lblHistory.TabIndex = 10;
            this.lblHistory.Text = "Transaction History";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTransactionId,
                this.colListingId,
                this.colMaterialType,
                this.colFinalWeight,
                this.colTotalPayment,
                this.colStatus,
                this.colDate
            });
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Location = new System.Drawing.Point(20, 238);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(680, 175);
            this.dgvTransactions.TabIndex = 11;
            // 
            // colTransactionId
            // 
            this.colTransactionId.HeaderText = "TransactionId";
            this.colTransactionId.Name = "colTransactionId";
            this.colTransactionId.ReadOnly = true;
            // 
            // colListingId
            // 
            this.colListingId.HeaderText = "ListingId";
            this.colListingId.Name = "colListingId";
            this.colListingId.ReadOnly = true;
            // 
            // colMaterialType
            // 
            this.colMaterialType.HeaderText = "MaterialType";
            this.colMaterialType.Name = "colMaterialType";
            this.colMaterialType.ReadOnly = true;
            // 
            // colFinalWeight
            // 
            this.colFinalWeight.HeaderText = "FinalWeight";
            this.colFinalWeight.Name = "colFinalWeight";
            this.colFinalWeight.ReadOnly = true;
            // 
            // colTotalPayment
            // 
            this.colTotalPayment.HeaderText = "TotalPayment";
            this.colTotalPayment.Name = "colTotalPayment";
            this.colTotalPayment.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.Location = new System.Drawing.Point(20, 430);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(130, 30);
            this.btnConfirmPayment.TabIndex = 12;
            this.btnConfirmPayment.Text = "Confirm Payment";
            this.btnConfirmPayment.UseVisualStyleBackColor = true;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.Location = new System.Drawing.Point(160, 430);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(120, 30);
            this.btnPrintReceipt.TabIndex = 13;
            this.btnPrintReceipt.Text = "Print Receipt";
            this.btnPrintReceipt.UseVisualStyleBackColor = true;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(290, 430);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(600, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLoggedInAs);
            this.Controls.Add(this.gbReceipt);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Name = "FormTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Transactions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.gbReceipt.ResumeLayout(false);
            this.gbReceipt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoggedInAs;
        private System.Windows.Forms.GroupBox gbReceipt;
        private System.Windows.Forms.Label lblTransactionId;
        private System.Windows.Forms.Label lblTransactionStatus;
        private System.Windows.Forms.Label lblOfferId;
        private System.Windows.Forms.Label lblFinalWeight;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}
