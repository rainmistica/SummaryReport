using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace SummaryReport
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string dbFilePath =  System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf");
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Backup your Database?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                try
                {
                    File.Copy(dbFilePath, @"C:\SumDB.bak");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                MessageBox.Show("Backup Save in Drive C With FileNameSumDB.bak!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Diag == DialogResult.No)
            {}
            }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }
    }
}
