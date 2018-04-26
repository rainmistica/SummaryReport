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
    public partial class frmTrucks : Form
    {
        int chk;
        public frmTrucks()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtBN.Text = item.SubItems[0].Text;
                lblBN.Text = item.SubItems[0].Text;
                txtPN.Text = item.SubItems[1].Text;
                txtPP.Text = item.SubItems[2].Text;
                txtBG.Text = item.SubItems[3].Text;
            }
            else
            {
                txtBN.Text = string.Empty;
                txtPN.Text = string.Empty;
                txtPP.Text = string.Empty;
                txtBG.Text = string.Empty;
            }
        }

        public void FillList()
        {
            listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblTruck ORDER BY BNum", cn);
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
                    item.SubItems.Add(dt.Rows[i]["BGar"].ToString());
                    listView1.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblCount.Text = listView1.Items.Count.ToString();
        }
        public void ClrScrn()
        {
            txtBN.Text = string.Empty;
            txtPN.Text = string.Empty;
            txtPP.Text = string.Empty;
            txtBG.Text = string.Empty;
            txtBN.Enabled = false;
            txtPN.Enabled = false;
            txtPP.Enabled = false;
            txtBG.Enabled = false;
        }
        public void AddTruck()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            cn.Open();
            SqlCeCommand cm = new SqlCeCommand("INSERT INTO tblTDriver(BNum,PNum,Type,Status) VALUES (@BNum, @PNum, @Type,'EMPTY')", cn);      
            cm.Parameters.AddWithValue("@BNum", txtBN.Text);
            cm.Parameters.AddWithValue("@PNum", txtPN.Text);
            cm.Parameters.AddWithValue("@Type", txtPP.Text);
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void EditTruck()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            cn.Open();
            SqlCeCommand cm = new SqlCeCommand("UPDATE tblTDriver SET BNum=@BNum,PNum=@PNum,Type=@Type WHERE BNum=" + lblBN.Text, cn);
            cm.Parameters.AddWithValue("@BNum", txtBN.Text);
            cm.Parameters.AddWithValue("@PNum", txtPN.Text);
            cm.Parameters.AddWithValue("@Type", txtPP.Text);
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void DelTruck()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            cn.Open();
            SqlCeCommand cm = new SqlCeCommand("DELETE tblTDriver where BNum = " + lblBN.Text, cn);
            cm.Parameters.AddWithValue("@BNum", lblBN.Text);
            cm.ExecuteNonQuery();
            cn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FillList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chk = 2;
            txtBN.Enabled = true;
            txtPN.Enabled = true;
            txtPP.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnUp.Enabled = true;
            btnDel.Enabled = false;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to remove this data?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("DELETE tblTruck where BNum = " + lblBN.Text, cn);
                cm.Parameters.AddWithValue("@BNum", lblBN.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                DelTruck();
                MessageBox.Show("Record Removed Successfully.");
                FillList();
                ClrScrn();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
            else if (Diag == DialogResult.No)
            {
                FillList();
                ClrScrn();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
            
            
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBN.Text) || String.IsNullOrEmpty(txtPN.Text) || String.IsNullOrEmpty(txtPP.Text) || String.IsNullOrEmpty(txtBG.Text))
            {
                MessageBox.Show("Please Complete Details!");
                chk = 0;
            }
            if (chk == 1)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("INSERT INTO tblTruck(BNum,PNum,Type,BGar) VALUES (@BNum, @PNum, @Type, @BGar)", cn);
                cm.Parameters.AddWithValue("@BNum", txtBN.Text);
                cm.Parameters.AddWithValue("@PNum", txtPN.Text);
                cm.Parameters.AddWithValue("@Type", txtPP.Text);
                cm.Parameters.AddWithValue("@BGar", txtBG.Text);
                try
                {
                    int affectedRows = cm.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Insert Success!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cn.Close();
                        AddTruck();
                    }
                    else
                    {
                        MessageBox.Show("Insert failed!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cn.Close();
                
            }
            else if (chk == 2)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("UPDATE tblTruck SET BNum=@BNum,PNum=@PNum,Type=@Type,BGar=@BGar WHERE BNum=" + lblBN.Text, cn);
                cm.Parameters.AddWithValue("@BNum", txtBN.Text);
                cm.Parameters.AddWithValue("@PNum", txtPN.Text);
                cm.Parameters.AddWithValue("@Type", txtPP.Text);
                cm.Parameters.AddWithValue("@BGar", txtBG.Text);

                try
                {
                    int affectedRows = cm.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Edit Success!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditTruck();
                        cn.Close();
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
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUp.Enabled = false;
            btnDel.Enabled = false;
            btnExt.Text = "Exit";
            lblBN.Text = string.Empty;
            FillList();
            ClrScrn();
            chk = 0;
        }

        private void txtBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtBG_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtPN_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            chk = 1;
            txtBN.Enabled = true;
            btnAdd.Enabled = false;
            txtPN.Enabled = true;
            txtPP.Enabled = true;
            btnUp.Enabled = true;
            txtBG.Enabled = true;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                lblBN.Text = item.SubItems[0].Text;
                txtBN.Text = item.SubItems[0].Text;
                txtPN.Text = item.SubItems[1].Text;
                txtPP.Text = item.SubItems[2].Text;
                txtBG.Text = item.SubItems[3].Text;
                btnEdit.Enabled = true;
                btnAdd.Enabled = false;
                btnDel.Enabled = true;
                btnUp.Enabled = false;
                btnExt.Text = "Cancel";
            }
            else
            {

            }
        }

        private void btnExt_Click(object sender, EventArgs e)
        {
            if (btnExt.Text == "Cancel")
            {
                DialogResult Diag = new DialogResult();
                Diag = MessageBox.Show("Do you want to Cancel? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnUp.Enabled = false;
                    btnDel.Enabled = false;
                    btnExt.Text = "Exit";
                    listView1.Enabled = true;
                    ClrScrn();

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

        private void frmTrucks_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblTruck WHERE Type = '" + comboBox1.Text + "' ORDER BY Bnum ASC", cn);
            cn.Open();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                item.SubItems.Add(dt.Rows[i]["BGar"].ToString());
                listView1.Items.Add(item);
            }
            cn.Close();
            lblCount.Text = listView1.Items.Count.ToString();

        }
}
}
