using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SummaryReport
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Admin" && txtPass.Text == "1234")
            {
                MessageBox.Show("Access Granted!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                this.Hide();
                var form2 = new FrmMain();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Access Denied!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to Close this application?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
