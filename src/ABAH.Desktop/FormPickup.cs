using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// Pickup Scheduling & Tracking - requested > accepted > on_the_way > collected > verified > completed.
    /// </summary>
    public partial class FormPickup : Form
    {
        public FormPickup()
        {
            InitializeComponent();
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            // TODO: UPDATE PickupSchedule.ScheduledTime.
            MessageBox.Show("Pickup rescheduled (UI prototype).", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            // TODO: move PickupSchedule.Status to the next value and recolor the matching lblStep* label.
            MessageBox.Show("Status updated to the next step (UI prototype).", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVerifyWeight_Click(object sender, EventArgs e)
        {
            var form = new FormWeightVerification();
            form.ShowDialog(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: reload dgvPickups from the database.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
