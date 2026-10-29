using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// Transaction & Financial Tracking - receipt calculated from verified weight, plus settlement history.
    /// </summary>
    public partial class FormTransaction : Form
    {
        public FormTransaction()
        {
            InitializeComponent();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            // TODO: UPDATE Transaction.TransactionStatus = 'Completed' and save PaymentMethod.
            MessageBox.Show("Payment confirmed (UI prototype).", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt printing is not implemented yet.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: reload dgvTransactions from the database.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
