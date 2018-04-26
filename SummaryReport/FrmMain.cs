using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
namespace SummaryReport
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
            timer1.Enabled = true;
            timer1.Start();
            

        }

        private void listOfTrucksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrucks sum = new frmTrucks();
            sum.ShowDialog();
        }

        private void listOfDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriver sum = new frmDriver();
            sum.ShowDialog();
        }

        private void listOfCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCust sum = new frmCust();
            sum.ShowDialog();
        }

        private void truckAndDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTDriver sum = new frmTDriver();
            sum.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Logout this session?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                this.Hide();
                var form2 = new frmLogin();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
             
            }
            else if (Diag == DialogResult.No)
            {
               
            }
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup sum = new frmBackup();
            sum.ShowDialog();
        }

        private void resetDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DO YOU WANT TO RESET WHOLE DATABASE?(HUWAG GALAWIN KUNG HINDI ALAM KUNG ANO ANG INYONG GINAGAWA AT KUNG HINDI KAYO OTORISADO NA GAWIN ITO)","WARNING!",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
        }

        private void modifyFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Open? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Diag == DialogResult.Yes)
            {
                frmSum sum = new frmSum();
                sum.ShowDialog(); 
            }
            else if (Diag == DialogResult.No)
            {
            }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox sum = new AboutBox();
            sum.ShowDialog(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
