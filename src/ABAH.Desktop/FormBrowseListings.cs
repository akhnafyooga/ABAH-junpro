using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// Search & Material Matching - collectors filter available listings by material, condition, volume and distance.
    /// </summary>
    public partial class FormBrowseListings : Form
    {
        public FormBrowseListings()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // TODO: query WasteListing filtered by the selected criteria.
            MessageBox.Show("Search is not connected to the database yet (UI prototype).", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbMaterial.SelectedIndex = 0;
            cbCondition.SelectedIndex = 0;
            nudMinWeight.Value = 0;
            nudMaxDistance.Value = 0;
        }

        private void btnMakeOffer_Click(object sender, EventArgs e)
        {
            var form = new FormMakeOffer();
            form.ShowDialog(this);
        }

        private void btnMyPickups_Click(object sender, EventArgs e)
        {
            var form = new FormPickup();
            form.ShowDialog(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: reload dgvListings from the database.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
