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
    public partial class frmSum : Form
    {
        int chk;
        public frmSum()
        {
            InitializeComponent();
        }

        private void frmSum_Load(object sender, EventArgs e)
        {
            lblfillDate.Text = DateTime.Now.ToShortDateString();
            FillBN();
            FillSBN();
            FillCust();
            FillDriver();
            FillList();        
        }
        public void FillBN()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT BNum FROM tblTDriver WHERE Status = 'EMPTY'", cn);
            cn.Open();
            SqlCeDataReader dr = cm.ExecuteReader();
            AutoCompleteStringCollection BNum = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                BNum.Add(dr.GetString(0));
            }
            txtBN.AutoCompleteCustomSource = BNum;
            cn.Close();
        }
        public void FillSBN()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT BNum FROM tblTruck", cn);
            cn.Open();
            SqlCeDataReader dr = cm.ExecuteReader();
            AutoCompleteStringCollection BNum = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                BNum.Add(dr.GetString(0));
            }
            txtSBN.AutoCompleteCustomSource = BNum;
            cn.Close();
        }
        public void FillCust()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT CustName FROM tblCust", cn);
            cn.Open();
            SqlCeDataReader dr = cm.ExecuteReader();
            AutoCompleteStringCollection CName = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                CName.Add(dr.GetString(0));
            }
            txtCust.AutoCompleteCustomSource = CName;
            txtSCust.AutoCompleteCustomSource = CName;
            cn.Close();
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
            txtSDriv.AutoCompleteCustomSource = DName;
            cn.Close();
        }
        public void FillList()
        {
            listView1.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblSum WHERE Date = '" + lblfillDate.Text + "' ORDER BY Sum_ID", cn);
            cn.Open();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Time"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Sum_ID"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close(); 
            lblCount.Text = listView1.Items.Count.ToString();
        }
        public void EdPN()
        {
            if (txtBN.Text == "")
            { }
            else
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT PNum,Driver FROM tblTDriver WHERE BNum = '" + txtBN.Text + "' AND Status = 'EMPTY'" , cn);
                cn.Open();
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    lblPN.Text = string.Empty;
                    txtDriv.Text = string.Empty;
                }
                else
                {
                    lblPN.Text = dt.Rows[0]["PNum"].ToString();
                    txtDriv.Text = dt.Rows[0]["Driver"].ToString();
                }
                cn.Close();
            }
            
        }
        public void EdSPN()
        {
            if (txtSBN.Text == "")
            { }
            else
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT PNum FROM tblTruck WHERE BNum = " + txtSBN.Text, cn);
                cn.Open();
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    lblSPN.Text = string.Empty;
                }
                else
                {
                    lblSPN.Text = dt.Rows[0]["PNum"].ToString();
                }
                cn.Close();
            }
        }
        public void ModifyStat()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            cn.Open();
            SqlCeCommand cm = new SqlCeCommand("UPDATE tblTDriver SET Status='LOADED' WHERE BNum=" + txtBN.Text, cn);
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void delStat()
        {
            SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
            cn.Open();
            SqlCeCommand cm = new SqlCeCommand("UPDATE tblTDriver SET Status='EMPTY' WHERE BNum=" + txtBN.Text, cn);
            cm.ExecuteNonQuery();
            cn.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            chk = 1;
            ClrScrn();
            txtBN.Enabled = true;
            btnAdd.Enabled = false;
            btnReTruck.Enabled = false;
            txtCust.Enabled = true;
            txtDriv.Enabled = true;
            dtDate.Enabled = true;
            dtTime.Enabled = true;
            btnUp.Enabled = true;
            gbSearch.Enabled = false;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";
            FillBN();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtBN.Text = item.SubItems[0].Text;
                lblPN.Text = item.SubItems[1].Text;
                txtCust.Text = item.SubItems[2].Text;
                txtDriv.Text = item.SubItems[3].Text;
                dtDate.Text = item.SubItems[4].Text;
                dtTime.Text = item.SubItems[5].Text;
                lblHSum.Text = item.SubItems[6].Text;
                btnEdit.Enabled = true;
                btnAdd.Enabled = false;
                btnReTruck.Enabled = false;
                btnDel.Enabled = true;
                btnUp.Enabled = false;
                gbSearch.Enabled = false;
                btnExt.Text = "Cancel";
               
            }
            else
            {
               // txtBN.Text = string.Empty;

            }
        }
        public void ClrScrn()
        {
            txtBN.Text = string.Empty;
            lblPN.Text = string.Empty;
            txtCust.Text = string.Empty;
            txtDriv.Text = string.Empty;
            txtBN.Enabled = false;
            txtCust.Enabled = false;
            txtDriv.Enabled = false;
            dtDate.Enabled = false;
            dtTime.Enabled = false;
        }
        public void ClrSrch()
        {
            txtSBN.Text = string.Empty;
            lblSPN.Text = string.Empty;
            txtSDriv.Text = string.Empty;
            txtSCust.Text = string.Empty;
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBN.Text) || String.IsNullOrEmpty(lblPN.Text) || String.IsNullOrEmpty(txtDriv.Text) || String.IsNullOrEmpty(txtCust.Text))
            {
                MessageBox.Show("Please Complete Details!");
                chk = 0;
            }
            if (chk == 1)
            {
                    int ctr ,cou;
                    SqlCeConnection con = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                    SqlCeCommand com = new SqlCeCommand("SELECT MAX(Sum_ID) as Tot FROM tblSum", con);
                    con.Open();
                    SqlCeDataAdapter da = new SqlCeDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows[0]["Tot"] !=DBNull.Value)
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
                    SqlCeCommand cm = new SqlCeCommand("INSERT INTO tblSum(Sum_ID,BNum,PNum,CustName,Driver,Date,Time) VALUES (@Sum_ID,@BNum,@PNum,@CustName,@Driver,@Date,@Time)", cn);
                    ctr = cou + 1;
                    cm.Parameters.AddWithValue("@Sum_ID", ctr);
                    cm.Parameters.AddWithValue("@BNum", txtBN.Text);
                    cm.Parameters.AddWithValue("@PNum", lblPN.Text);
                    cm.Parameters.AddWithValue("@CustName", txtCust.Text);
                    cm.Parameters.AddWithValue("@Driver", txtDriv.Text);
                    cm.Parameters.AddWithValue("@Date", dtDate.Text);
                    cm.Parameters.AddWithValue("@Time", dtTime.Text);
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
                    ModifyStat();
                }
                else if (chk == 2)
                {
                    SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                    cn.Open();
                    SqlCeCommand cm = new SqlCeCommand("UPDATE tblSum SET BNum=@BNum,PNum=@PNum,CustName=@CustName,Driver=@Driver,Date=@Date,Time=@Time WHERE Sum_ID=" + lblHSum.Text, cn);
                    cm.Parameters.AddWithValue("@BNum", txtBN.Text);
                    cm.Parameters.AddWithValue("@PNum", lblPN.Text);
                    cm.Parameters.AddWithValue("@CustName", txtCust.Text);
                    cm.Parameters.AddWithValue("@Driver", txtDriv.Text);
                    cm.Parameters.AddWithValue("@Date", dtDate.Text);
                    cm.Parameters.AddWithValue("@Time", dtTime.Text);
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
                    ModifyStat();
                }
            listView1.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUp.Enabled = false;
            btnReTruck.Enabled = true;
            btnDel.Enabled = false;
            btnExt.Text = "Exit";
            lblHSum.Text = string.Empty;
            gbSearch.Enabled = true;
            FillList();
            FillBN();
            ClrScrn();
            chk = 0;
           
        }

        private void txtBN_Leave(object sender, EventArgs e)
        {
            EdPN();
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
                    gbSearch.Enabled = true;
                    btnReTruck.Enabled = true;
                    ClrScrn();
                    FillBN();
                }
                else if (Diag == DialogResult.No)
                { }

                
               

            }
            else if (btnExt.Text == "Exit")
            {
                this.Close();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chk=2;
            txtBN.Enabled = true;
            txtCust.Enabled = true;
            txtDriv.Enabled = true;
            dtDate.Enabled = true;
            dtTime.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnUp.Enabled = true;
            btnDel.Enabled = false;
            listView1.Enabled = false;
            gbSearch.Enabled = false;
            btnExt.Text = "Cancel";
            FillBN();
        }

        private void txtBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to remove this data?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                cn.Open();
                SqlCeCommand cm = new SqlCeCommand("DELETE tblSum where Sum_ID=" + lblHSum.Text, cn);
                cm.ExecuteNonQuery();
                cn.Close();
                delStat();
                MessageBox.Show("Record Removed Successfully.");
                FillList();
                FillBN();
                ClrScrn();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
            else if (Diag==DialogResult.No)
            {
                FillList();
                FillBN();
                ClrScrn();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
            
              
         
        }

        private void frmSum_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to Close?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (cmbSearch.SelectedIndex == 0)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblSum WHERE Date >= '" + dtFDate.Text + "' AND Date <= '" + dtTDate.Text + "' ORDER BY Date ASC", cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Time"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Sum_ID"].ToString());
                    listView1.Items.Add(item);

                }
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblSum WHERE Date >= '" + dtFDate.Text + "' AND Date <= '" + dtTDate.Text + "' AND BNum = '" + txtSBN.Text + "' ORDER BY Date ASC", cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Time"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Sum_ID"].ToString());
                    listView1.Items.Add(item);

                }
            }
            else if (cmbSearch.SelectedIndex == 2)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblSum WHERE Date >= '" + dtFDate.Text + "' AND Date <= '" + dtTDate.Text + "' AND CustName = '" + txtSCust.Text + "' ORDER BY Date ASC", cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Time"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Sum_ID"].ToString());
                    listView1.Items.Add(item);

                }
            }
            else if (cmbSearch.SelectedIndex == 3)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblSum WHERE Date >= '" + dtFDate.Text + "' AND Date <= '" + dtTDate.Text + "' AND Driver = '" + txtSDriv.Text + "' ORDER BY Date ASC", cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Time"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Sum_ID"].ToString());
                    listView1.Items.Add(item);

                }

            }
            else if (cmbSearch.SelectedIndex == 4)
            {
                SqlCeConnection cn = new SqlCeConnection("Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "SumDB.sdf; Persist Security Info=False"));
                SqlCeCommand cm = new SqlCeCommand("SELECT * FROM tblSum WHERE Date >= '" + dtFDate.Text + "' AND Date <= '" + dtTDate.Text + "' AND BNum = '" + txtSBN.Text + "' AND CustName = '" + txtSCust.Text + "' AND Driver = '" + txtSDriv.Text + "' ORDER BY Date ASC", cn);
                SqlCeDataAdapter da = new SqlCeDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                    item.SubItems.Add(dt.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Time"].ToString());
                    item.SubItems.Add(dt.Rows[i]["Sum_ID"].ToString());
                    listView1.Items.Add(item);

                }

            }
            lblCount.Text = listView1.Items.Count.ToString();
            ClrSrch();

        }

        private void txtDriv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtSBN_Leave(object sender, EventArgs e)
        {
            EdSPN();
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Clear Search items? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Diag == DialogResult.Yes)
            {
                FillList();
                txtSBN.Text = string.Empty;
                lblSPN.Text = string.Empty;
                txtSCust.Text = string.Empty;
                txtSDriv.Text = string.Empty;
            }
            else if (Diag == DialogResult.No)
            {
               
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog1.FileName = "logs";
            saveFileDialog1.Title = "Export to Excel";
            StringBuilder sb = new StringBuilder();
            foreach (ColumnHeader ch in listView1.Columns)
            {
                sb.Append(ch.Text + ",");
            }
            sb.AppendLine();
            foreach (ListViewItem lvi in listView1.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    if (lvs.Text.Trim() == string.Empty)
                        sb.Append(" ,");
                    else
                        sb.Append(lvs.Text + ",");
                }
                sb.AppendLine();
            }
            sb.Append("Date and Time Printed: '" + DateTime.Now + "'");
            sb.AppendLine();
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(sb.ToString());
                sw.Close();
                MessageBox.Show("Data Export Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            
        }

        private void txtSDriv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtSCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void btnEmpTruck_Click(object sender, EventArgs e)
        {
            FrmEmptyTruck frm = new FrmEmptyTruck();
            frm.ShowDialog();
        }

        private void btnReTruck_Click(object sender, EventArgs e)
        {
            FillBN();
            frmReuse frm = new frmReuse();
            frm.ShowDialog();
        }
    }
}
