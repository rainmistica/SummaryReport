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
    public partial class frmReuse : Form
    {
        public frmReuse()
        {
            InitializeComponent();
        }

        private void frmReuse_Load(object sender, EventArgs e)
        {
            FillUse();            
        }
        public void FillUse()
        {
            listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblTDriver WHERE Status = 'LOADED' ORDER BY Driver", cn);
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
        }

        private void frmReuse_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSum frm = new frmSum();
            frm.FillBN();
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.CheckedItems.Count; i++)
            {
                ListViewItem item = listView1.CheckedItems[i];
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("UPDATE tblTDriver SET Status='EMPTY' WHERE BNum=" + item.SubItems[0].Text, cn);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            MessageBox.Show("Done!");
            FillUse();

          

        }
    }
}
