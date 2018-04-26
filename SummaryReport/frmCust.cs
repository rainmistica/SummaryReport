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
    public partial class frmCust : Form
    {
        int chk;
        public frmCust()
        {
            InitializeComponent();
        }

        private void frmCust_Load(object sender, EventArgs e)
        {
            FillList();
        }
        public void FillList()
        {
            listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblCust ORDER BY CustName", cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["Cus_ID"].ToString());
                    item.SubItems.Add(dt.Rows[i]["CustName"].ToString());
                    listView1.Items.Add(item);
                }
                lblCount.Text = listView1.Items.Count.ToString();
                lblID.Text = string.Empty;
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                lblID.Text = item.SubItems[0].Text;
                txtCN.Text = item.SubItems[1].Text;
                btnEdit.Enabled = true;
                btnAdd.Enabled = false;
                btnDel.Enabled = true;
                btnUp.Enabled = false;
                btnExt.Text = "Cancel";
                
            }
            else
            {
               lblID.Text = string.Empty;
               txtCN.Text = string.Empty;
                
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
                    txtCN.Text = string.Empty;
                    txtCN.Enabled = false;
                    FillList();

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

        private void frmCust_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            chk = 1;
            txtCN.Enabled = true;
            btnAdd.Enabled = false;
            btnUp.Enabled = true;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chk = 2;
            txtCN.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnUp.Enabled = true;
            btnDel.Enabled = false;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCN.Text))
            {
                MessageBox.Show("Please Complete Details!");
                chk = 0;
            }
            if (chk == 1)
            {
                int ctr, cou;
                SqlCeConnection con = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand com = new SqlCeCommand("SELECT MAX(Cus_ID) as Tot FROM tblCust", con);
                con.Open();
                SqlCeDataAdapter da = new SqlCeDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0]["Tot"] != DBNull.Value)
                {
                    lblSum.Text = dt.Rows[0]["Tot"].ToString();
                }
                else
                {
                    lblSum.Text = "0";

                }
                con.Close();
                cou = Convert.ToInt32(lblSum.Text);
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("INSERT INTO tblCust (Cus_ID,CustName) VALUES (@Cus_ID,@CustName)", cn);
                ctr = cou + 1;
                cm.Parameters.AddWithValue("Cus_ID", ctr);
                cm.Parameters.AddWithValue("CustName", txtCN.Text);
                try
                {
                    int affectedRows = cm.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Insert Success!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCeCommand cm = new SqlCeCommand("UPDATE tblCust SET CustName=@CustName WHERE Cus_ID=" + lblID.Text, cn);
                cm.Parameters.AddWithValue("@CustName", txtCN.Text);
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
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUp.Enabled = false;
            btnDel.Enabled = false;
            btnExt.Text = "Exit";
            lblSum.Text = string.Empty;
            lblID.Text = string.Empty;
            FillList();
            txtCN.Text = string.Empty;
            txtCN.Enabled = false;
            chk = 0;

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to remove this data?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("DELETE tblCust where Cus_ID = " + lblID.Text, cn);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record Removed Successfully.");
                FillList();
                txtCN.Text = string.Empty;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                btnExt.Text = "Exit";
            }
            else if (Diag == DialogResult.No)
            {
                FillList();
                txtCN.Text = string.Empty;
                txtCN.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                btnExt.Text = "Exit";
            }
        }
    }
}
