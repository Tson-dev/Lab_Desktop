using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab05
{
    public partial class Role : Form
    {
        string accountName = string.Empty;
        int action = -1;
        public Role()
        {
            InitializeComponent();
        }
        public void LoadRole(string aName)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = conn.CreateCommand();
                this.accountName = aName;
                this.Text = "Role from " + accountName;
                cmd.CommandText =
                    "SELECT\n" +
                    "   CAST(CASE\n" +
                    $"       WHEN a.AccountName = '{this.accountName}' THEN 1\n" +
                    "       ELSE 0\n" +
                    "END AS BIT) AS Checked,\n" +
                    "   r.ID as RoleID,\n" +
                    "   Actived,\n" +
                    "   r.RoleName as RoleName,\n" +
                    "   r.[Path] as [Path]\n" +
                    "FROM dbo.Account a\n" +
                    "INNER JOIN dbo.RoleAccount ra ON a.AccountName = ra.AccountName\n" +
                    "INNER JOIN dbo.Role r ON ra.RoleID = r.ID\n" +
                    "ORDER BY RoleID ASC";

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Role");
                da.Fill(dt);
                dgvRole.DataSource = dt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
            }
        }

        private void Role_Load(object sender, EventArgs e)
        {
            LoadRole(this.accountName);
        }

        private void FormResize(int mode)
        {
            if (mode == 1)
            {
                while (this.Height < 400)
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
            DataGridViewRow row = dgvRole.CurrentRow;
            txtAccount.Text = row.Cells["colAccount"].Value.ToString();
            txtRoleID.Text = row.Cells["colRoleID"].Value.ToString();
            txtName.Text = row.Cells["colName"].Value.ToString();
            txtActived.Text = row.Cells["colActived"].Value.ToString();
            txtPath.Text = row.Cells["colPath"].Value.ToString();
        }
        private void SetEnableControl(bool status)
        {
            lblAccount.Visible = status;
            txtAccount.Visible = status;
            txtAccount.Enabled = status;

            lblID.Visible = status;
            txtRoleID.Visible = status;
            txtRoleID.Enabled = status;

            lblName.Visible = status;
            txtName.Visible = status;
            txtName.Enabled = status;

            lblActived.Visible = status;
            txtActived.Visible = status;
            txtActived.Enabled = status;

            lblPath.Visible = status;
            txtPath.Visible = status;
            txtPath.Enabled = status;

            btnConfirm.Visible = status;
            btnConfirm.Enabled = status;

            btnCancel.Visible = status;
            btnCancel.Enabled = status;
        }
        private void ClearText()
        {
            txtAccount.Text = string.Empty;
            txtRoleID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtActived.Text = string.Empty;
            txtPath.Text = string.Empty;
        }
        private bool IsTextCorrected()
        {
            if(!string.IsNullOrWhiteSpace(txtAccount.Text))
            if (!string.IsNullOrWhiteSpace(txtRoleID.Text) && txtRoleID.Text.All(char.IsDigit))
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                    if (!string.IsNullOrWhiteSpace(txtActived.Text) && txtActived.Text.All(x=>x == '0'|| x=='1'))
                        if (!string.IsNullOrWhiteSpace(txtPath.Text))
                            return true;
            return false;
        }
        private int Insert_Update_Delete(int action)
        {
            return 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (IsTextCorrected())
            {
                if (Insert_Update_Delete(this.action) != 0)
                {
                    btnCancel.PerformClick();
                    LoadRole(this.accountName);
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
            dgvRole.Enabled = true;
        }

        private void tsiDeselect_Click(object sender, EventArgs e)
        {
            if (dgvRole.CurrentRow != null)
            {
                dgvRole.ClearSelection();
                dgvRole.CurrentCell = null;
                tsiSave.Text = "Add";
            }
        }

        private void tsiSave_Click(object sender, EventArgs e)
        {
            FormResize(1);
            SetEnableControl(true);
            dgvRole.Enabled = false;
            if (dgvRole.CurrentRow == null)
            {
                this.action = 0;
            }
            else
            {
                GetData();
                this.action = 1;
            }
            txtName.Focus();
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRole.CurrentCell != null)
            {
                tsiSave.Text = "Update";
            }
        }
    }
}
