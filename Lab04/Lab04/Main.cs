using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Main : Form
    {
        int action = -1;
        public Main()
        {
            InitializeComponent();
            this.Height = 280;
            SetEnableControl(false);
        }
        private void LoadForm()
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Table_GetAll, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DisplayListView(cmd.ExecuteReader());
                conn.Close();
            }
        }
        private void DisplayListView(SqlDataReader reader)
        {
            lvTable.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["TableCode"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Status"].ToString());
                item.SubItems.Add(reader["Seats"].ToString());
                item.SubItems.Add(reader["HallID"].ToString());

                lvTable.Items.Add(item);
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (IsTextCorrected())
            {
                if (Insert_Update_Delete(this.action) != 0)
                {
                    btnCancel.PerformClick();
                    LoadForm();
                }
                else
                    MessageBox.Show("Something gone wrong.\nAction: " + action, "Error", 0, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Incorrect text in textbox.", "Warning", 0, MessageBoxIcon.Warning);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.action = -1;
            FormResize(2);
            ClearText();
            SetEnableControl(false);
            txtTableCode.Enabled = false;
            lvTable.Enabled = true;
        }

        private void tsiSave_Click(object sender, EventArgs e)
        {
            FormResize(1);
            SetEnableControl(true);
            lvTable.Enabled = false;
            if (lvTable.SelectedItems.Count == 0)
            {
                this.action = 0;
            }
            else
            {
                GetData();
                this.action = 1;
            }
            txtTableCode.Focus();
        }

        private void tsiDelete_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure to reomve the object?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    GetData();
                    this.action = 2;
                    if (Insert_Update_Delete(this.action) == 0)
                        MessageBox.Show("Something went wrong", "Error", 0, MessageBoxIcon.Error);
                    this.action = -1;
                    ClearText();
                    LoadForm();
                }
            }
        }

        private void tsiInvoiceHistory_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show(this);
        }

        private int Insert_Update_Delete(int action)
        {
            try
            {
                using (SqlConnection conn = Ultilities.CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand(Ultilities.Table_InsertUpdateDelete, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
                    try
                    {
                        IDPara.Value = action == 0 ? 0 : Convert.ToInt32(lvTable.SelectedItems[0].SubItems[0].Text);
                        cmd.Parameters.Add(IDPara);
                        cmd.Parameters.Add("@TableCode", SqlDbType.NVarChar, 200).Value = txtTableCode.Text;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = txtName.Text;
                        cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Convert.ToInt32(txtStatus.Text);
                        cmd.Parameters.Add("@Seats", SqlDbType.Int).Value = Convert.ToInt32(txtSeat.Text);
                        cmd.Parameters.Add("@HallID", SqlDbType.Int).Value = Convert.ToInt32(txtHallID.Text);
                        cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while collect data.\n\n" + ex, "Error", 0, MessageBoxIcon.Error);
                        return 0;
                    }
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result > 0)
                        return (int)cmd.Parameters["@ID"].Value;
                    else return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error while trying contact to database.\n\n" + ex, "Error", 0, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n\n" + ex, "Error", 0, MessageBoxIcon.Error);
            }
            return 0;
        }
        private void FormResize(int mode)
        {
            if (mode == 1)
            {
                while (this.Height < 390)
                {
                    this.Height += 2;
                }
            }
            else if (mode == 2)
            {
                while (this.Height > 280)
                {
                    this.Height -= 2;
                }
            }
        }
        private void GetData()
        {
            if (lvTable.SelectedItems.Count > 0)
            {
                ListViewItem item = lvTable.SelectedItems[0];
                txtTableCode.Text = item.SubItems[1].Text;
                txtName.Text = item.SubItems[2].Text;
                txtStatus.Text = item.SubItems[3].Text;
                txtSeat.Text = item.SubItems[4].Text;
                txtHallID.Text = item.SubItems[5].Text;
            }
        }
        private void SetEnableControl(bool status)
        {
            lblTableCode.Visible = status;
            txtTableCode.Visible = status;
            txtTableCode.Enabled = status;

            lblName.Visible = status;
            txtName.Visible = status;
            txtName.Enabled = status;

            lblStatus.Visible = status;
            txtStatus.Visible = status;
            txtStatus.Enabled = status;

            lblSeat.Visible = status;
            txtSeat.Visible = status;
            txtSeat.Enabled = status;

            lblHallID.Visible = status;
            txtHallID.Visible = status;
            txtHallID.Enabled = status;

            btnConfirm.Visible = status;
            btnConfirm.Enabled = status;

            btnCancel.Visible = status;
            btnCancel.Enabled = status;
        }
        private void ClearText()
        {
            txtTableCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtSeat.Text = string.Empty;
            txtHallID.Text = string.Empty;
        }
        private bool IsTextCorrected()
        {
            if (!string.IsNullOrWhiteSpace(txtTableCode.Text))
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                    if (!string.IsNullOrWhiteSpace(txtStatus.Text) && txtStatus.Text.All(char.IsDigit))
                        if (!string.IsNullOrWhiteSpace(txtSeat.Text) && txtSeat.Text.All(char.IsDigit))
                            if (!string.IsNullOrWhiteSpace(txtHallID.Text) && txtHallID.Text.All(char.IsDigit))
                                return true;
            return false;
        }

        private void tsiDeselect_Click(object sender, EventArgs e)
        {
            lvTable.SelectedItems.Clear();
            tsiSave.Text = "Add";
        }

        private void lvTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count > 0)
            {
                tsiSave.Text = "Update";

                tsiDeselect.Visible = true;
                tsiDeselect.Enabled = true;

                tsiDelete.Visible = true;
                tsiDelete.Enabled = true;

                tsiViewInvoice.Visible = false;
                tsiViewInvoice.Enabled = false;
            }
            else
            {
                tsiDeselect.PerformClick();

                tsiDeselect.Visible = false;
                tsiDeselect.Enabled = false;

                tsiDelete.Visible = false;
                tsiDelete.Enabled = false;

                tsiViewInvoice.Visible = false;
                tsiViewInvoice.Enabled = false;
            }
        }
    }
}