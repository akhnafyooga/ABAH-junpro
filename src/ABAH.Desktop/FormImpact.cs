using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// Climate Impact Dashboard - total kg diverted, environmental points, transaction count and impact history.
    /// </summary>
    public partial class FormImpact : Form
    {
        public FormImpact()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // TODO: reload dgvHistory and the summary labels using the selected period/material.
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: reload the impact summary from ImpactRecord.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
