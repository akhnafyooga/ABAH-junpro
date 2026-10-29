using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// Offers & Price Negotiation - a producer reviews, accepts or rejects offers on one of their listings.
    /// </summary>
    public partial class FormOffers : Form
    {
        public FormOffers()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // TODO: UPDATE Offer.Status = 'Accepted' and create a PickupSchedule row.
            MessageBox.Show("Offer accepted. A pickup has been requested.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var form = new FormPickup();
            form.ShowDialog(this);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            // TODO: UPDATE Offer.Status = 'Rejected'.
            MessageBox.Show("Offer rejected.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: reload dgvOffers for the selected listing.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
