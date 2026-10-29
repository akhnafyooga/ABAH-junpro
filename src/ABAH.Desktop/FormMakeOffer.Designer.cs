namespace ABAH.Desktop
{
    partial class FormMakeOffer
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
            this.gbListing = new System.Windows.Forms.GroupBox();
            this.lblListingId = new System.Windows.Forms.Label();
            this.lblListingMaterial = new System.Windows.Forms.Label();
            this.lblListingWeight = new System.Windows.Forms.Label();
            this.lblListingLocation = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblFee = new System.Windows.Forms.Label();
            this.nudFee = new System.Windows.Forms.NumericUpDown();
            this.lblPickupDate = new System.Windows.Forms.Label();
            this.dtpPickupDate = new System.Windows.Forms.DateTimePicker();
            this.lblPickupTime = new System.Windows.Forms.Label();
            this.dtpPickupTime = new System.Windows.Forms.DateTimePicker();
            this.lblEstimatedPayout = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFee)).BeginInit();
            this.gbListing.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Make Offer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // gbListing
            // 
            this.gbListing.Location = new System.Drawing.Point(20, 50);
            this.gbListing.Name = "gbListing";
            this.gbListing.Size = new System.Drawing.Size(460, 100);
            this.gbListing.TabIndex = 1;
            this.gbListing.Text = "Listing Summary";
            this.gbListing.TabStop = false;
            this.gbListing.Controls.Add(this.lblListingId);
            this.gbListing.Controls.Add(this.lblListingMaterial);
            this.gbListing.Controls.Add(this.lblListingWeight);
            this.gbListing.Controls.Add(this.lblListingLocation);
            // 
            // lblListingId
            // 
            this.lblListingId.AutoSize = true;
            this.lblListingId.Location = new System.Drawing.Point(15, 28);
            this.lblListingId.Name = "lblListingId";
            this.lblListingId.Size = new System.Drawing.Size(98, 15);
            this.lblListingId.TabIndex = 2;
            this.lblListingId.Text = "Listing ID : -";
            // 
            // lblListingMaterial
            // 
            this.lblListingMaterial.AutoSize = true;
            this.lblListingMaterial.Location = new System.Drawing.Point(250, 28);
            this.lblListingMaterial.Name = "lblListingMaterial";
            this.lblListingMaterial.Size = new System.Drawing.Size(85, 15);
            this.lblListingMaterial.TabIndex = 3;
            this.lblListingMaterial.Text = "Material : -";
            // 
            // lblListingWeight
            // 
            this.lblListingWeight.AutoSize = true;
            this.lblListingWeight.Location = new System.Drawing.Point(15, 62);
            this.lblListingWeight.Name = "lblListingWeight";
            this.lblListingWeight.Size = new System.Drawing.Size(124, 15);
            this.lblListingWeight.TabIndex = 4;
            this.lblListingWeight.Text = "Est. Weight : - kg";
            // 
            // lblListingLocation
            // 
            this.lblListingLocation.AutoSize = true;
            this.lblListingLocation.Location = new System.Drawing.Point(250, 62);
            this.lblListingLocation.Name = "lblListingLocation";
            this.lblListingLocation.Size = new System.Drawing.Size(131, 15);
            this.lblListingLocation.TabIndex = 5;
            this.lblListingLocation.Text = "Pickup Location : -";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(40, 178);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(144, 15);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Proposed Price (Rp) :";
            // 
            // nudPrice
            // 
            this.nudPrice.Location = new System.Drawing.Point(200, 175);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(150, 23);
            this.nudPrice.TabIndex = 7;
            this.nudPrice.DecimalPlaces = 0;
            this.nudPrice.Maximum = new decimal(new int[] {1000000000, 0, 0, 0});
            this.nudPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrice.ThousandsSeparator = true;
            this.nudPrice.Increment = new decimal(new int[] {1000, 0, 0, 0});
            this.nudPrice.ValueChanged += new System.EventHandler(this.nudPrice_ValueChanged);
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Location = new System.Drawing.Point(40, 213);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(118, 15);
            this.lblFee.TabIndex = 8;
            this.lblFee.Text = "Pickup Fee (Rp) :";
            // 
            // nudFee
            // 
            this.nudFee.Location = new System.Drawing.Point(200, 210);
            this.nudFee.Name = "nudFee";
            this.nudFee.Size = new System.Drawing.Size(150, 23);
            this.nudFee.TabIndex = 9;
            this.nudFee.DecimalPlaces = 0;
            this.nudFee.Maximum = new decimal(new int[] {1000000000, 0, 0, 0});
            this.nudFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFee.ThousandsSeparator = true;
            this.nudFee.Increment = new decimal(new int[] {1000, 0, 0, 0});
            this.nudFee.ValueChanged += new System.EventHandler(this.nudFee_ValueChanged);
            // 
            // lblPickupDate
            // 
            this.lblPickupDate.AutoSize = true;
            this.lblPickupDate.Location = new System.Drawing.Point(40, 248);
            this.lblPickupDate.Name = "lblPickupDate";
            this.lblPickupDate.Size = new System.Drawing.Size(91, 15);
            this.lblPickupDate.TabIndex = 10;
            this.lblPickupDate.Text = "Pickup Date :";
            // 
            // dtpPickupDate
            // 
            this.dtpPickupDate.Location = new System.Drawing.Point(200, 245);
            this.dtpPickupDate.Name = "dtpPickupDate";
            this.dtpPickupDate.Size = new System.Drawing.Size(150, 23);
            this.dtpPickupDate.TabIndex = 11;
            this.dtpPickupDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblPickupTime
            // 
            this.lblPickupTime.AutoSize = true;
            this.lblPickupTime.Location = new System.Drawing.Point(40, 283);
            this.lblPickupTime.Name = "lblPickupTime";
            this.lblPickupTime.Size = new System.Drawing.Size(91, 15);
            this.lblPickupTime.TabIndex = 12;
            this.lblPickupTime.Text = "Pickup Time :";
            // 
            // dtpPickupTime
            // 
            this.dtpPickupTime.Location = new System.Drawing.Point(200, 280);
            this.dtpPickupTime.Name = "dtpPickupTime";
            this.dtpPickupTime.Size = new System.Drawing.Size(150, 23);
            this.dtpPickupTime.TabIndex = 13;
            this.dtpPickupTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPickupTime.ShowUpDown = true;
            // 
            // lblEstimatedPayout
            // 
            this.lblEstimatedPayout.AutoSize = true;
            this.lblEstimatedPayout.Location = new System.Drawing.Point(40, 325);
            this.lblEstimatedPayout.Name = "lblEstimatedPayout";
            this.lblEstimatedPayout.Size = new System.Drawing.Size(177, 15);
            this.lblEstimatedPayout.TabIndex = 14;
            this.lblEstimatedPayout.Text = "Estimated Net Total : Rp 0";
            this.lblEstimatedPayout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(130, 370);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 30);
            this.btnSubmit.TabIndex = 15;
            this.btnSubmit.Text = "Submit Offer";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormMakeOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AcceptButton = this.btnSubmit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbListing);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblFee);
            this.Controls.Add(this.nudFee);
            this.Controls.Add(this.lblPickupDate);
            this.Controls.Add(this.dtpPickupDate);
            this.Controls.Add(this.lblPickupTime);
            this.Controls.Add(this.dtpPickupTime);
            this.Controls.Add(this.lblEstimatedPayout);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormMakeOffer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Make Offer";
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFee)).EndInit();
            this.gbListing.ResumeLayout(false);
            this.gbListing.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbListing;
        private System.Windows.Forms.Label lblListingId;
        private System.Windows.Forms.Label lblListingMaterial;
        private System.Windows.Forms.Label lblListingWeight;
        private System.Windows.Forms.Label lblListingLocation;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.NumericUpDown nudFee;
        private System.Windows.Forms.Label lblPickupDate;
        private System.Windows.Forms.DateTimePicker dtpPickupDate;
        private System.Windows.Forms.Label lblPickupTime;
        private System.Windows.Forms.DateTimePicker dtpPickupTime;
        private System.Windows.Forms.Label lblEstimatedPayout;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}
