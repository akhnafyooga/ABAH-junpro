using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// Offers & Price Negotiation - a collector proposes price, pickup fee and pickup time for a listing.
    /// </summary>
    public partial class FormMakeOffer : Form
    {
        public FormMakeOffer()
        {
            InitializeComponent();
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            UpdateEstimatedPayout();
        }

        private void nudFee_ValueChanged(object sender, EventArgs e)
        {
            UpdateEstimatedPayout();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Please enter a proposed price.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO (database module): INSERT into Offer with Status = "Pending".
            MessageBox.Show("Offer submitted. The producer will be notified.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateEstimatedPayout()
        {
            // Mirrors Transaction.TotalPayment = ProposedPrice - PickupFee in program.cs
            decimal net = nudPrice.Value - nudFee.Value;
            lblEstimatedPayout.Text = "Estimated Net Total : Rp " + net.ToString("N0");
        }
    }
}
