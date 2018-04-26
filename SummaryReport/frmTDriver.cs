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
    public partial class frmTDriver : Form
    {
        int chk;
        public frmTDriver()
        {
            InitializeComponent();
        }

        private void frmTDriver_Load(object sender, EventArgs e)
        {
            FillListView();
            FillDriver();
        }
        public void FillListView()
        {
            listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblTDriver ORDER BY BNum", cn);
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
        public void FillDriver()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT LName FROM tblDriver", cn);
            cn.Open();
            SqlCeDataReader dr = cm.ExecuteReader();
            AutoCompleteStringCollection DName = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                DName.Add(dr.GetString(0));
            }
            txtDriv.AutoCompleteCustomSource = DName;
            cn.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtBN.Text = item.SubItems[0].Text;
                txtPN.Text = item.SubItems[1].Text;
                txtType.Text = item.SubItems[2].Text;
                txtDriv.Text = item.SubItems[3].Text;
                txtDriv.Enabled = false;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnUp.Enabled = false;
                btnExt.Text = "Cancel";
            }
            else
            {
                txtDriv.Enabled = false;
                txtBN.Text = string.Empty;
                txtPN.Text = string.Empty;
                txtType.Text = string.Empty;
                txtDriv.Text = string.Empty;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chk = 1;
            txtDriv.Enabled = true;
            btnEdit.Enabled = false;
            btnUp.Enabled = true;
            btnDel.Enabled = false;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";
        }

        private void btnExt_Click(object sender, EventArgs e)
        {
            if (btnExt.Text == "Cancel")
            {
                DialogResult Diag = new DialogResult();
                Diag = MessageBox.Show("Do you want to Cancel? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    btnEdit.Enabled = false;
                    btnUp.Enabled = false;
                    btnDel.Enabled = false;
                    btnExt.Text = "Exit";
                    listView1.Enabled = true;
                    txtDriv.Text = string.Empty;
                    txtDriv.Enabled = false;
                    FillListView();

                }
                else if (Diag == DialogResult.No)
                {
                }
            }
            else if (btnExt.Text == "Exit")
            {
                this.Close();

            }
        }

        private void frmTDriver_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDriv.Text))
            {
                MessageBox.Show("Please Complete Details!");
                chk = 0;
            }
            else if (chk == 1)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("UPDATE tblTDriver SET Driver=@Driver WHERE BNum=" + txtBN.Text, cn);
                cm.Parameters.AddWithValue("@Driver", txtDriv.Text);
                try
                {
                    int affectedRows = cm.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Edit Success!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Edit failed!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cn.Close();
            }
            listView1.Enabled = true;
            btnEdit.Enabled = false;
            btnUp.Enabled = false;
            btnDel.Enabled = false;
            btnExt.Text = "Exit";
            txtBN.Text = string.Empty;
            txtPN.Text = string.Empty;
            txtType.Text = string.Empty;
            txtDriv.Text = string.Empty;
            txtDriv.Enabled = false;
            FillListView();
            chk = 0;
        }

        private void txtDriv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Remove the Driver of this Truck?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                txtDriv.Text = string.Empty;
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("UPDATE tblTDriver SET Driver=@Driver WHERE BNum=" + txtBN.Text, cn);
                cm.Parameters.AddWithValue("@Driver", txtDriv.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record Removed Successfully.");
                FillListView();
                txtDriv.Text = string.Empty;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                btnExt.Text = "Exit";
            }
            else if (Diag == DialogResult.No)
            {
                FillListView();
                txtDriv.Text = string.Empty;
                txtDriv.Enabled = false;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                btnExt.Text = "Exit";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblTDriver WHERE Type = '" + comboBox1.Text + "' ORDER BY BNum", cn);
            cn.Open();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                item.SubItems.Add(dt.Rows[i]["Status"].ToString());
                listView1.Items.Add(item);
            }
            cn.Close();
            lblCount.Text = listView1.Items.Count.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
