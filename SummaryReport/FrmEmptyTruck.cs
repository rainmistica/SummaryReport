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
    public partial class FrmEmptyTruck : Form
    {
        public FrmEmptyTruck()
        {
            InitializeComponent();
        }

        private void FrmEmptyTruck_Load(object sender, EventArgs e)
        {
            FillEmptyTruck();
        }
        public void FillEmptyTruck()
        {
            listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT DISTINCT Bnum, PNum, Type,tblTDriver.Driver FROM tblTDriver WHERE tblTDriver.Status = 'EMPTY' ORDER BY BNum", cn);
            try
            {
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    listView1.Items.Add(item);
                }
                lblCount.Text = listView1.Items.Count.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FillEmptyTruck();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dtSearch.Text) || String.IsNullOrEmpty(cbSearch.Text))
            {
                MessageBox.Show("Error in Search Parameters!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listView1.Items.Clear();
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT DISTINCT tblTDriver.Bnum, tblTDriver.PNum, tblTDriver.Type, tblTDriver.Driver FROM tblTDriver CROSS JOIN tblSum WHERE (tblSum.Date = '" + dtSearch.Text + "') AND (tblTDriver.Status = 'EMPTY') AND (tblTDriver.Type = '" + cbSearch.Text + "') ORDER BY tblTDriver.Driver", cn);

                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    listView1.Items.Add(item);
                }
                lblCount.Text = listView1.Items.Count.ToString();
            }
        }
    }
}
