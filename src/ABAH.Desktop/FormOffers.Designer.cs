namespace ABAH.Desktop
{
    partial class FormOffers
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
            this.lblSelectListing = new System.Windows.Forms.Label();
            this.cbListing = new System.Windows.Forms.ComboBox();
            this.lblOfferCount = new System.Windows.Forms.Label();
            this.dgvOffers = new System.Windows.Forms.DataGridView();
            this.colOfferId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCollector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProposedPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPickupFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPickupSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Offers Received";
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
            // lblSelectListing
            // 
            this.lblSelectListing.AutoSize = true;
            this.lblSelectListing.Location = new System.Drawing.Point(20, 71);
            this.lblSelectListing.Name = "lblSelectListing";
            this.lblSelectListing.Size = new System.Drawing.Size(111, 15);
            this.lblSelectListing.TabIndex = 2;
            this.lblSelectListing.Text = "Select Listing :";
            // 
            // cbListing
            // 
            this.cbListing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListing.FormattingEnabled = true;
            this.cbListing.Items.AddRange(new object[] {
                "(select a listing)"
            });
            this.cbListing.Location = new System.Drawing.Point(120, 67);
            this.cbListing.Name = "cbListing";
            this.cbListing.Size = new System.Drawing.Size(260, 23);
            this.cbListing.SelectedIndex = 0;
            this.cbListing.TabIndex = 3;
            // 
            // lblOfferCount
            // 
            this.lblOfferCount.AutoSize = true;
            this.lblOfferCount.Location = new System.Drawing.Point(410, 71);
            this.lblOfferCount.Name = "lblOfferCount";
            this.lblOfferCount.Size = new System.Drawing.Size(72, 15);
            this.lblOfferCount.TabIndex = 4;
            this.lblOfferCount.Text = "Offers : -";
            // 
            // dgvOffers
            // 
            this.dgvOffers.AllowUserToAddRows = false;
            this.dgvOffers.AllowUserToDeleteRows = false;
            this.dgvOffers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOffers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOffers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colOfferId,
                this.colCollector,
                this.colProposedPrice,
                this.colPickupFee,
                this.colPickupSchedule,
                this.colStatus
            });
            this.dgvOffers.MultiSelect = false;
            this.dgvOffers.ReadOnly = true;
            this.dgvOffers.RowHeadersVisible = false;
            this.dgvOffers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOffers.Location = new System.Drawing.Point(20, 100);
            this.dgvOffers.Name = "dgvOffers";
            this.dgvOffers.Size = new System.Drawing.Size(680, 250);
            this.dgvOffers.TabIndex = 5;
            // 
            // colOfferId
            // 
            this.colOfferId.HeaderText = "OfferId";
            this.colOfferId.Name = "colOfferId";
            this.colOfferId.ReadOnly = true;
            // 
            // colCollector
            // 
            this.colCollector.HeaderText = "Collector";
            this.colCollector.Name = "colCollector";
            this.colCollector.ReadOnly = true;
            // 
            // colProposedPrice
            // 
            this.colProposedPrice.HeaderText = "ProposedPrice";
            this.colProposedPrice.Name = "colProposedPrice";
            this.colProposedPrice.ReadOnly = true;
            // 
            // colPickupFee
            // 
            this.colPickupFee.HeaderText = "PickupFee";
            this.colPickupFee.Name = "colPickupFee";
            this.colPickupFee.ReadOnly = true;
            // 
            // colPickupSchedule
            // 
            this.colPickupSchedule.HeaderText = "PickupSchedule";
            this.colPickupSchedule.Name = "colPickupSchedule";
            this.colPickupSchedule.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.Location = new System.Drawing.Point(20, 362);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(190, 15);
            this.lblNetAmount.TabIndex = 6;
            this.lblNetAmount.Text = "Net amount to receive : Rp -";
            this.lblNetAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(20, 395);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 30);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept Offer";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(140, 395);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(110, 30);
            this.btnReject.TabIndex = 8;
            this.btnReject.Text = "Reject Offer";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(260, 395);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(600, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormOffers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(720, 445);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLoggedInAs);
            this.Controls.Add(this.lblSelectListing);
            this.Controls.Add(this.cbListing);
            this.Controls.Add(this.lblOfferCount);
            this.Controls.Add(this.dgvOffers);
            this.Controls.Add(this.lblNetAmount);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Name = "FormOffers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Offers Received";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoggedInAs;
        private System.Windows.Forms.Label lblSelectListing;
        private System.Windows.Forms.ComboBox cbListing;
        private System.Windows.Forms.Label lblOfferCount;
        private System.Windows.Forms.DataGridView dgvOffers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOfferId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCollector;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposedPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}
