using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// Weight Verification System - estimated vs. actual scale weight, with scale photo evidence.
    /// </summary>
    public partial class FormWeightVerification : Form
    {
        public FormWeightVerification()
        {
            InitializeComponent();
        }

        private void nudActualWeight_ValueChanged(object sender, EventArgs e)
        {
            UpdateDifference();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select scale photo evidence";
                dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbPhotoPath.Text = dialog.FileName;
                    pbEvidence.Image = System.Drawing.Image.FromFile(dialog.FileName);
                }
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (nudActualWeight.Value <= 0 || string.IsNullOrWhiteSpace(tbScaleId.Text))
            {
                MessageBox.Show("Actual weight and Scale ID are required.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO (database module): INSERT WeightVerification, then generate the Transaction.
            MessageBox.Show("Weight verified. A transaction has been generated.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDifference()
        {
            decimal.TryParse(tbEstimatedWeight.Text, out decimal estimated);
            decimal difference = nudActualWeight.Value - estimated;
            lblDifference.Text = "Difference : " + difference.ToString("0.00") + " kg";
        }
    }
}
