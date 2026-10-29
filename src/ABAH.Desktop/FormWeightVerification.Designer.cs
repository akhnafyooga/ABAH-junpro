namespace ABAH.Desktop
{
    partial class FormWeightVerification
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
            this.gbPickup = new System.Windows.Forms.GroupBox();
            this.lblListingId = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblProducer = new System.Windows.Forms.Label();
            this.lblCollector = new System.Windows.Forms.Label();
            this.lblEstimatedWeight = new System.Windows.Forms.Label();
            this.tbEstimatedWeight = new System.Windows.Forms.TextBox();
            this.lblActualWeight = new System.Windows.Forms.Label();
            this.nudActualWeight = new System.Windows.Forms.NumericUpDown();
            this.lblScaleId = new System.Windows.Forms.Label();
            this.tbScaleId = new System.Windows.Forms.TextBox();
            this.lblPhotoEvidence = new System.Windows.Forms.Label();
            this.tbPhotoPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbEvidence = new System.Windows.Forms.PictureBox();
            this.lblDifference = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudActualWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEvidence)).BeginInit();
            this.gbPickup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Weight Verification";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // gbPickup
            // 
            this.gbPickup.Location = new System.Drawing.Point(20, 50);
            this.gbPickup.Name = "gbPickup";
            this.gbPickup.Size = new System.Drawing.Size(520, 100);
            this.gbPickup.TabIndex = 1;
            this.gbPickup.Text = "Pickup Information";
            this.gbPickup.TabStop = false;
            this.gbPickup.Controls.Add(this.lblListingId);
            this.gbPickup.Controls.Add(this.lblMaterial);
            this.gbPickup.Controls.Add(this.lblProducer);
            this.gbPickup.Controls.Add(this.lblCollector);
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
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(270, 28);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(85, 15);
            this.lblMaterial.TabIndex = 3;
            this.lblMaterial.Text = "Material : -";
            // 
            // lblProducer
            // 
            this.lblProducer.AutoSize = true;
            this.lblProducer.Location = new System.Drawing.Point(15, 62);
            this.lblProducer.Name = "lblProducer";
            this.lblProducer.Size = new System.Drawing.Size(85, 15);
            this.lblProducer.TabIndex = 4;
            this.lblProducer.Text = "Producer : -";
            // 
            // lblCollector
            // 
            this.lblCollector.AutoSize = true;
            this.lblCollector.Location = new System.Drawing.Point(270, 62);
            this.lblCollector.Name = "lblCollector";
            this.lblCollector.Size = new System.Drawing.Size(91, 15);
            this.lblCollector.TabIndex = 5;
            this.lblCollector.Text = "Collector : -";
            // 
            // lblEstimatedWeight
            // 
            this.lblEstimatedWeight.AutoSize = true;
            this.lblEstimatedWeight.Location = new System.Drawing.Point(30, 173);
            this.lblEstimatedWeight.Name = "lblEstimatedWeight";
            this.lblEstimatedWeight.Size = new System.Drawing.Size(157, 15);
            this.lblEstimatedWeight.TabIndex = 6;
            this.lblEstimatedWeight.Text = "Estimated Weight (kg) :";
            // 
            // tbEstimatedWeight
            // 
            this.tbEstimatedWeight.Location = new System.Drawing.Point(210, 170);
            this.tbEstimatedWeight.Name = "tbEstimatedWeight";
            this.tbEstimatedWeight.Size = new System.Drawing.Size(120, 23);
            this.tbEstimatedWeight.TabIndex = 7;
            this.tbEstimatedWeight.ReadOnly = true;
            this.tbEstimatedWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblActualWeight
            // 
            this.lblActualWeight.AutoSize = true;
            this.lblActualWeight.Location = new System.Drawing.Point(30, 208);
            this.lblActualWeight.Name = "lblActualWeight";
            this.lblActualWeight.Size = new System.Drawing.Size(138, 15);
            this.lblActualWeight.TabIndex = 8;
            this.lblActualWeight.Text = "Actual Weight (kg) :";
            // 
            // nudActualWeight
            // 
            this.nudActualWeight.Location = new System.Drawing.Point(210, 205);
            this.nudActualWeight.Name = "nudActualWeight";
            this.nudActualWeight.Size = new System.Drawing.Size(120, 23);
            this.nudActualWeight.TabIndex = 9;
            this.nudActualWeight.DecimalPlaces = 2;
            this.nudActualWeight.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.nudActualWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudActualWeight.ThousandsSeparator = true;
            this.nudActualWeight.ValueChanged += new System.EventHandler(this.nudActualWeight_ValueChanged);
            // 
            // lblScaleId
            // 
            this.lblScaleId.AutoSize = true;
            this.lblScaleId.Location = new System.Drawing.Point(30, 243);
            this.lblScaleId.Name = "lblScaleId";
            this.lblScaleId.Size = new System.Drawing.Size(72, 15);
            this.lblScaleId.TabIndex = 10;
            this.lblScaleId.Text = "Scale ID :";
            // 
            // tbScaleId
            // 
            this.tbScaleId.Location = new System.Drawing.Point(210, 240);
            this.tbScaleId.Name = "tbScaleId";
            this.tbScaleId.Size = new System.Drawing.Size(120, 23);
            this.tbScaleId.TabIndex = 11;
            // 
            // lblPhotoEvidence
            // 
            this.lblPhotoEvidence.AutoSize = true;
            this.lblPhotoEvidence.Location = new System.Drawing.Point(30, 278);
            this.lblPhotoEvidence.Name = "lblPhotoEvidence";
            this.lblPhotoEvidence.Size = new System.Drawing.Size(151, 15);
            this.lblPhotoEvidence.TabIndex = 12;
            this.lblPhotoEvidence.Text = "Scale Photo Evidence :";
            // 
            // tbPhotoPath
            // 
            this.tbPhotoPath.Location = new System.Drawing.Point(210, 275);
            this.tbPhotoPath.Name = "tbPhotoPath";
            this.tbPhotoPath.Size = new System.Drawing.Size(190, 23);
            this.tbPhotoPath.TabIndex = 13;
            this.tbPhotoPath.ReadOnly = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(410, 273);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 27);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbEvidence
            // 
            this.pbEvidence.Location = new System.Drawing.Point(210, 312);
            this.pbEvidence.Name = "pbEvidence";
            this.pbEvidence.Size = new System.Drawing.Size(170, 90);
            this.pbEvidence.TabIndex = 15;
            this.pbEvidence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEvidence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEvidence.TabStop = false;
            // 
            // lblDifference
            // 
            this.lblDifference.AutoSize = true;
            this.lblDifference.Location = new System.Drawing.Point(395, 350);
            this.lblDifference.Name = "lblDifference";
            this.lblDifference.Size = new System.Drawing.Size(118, 15);
            this.lblDifference.TabIndex = 16;
            this.lblDifference.Text = "Difference : - kg";
            this.lblDifference.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(140, 420);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(130, 30);
            this.btnVerify.TabIndex = 17;
            this.btnVerify.Text = "Verify && Submit";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormWeightVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(560, 470);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbPickup);
            this.Controls.Add(this.lblEstimatedWeight);
            this.Controls.Add(this.tbEstimatedWeight);
            this.Controls.Add(this.lblActualWeight);
            this.Controls.Add(this.nudActualWeight);
            this.Controls.Add(this.lblScaleId);
            this.Controls.Add(this.tbScaleId);
            this.Controls.Add(this.lblPhotoEvidence);
            this.Controls.Add(this.tbPhotoPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pbEvidence);
            this.Controls.Add(this.lblDifference);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormWeightVerification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Weight Verification";
            ((System.ComponentModel.ISupportInitialize)(this.nudActualWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEvidence)).EndInit();
            this.gbPickup.ResumeLayout(false);
            this.gbPickup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbPickup;
        private System.Windows.Forms.Label lblListingId;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblProducer;
        private System.Windows.Forms.Label lblCollector;
        private System.Windows.Forms.Label lblEstimatedWeight;
        private System.Windows.Forms.TextBox tbEstimatedWeight;
        private System.Windows.Forms.Label lblActualWeight;
        private System.Windows.Forms.NumericUpDown nudActualWeight;
        private System.Windows.Forms.Label lblScaleId;
        private System.Windows.Forms.TextBox tbScaleId;
        private System.Windows.Forms.Label lblPhotoEvidence;
        private System.Windows.Forms.TextBox tbPhotoPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbEvidence;
        private System.Windows.Forms.Label lblDifference;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnCancel;
    }
}
