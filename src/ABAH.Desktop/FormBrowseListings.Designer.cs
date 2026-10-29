namespace ABAH.Desktop
{
    partial class FormBrowseListings
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.nudMinWeight = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDistance = new System.Windows.Forms.Label();
            this.nudMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvListings = new System.Windows.Forms.DataGridView();
            this.colListingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimatedWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPickupLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistancekm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMakeOffer = new System.Windows.Forms.Button();
            this.btnMyPickups = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABAH - Browse Waste Listings";
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
            // gbFilter
            // 
            this.gbFilter.Location = new System.Drawing.Point(20, 65);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(720, 95);
            this.gbFilter.TabIndex = 2;
            this.gbFilter.Text = "Search & Filter";
            this.gbFilter.TabStop = false;
            this.gbFilter.Controls.Add(this.lblMaterial);
            this.gbFilter.Controls.Add(this.cbMaterial);
            this.gbFilter.Controls.Add(this.lblCondition);
            this.gbFilter.Controls.Add(this.cbCondition);
            this.gbFilter.Controls.Add(this.lblMinWeight);
            this.gbFilter.Controls.Add(this.nudMinWeight);
            this.gbFilter.Controls.Add(this.lblMaxDistance);
            this.gbFilter.Controls.Add(this.nudMaxDistance);
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.btnReset);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(15, 25);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(105, 15);
            this.lblMaterial.TabIndex = 3;
            this.lblMaterial.Text = "Material Type :";
            // 
            // cbMaterial
            // 
            this.cbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Items.AddRange(new object[] {
                "All",
                "Cardboard",
                "Paper",
                "Plastic (PET)",
                "Glass",
                "Aluminum Cans",
                "Used Cooking Oil"
            });
            this.cbMaterial.Location = new System.Drawing.Point(15, 45);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(135, 23);
            this.cbMaterial.SelectedIndex = 0;
            this.cbMaterial.TabIndex = 4;
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(165, 25);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(78, 15);
            this.lblCondition.TabIndex = 5;
            this.lblCondition.Text = "Condition :";
            // 
            // cbCondition
            // 
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
                "All",
                "Clean",
                "Dry",
                "Flattened",
                "Filtered"
            });
            this.cbCondition.Location = new System.Drawing.Point(165, 45);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(125, 23);
            this.cbCondition.SelectedIndex = 0;
            this.cbCondition.TabIndex = 6;
            // 
            // lblMinWeight
            // 
            this.lblMinWeight.AutoSize = true;
            this.lblMinWeight.Location = new System.Drawing.Point(305, 25);
            this.lblMinWeight.Name = "lblMinWeight";
            this.lblMinWeight.Size = new System.Drawing.Size(118, 15);
            this.lblMinWeight.TabIndex = 7;
            this.lblMinWeight.Text = "Min Weight (kg) :";
            // 
            // nudMinWeight
            // 
            this.nudMinWeight.Location = new System.Drawing.Point(305, 45);
            this.nudMinWeight.Name = "nudMinWeight";
            this.nudMinWeight.Size = new System.Drawing.Size(100, 23);
            this.nudMinWeight.TabIndex = 8;
            this.nudMinWeight.DecimalPlaces = 1;
            this.nudMinWeight.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.nudMinWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMinWeight.ThousandsSeparator = true;
            // 
            // lblMaxDistance
            // 
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(425, 25);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(131, 15);
            this.lblMaxDistance.TabIndex = 9;
            this.lblMaxDistance.Text = "Max Distance (km) :";
            // 
            // nudMaxDistance
            // 
            this.nudMaxDistance.Location = new System.Drawing.Point(425, 45);
            this.nudMaxDistance.Name = "nudMaxDistance";
            this.nudMaxDistance.Size = new System.Drawing.Size(100, 23);
            this.nudMaxDistance.TabIndex = 10;
            this.nudMaxDistance.DecimalPlaces = 1;
            this.nudMaxDistance.Maximum = new decimal(new int[] {1000, 0, 0, 0});
            this.nudMaxDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxDistance.ThousandsSeparator = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(555, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 27);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(635, 42);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 27);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvListings
            // 
            this.dgvListings.AllowUserToAddRows = false;
            this.dgvListings.AllowUserToDeleteRows = false;
            this.dgvListings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListings.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colListingId,
                this.colMaterialType,
                this.colEstimatedWeight,
                this.colCondition,
                this.colPickupLocation,
                this.colDistancekm,
                this.colStatus
            });
            this.dgvListings.MultiSelect = false;
            this.dgvListings.ReadOnly = true;
            this.dgvListings.RowHeadersVisible = false;
            this.dgvListings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListings.Location = new System.Drawing.Point(20, 175);
            this.dgvListings.Name = "dgvListings";
            this.dgvListings.Size = new System.Drawing.Size(720, 250);
            this.dgvListings.TabIndex = 13;
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
            // colEstimatedWeight
            // 
            this.colEstimatedWeight.HeaderText = "EstimatedWeight";
            this.colEstimatedWeight.Name = "colEstimatedWeight";
            this.colEstimatedWeight.ReadOnly = true;
            // 
            // colCondition
            // 
            this.colCondition.HeaderText = "Condition";
            this.colCondition.Name = "colCondition";
            this.colCondition.ReadOnly = true;
            // 
            // colPickupLocation
            // 
            this.colPickupLocation.HeaderText = "PickupLocation";
            this.colPickupLocation.Name = "colPickupLocation";
            this.colPickupLocation.ReadOnly = true;
            // 
            // colDistancekm
            // 
            this.colDistancekm.HeaderText = "Distance (km)";
            this.colDistancekm.Name = "colDistancekm";
            this.colDistancekm.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // btnMakeOffer
            // 
            this.btnMakeOffer.Location = new System.Drawing.Point(20, 440);
            this.btnMakeOffer.Name = "btnMakeOffer";
            this.btnMakeOffer.Size = new System.Drawing.Size(110, 30);
            this.btnMakeOffer.TabIndex = 14;
            this.btnMakeOffer.Text = "Make Offer";
            this.btnMakeOffer.UseVisualStyleBackColor = true;
            this.btnMakeOffer.Click += new System.EventHandler(this.btnMakeOffer_Click);
            // 
            // btnMyPickups
            // 
            this.btnMyPickups.Location = new System.Drawing.Point(140, 440);
            this.btnMyPickups.Name = "btnMyPickups";
            this.btnMyPickups.Size = new System.Drawing.Size(110, 30);
            this.btnMyPickups.TabIndex = 15;
            this.btnMyPickups.Text = "My Pickups";
            this.btnMyPickups.UseVisualStyleBackColor = true;
            this.btnMyPickups.Click += new System.EventHandler(this.btnMyPickups_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(260, 440);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(640, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormBrowseListings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AcceptButton = this.btnSearch;
            this.ClientSize = new System.Drawing.Size(760, 490);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLoggedInAs);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.dgvListings);
            this.Controls.Add(this.btnMakeOffer);
            this.Controls.Add(this.btnMyPickups);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Name = "FormBrowseListings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABAH - Browse Listings";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoggedInAs;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Label lblMinWeight;
        private System.Windows.Forms.NumericUpDown nudMinWeight;
        private System.Windows.Forms.Label lblMaxDistance;
        private System.Windows.Forms.NumericUpDown nudMaxDistance;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvListings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimatedWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickupLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistancekm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnMakeOffer;
        private System.Windows.Forms.Button btnMyPickups;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}
