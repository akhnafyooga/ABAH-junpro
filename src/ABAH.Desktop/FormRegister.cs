using System;
using System.Windows.Forms;

namespace ABAH.Desktop
{
    /// <summary>
    /// User Accounts & Dynamic Roles - registration (one account may hold several roles).
    /// </summary>
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Name, email, and password are required.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkProducer.Checked && !chkCollector.Checked && !chkProcessor.Checked && !chkPartner.Checked)
            {
                MessageBox.Show("Please select at least one role.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO (database module): hash the password and INSERT the user + roles into PostgreSQL.
            MessageBox.Show("Registration successful. You can now log in.", "ABAH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
