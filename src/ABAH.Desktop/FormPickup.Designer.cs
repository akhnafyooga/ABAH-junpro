namespace ABAH.Desktop
{
    partial class FormPickup
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
            this.dgvPickups = new System.Windows.Forms.DataGridView();
            this.colPickupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCollector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScheduledTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lblStepRequested = new System.Windows.Forms.Label();
            this.lblStepAccepted = new System.Windows.Forms.Label();
            this.lblStepOnTheWay = new System.Windows.Forms.Label();
            this.lblStepCollected = new System.Windows.Forms.Label();
            this.lblStepVerified = new System.Windows.Forms.Label();
            this.lblStepCompleted = new System.Windows.Forms.Label();
            this.gbSchedule = new System.Windows.Forms.GroupBox();
            this.lblPickupTime = new System.Windows.Forms.Label();
            this.dtpPickupDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPickupTime = new System.Windows.Forms.DateTimePicker();
            this.btnReschedule = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnVerifyWeight = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickups)).BeginInit();
            this.gbStatus.SuspendLayout();
            this.gbSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Pickup Tracking";
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
            // dgvPickups
            // 
            this.dgvPickups.AllowUserToAddRows = false;
            this.dgvPickups.AllowUserToDeleteRows = false;
            this.dgvPickups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPickups.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPickups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colPickupId,
                this.colListingId,
                this.colMaterialType,
                this.colCollector,
                this.colScheduledTime,
                this.colStatus
            });
            this.dgvPickups.MultiSelect = false;
            this.dgvPickups.ReadOnly = true;
            this.dgvPickups.RowHeadersVisible = false;
            this.dgvPickups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPickups.Location = new System.Drawing.Point(20, 65);
            this.dgvPickups.Name = "dgvPickups";
            this.dgvPickups.Size = new System.Drawing.Size(680, 160);
            this.dgvPickups.TabIndex = 2;
            // 
            // colPickupId
            // 
            this.colPickupId.HeaderText = "PickupId";
            this.colPickupId.Name = "colPickupId";
            this.colPickupId.ReadOnly = true;
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
            // colCollector
            // 
            this.colCollector.HeaderText = "Collector";
            this.colCollector.Name = "colCollector";
            this.colCollector.ReadOnly = true;
            // 
            // colScheduledTime
            // 
            this.colScheduledTime.HeaderText = "ScheduledTime";
            this.colScheduledTime.Name = "colScheduledTime";
            this.colScheduledTime.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // gbStatus
            // 
            this.gbStatus.Location = new System.Drawing.Point(20, 235);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(680, 85);
            this.gbStatus.TabIndex = 3;
            this.gbStatus.Text = "Pickup Status";
            this.gbStatus.TabStop = false;
            this.gbStatus.Controls.Add(this.lblStepRequested);
            this.gbStatus.Controls.Add(this.lblStepAccepted);
            this.gbStatus.Controls.Add(this.lblStepOnTheWay);
            this.gbStatus.Controls.Add(this.lblStepCollected);
            this.gbStatus.Controls.Add(this.lblStepVerified);
            this.gbStatus.Controls.Add(this.lblStepCompleted);
            // 
            // lblStepRequested
            // 
            this.lblStepRequested.AutoSize = false;
            this.lblStepRequested.Location = new System.Drawing.Point(10, 35);
            this.lblStepRequested.Name = "lblStepRequested";
            this.lblStepRequested.Size = new System.Drawing.Size(105, 32);
            this.lblStepRequested.TabIndex = 4;
            this.lblStepRequested.Text = "1. Requested";
            this.lblStepRequested.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStepRequested.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepRequested.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // lblStepAccepted
            // 
            this.lblStepAccepted.AutoSize = false;
            this.lblStepAccepted.Location = new System.Drawing.Point(121, 35);
            this.lblStepAccepted.Name = "lblStepAccepted";
            this.lblStepAccepted.Size = new System.Drawing.Size(105, 32);
            this.lblStepAccepted.TabIndex = 5;
            this.lblStepAccepted.Text = "2. Accepted";
            this.lblStepAccepted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStepAccepted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepAccepted.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // lblStepOnTheWay
            // 
            this.lblStepOnTheWay.AutoSize = false;
            this.lblStepOnTheWay.Location = new System.Drawing.Point(232, 35);
            this.lblStepOnTheWay.Name = "lblStepOnTheWay";
            this.lblStepOnTheWay.Size = new System.Drawing.Size(105, 32);
            this.lblStepOnTheWay.TabIndex = 6;
            this.lblStepOnTheWay.Text = "3. On The Way";
            this.lblStepOnTheWay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStepOnTheWay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepOnTheWay.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // lblStepCollected
            // 
            this.lblStepCollected.AutoSize = false;
            this.lblStepCollected.Location = new System.Drawing.Point(343, 35);
            this.lblStepCollected.Name = "lblStepCollected";
            this.lblStepCollected.Size = new System.Drawing.Size(105, 32);
            this.lblStepCollected.TabIndex = 7;
            this.lblStepCollected.Text = "4. Collected";
            this.lblStepCollected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStepCollected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepCollected.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // lblStepVerified
            // 
            this.lblStepVerified.AutoSize = false;
            this.lblStepVerified.Location = new System.Drawing.Point(454, 35);
            this.lblStepVerified.Name = "lblStepVerified";
            this.lblStepVerified.Size = new System.Drawing.Size(105, 32);
            this.lblStepVerified.TabIndex = 8;
            this.lblStepVerified.Text = "5. Verified";
            this.lblStepVerified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStepVerified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepVerified.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // lblStepCompleted
            // 
            this.lblStepCompleted.AutoSize = false;
            this.lblStepCompleted.Location = new System.Drawing.Point(565, 35);
            this.lblStepCompleted.Name = "lblStepCompleted";
            this.lblStepCompleted.Size = new System.Drawing.Size(105, 32);
            this.lblStepCompleted.TabIndex = 9;
            this.lblStepCompleted.Text = "6. Completed";
            this.lblStepCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStepCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepCompleted.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // gbSchedule
            // 
            this.gbSchedule.Location = new System.Drawing.Point(20, 330);
            this.gbSchedule.Name = "gbSchedule";
            this.gbSchedule.Size = new System.Drawing.Size(680, 65);
            this.gbSchedule.TabIndex = 10;
            this.gbSchedule.Text = "Schedule";
            this.gbSchedule.TabStop = false;
            this.gbSchedule.Controls.Add(this.lblPickupTime);
            this.gbSchedule.Controls.Add(this.dtpPickupDate);
            this.gbSchedule.Controls.Add(this.dtpPickupTime);
            this.gbSchedule.Controls.Add(this.btnReschedule);
            // 
            // lblPickupTime
            // 
            this.lblPickupTime.AutoSize = true;
            this.lblPickupTime.Location = new System.Drawing.Point(15, 30);
            this.lblPickupTime.Name = "lblPickupTime";
            this.lblPickupTime.Size = new System.Drawing.Size(91, 15);
            this.lblPickupTime.TabIndex = 11;
            this.lblPickupTime.Text = "Pickup Time :";
            // 
            // dtpPickupDate
            // 
            this.dtpPickupDate.Location = new System.Drawing.Point(105, 26);
            this.dtpPickupDate.Name = "dtpPickupDate";
            this.dtpPickupDate.Size = new System.Drawing.Size(120, 23);
            this.dtpPickupDate.TabIndex = 12;
            this.dtpPickupDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // dtpPickupTime
            // 
            this.dtpPickupTime.Location = new System.Drawing.Point(235, 26);
            this.dtpPickupTime.Name = "dtpPickupTime";
            this.dtpPickupTime.Size = new System.Drawing.Size(100, 23);
            this.dtpPickupTime.TabIndex = 13;
            this.dtpPickupTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPickupTime.ShowUpDown = true;
            // 
            // btnReschedule
            // 
            this.btnReschedule.Location = new System.Drawing.Point(355, 24);
            this.btnReschedule.Name = "btnReschedule";
            this.btnReschedule.Size = new System.Drawing.Size(100, 27);
            this.btnReschedule.TabIndex = 14;
            this.btnReschedule.Text = "Reschedule";
            this.btnReschedule.UseVisualStyleBackColor = true;
            this.btnReschedule.Click += new System.EventHandler(this.btnReschedule_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(20, 415);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateStatus.TabIndex = 15;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnVerifyWeight
            // 
            this.btnVerifyWeight.Location = new System.Drawing.Point(150, 415);
            this.btnVerifyWeight.Name = "btnVerifyWeight";
            this.btnVerifyWeight.Size = new System.Drawing.Size(120, 30);
            this.btnVerifyWeight.TabIndex = 16;
            this.btnVerifyWeight.Text = "Verify Weight";
            this.btnVerifyWeight.UseVisualStyleBackColor = true;
            this.btnVerifyWeight.Click += new System.EventHandler(this.btnVerifyWeight_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(280, 415);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(600, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormPickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(720, 465);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLoggedInAs);
            this.Controls.Add(this.dgvPickups);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.gbSchedule);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnVerifyWeight);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Name = "FormPickup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Pickup Tracking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickups)).EndInit();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbSchedule.ResumeLayout(false);
            this.gbSchedule.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoggedInAs;
        private System.Windows.Forms.DataGridView dgvPickups;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCollector;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduledTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Label lblStepRequested;
        private System.Windows.Forms.Label lblStepAccepted;
        private System.Windows.Forms.Label lblStepOnTheWay;
        private System.Windows.Forms.Label lblStepCollected;
        private System.Windows.Forms.Label lblStepVerified;
        private System.Windows.Forms.Label lblStepCompleted;
        private System.Windows.Forms.GroupBox gbSchedule;
        private System.Windows.Forms.Label lblPickupTime;
        private System.Windows.Forms.DateTimePicker dtpPickupDate;
        private System.Windows.Forms.DateTimePicker dtpPickupTime;
        private System.Windows.Forms.Button btnReschedule;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnVerifyWeight;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}
