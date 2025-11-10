using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Account : Form
    {
        bool active = false;
        int action = -1;
        public Account()
        {
            InitializeComponent();
            this.Height = 290;
            SetEnableControl(false);
        }
        private void LoadForm(bool active)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                string command = active ?
                    "SELECT a.AccountName as AccountName, [Password], FullName, Email, Phone, DateCreated\n" +
                    "FROM Account a\n" +
                    "JOIN RoleAccount ra ON a.AccountName = ra.AccountName\n" +
                    "WHERE ra.Actived = 1;"
                    : Ultilities.Account_GetAll;
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();
                DisplayListView(cmd.ExecuteReader());
                conn.Close();
                cmd.Dispose();
            }
        }
        private void DisplayListView(SqlDataReader sqldata)
        {
            lvAccount.Items.Clear();
            while (sqldata.Read())
            {
                ListViewItem lvi = new ListViewItem(sqldata["AccountName"].ToString());

                lvi.SubItems.Add(sqldata["Password"].ToString());
                lvi.SubItems.Add(sqldata["FullName"].ToString());
                lvi.SubItems.Add(sqldata["Email"].ToString());
                lvi.SubItems.Add(sqldata["Phone"].ToString());
                lvi.SubItems.Add(sqldata["DateCreated"].ToString());

                lvAccount.Items.Add(lvi);
            }
        }

        private void Account_Load(object sender, EventArgs e)
        {
            LoadForm(this.active);
        }

        private void cbxActive_CheckedChanged(object sender, EventArgs e)
        {
            this.active = cbxActive.Checked;
            LoadForm(this.active);
        }

        private void tsiSave_Click(object sender, EventArgs e)
        {
            FormResize(1);
            SetEnableControl(true);
            gbxAccount.Enabled = false;
            if (lvAccount.SelectedItems.Count == 0)
            {
                this.action = 0;
                txtAName.Enabled = true;
            }
            else
            {
                GetData();
                this.action = 1;
            }
            txtName.Focus();
        }
        private void tsiDelete_Click(object sender, EventArgs e)
        {
            if (lvAccount.SelectedItems.Count>0)
            {
                if (MessageBox.Show("Are you sure to reomve the object?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    GetData();
                    this.action = 2;
                    if (Insert_Update_Delete(this.action) == 0)
                        MessageBox.Show("Something went wrong", "Error", 0, MessageBoxIcon.Error);
                    this.action = -1;
                    ClearText();
                    LoadForm(this.active);
                }
            }
        }

        private void tsiViewRole_Click(object sender, EventArgs e)
        {
            if (lvAccount.SelectedItems.Count > 0) {
                Role frmRole = new Role();
                frmRole.LoadRole(lvAccount.SelectedItems[0].SubItems[0].Text);
                frmRole.Show(this);
            }
        }

        private void tsiDeselect_Click(object sender, EventArgs e)
        {
            lvAccount.SelectedItems.Clear();
            tsiSave.Text = "Add";
        }

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccount.SelectedItems.Count > 0)
            {
                tsiSave.Text = "Update";

                tsiDeselect.Visible = true;
                tsiDeselect.Enabled = true;

                tsiDelete.Visible = true;
                tsiDelete.Enabled = true;

                tsiViewRole.Visible = true;
                tsiViewRole.Enabled = true;
            }
            else
            {
                tsiDeselect.PerformClick();

                tsiDeselect.Visible = false;
                tsiDeselect.Enabled = false;

                tsiDelete.Visible = false;
                tsiDelete.Enabled = false;

                tsiViewRole.Visible = false;
                tsiViewRole.Enabled = false;
            }
        }

        private void FormResize(int mode)
        {
            if (mode == 1)
            {
                while (this.Height < 380)
                {
                    this.Height += 2;
                }
            }
            else if (mode == 2)
            {
                while (this.Height > 290)
                {
                    this.Height -= 2;
                }
            }
        }
        private void GetData()
        {
            if(lvAccount.SelectedItems.Count > 0)
            {
                ListViewItem item = lvAccount.SelectedItems[0];
                txtAName.Text = item.SubItems[0].Text;
                txtPass.Text = item.SubItems[1].Text;
                txtName.Text = item.SubItems[2].Text;
                txtEmail.Text = item.SubItems[3].Text;
                txtPhone.Text = item.SubItems[4].Text;
            }
        }
        private void SetEnableControl(bool status)
        {
            lblAName.Visible = status;
            txtAName.Visible = status;

            lblPass.Visible = status;
            txtPass.Visible = status;
            txtPass.Enabled = status;

            lblName.Visible = status;
            txtName.Visible = status;
            txtName.Enabled = status;

            lblEmail.Visible = status;
            txtEmail.Visible = status;
            txtEmail.Enabled = status;

            lblPhone.Visible = status;
            txtPhone.Visible = status;
            txtPhone.Enabled = status;

            btnConfirm.Visible = status;
            btnConfirm.Enabled = status;

            btnCancel.Visible = status;
            btnCancel.Enabled = status;
        }
        private void ClearText()
        {
            txtAName.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
        private bool IsTextCorrected()
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                    if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                        if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                            return true;
            return false;
        }
        private int Insert_Update_Delete(int action)
        {
            try
            {
                using (SqlConnection conn = Ultilities.CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand(Ultilities.Account_InsertUpdateDelete, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = txtAName.Text;
                        cmd.Parameters.Add("@Password",SqlDbType.NVarChar, 200).Value = txtPass.Text;
                        cmd.Parameters.Add("@FullName", SqlDbType.NVarChar,1000).Value = txtName.Text;
                        cmd.Parameters.Add("@Email",SqlDbType.NVarChar,1000).Value = txtEmail.Text;
                        cmd.Parameters.Add("@Phone",SqlDbType.NVarChar,200).Value = txtPhone.Text;
                        cmd.Parameters.AddWithValue("@Action", this.action);
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
                        return result;
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
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (IsTextCorrected())
            {
                if (Insert_Update_Delete(this.action) != 0)
                {
                    btnCancel.PerformClick();
                    LoadForm(this.active);
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
            txtAName.Enabled = false;
            gbxAccount.Enabled = true;
        }
    }
}