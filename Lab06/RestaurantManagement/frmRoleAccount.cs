using BusinessLogic;
using DataAccess;
using System;
using System.Data;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmRoleAccount : Form
    {
        private RoleAccountBL roleAccBL = new RoleAccountBL();
        private AccountBL accBL = new AccountBL();
        private RoleBL roleBL = new RoleBL();
        private bool isNew = false;

        public frmRoleAccount()
        {
            InitializeComponent();
        }

        private void frmRoleAccount_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            cboAccount.DataSource = accBL.GetAll();
            cboAccount.DisplayMember = "AccountName";
            cboAccount.ValueMember = "AccountName";

            cboRole.DataSource = roleBL.GetAll();
            cboRole.DisplayMember = "RoleName";
            cboRole.ValueMember = "ID";
        }

        private void LoadData()
        {
            dgvRoleAccount.DataSource = roleAccBL.GetAll();
        }

        private void ClearForm()
        {
            cboAccount.SelectedIndex = -1;
            cboRole.SelectedIndex = -1;
            chkActived.Checked = true;
            txtNotes.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isNew = true;
            ClearForm();
            cboAccount.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboAccount.SelectedIndex == -1 || cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tài khoản và quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RoleAccount ra = new RoleAccount()
            {
                AccountName = cboAccount.SelectedValue.ToString(),
                RoleID = Convert.ToInt32(cboRole.SelectedValue),
                Actived = chkActived.Checked,
                Notes = txtNotes.Text
            };

            if (isNew)
                roleAccBL.Insert(ra);
            else
                roleAccBL.Update(ra);

            LoadData();
            ClearForm();
            isNew = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoleAccount.CurrentRow != null)
            {
                string acc = dgvRoleAccount.CurrentRow.Cells["AccountName"].Value.ToString();
                int roleID = Convert.ToInt32(dgvRoleAccount.CurrentRow.Cells["RoleID"].Value);
                if (MessageBox.Show("Bạn có chắc muốn xóa quyền này khỏi tài khoản?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RoleAccount ra = new RoleAccount()
                    {
                        AccountName = acc,
                        RoleID = roleID,
                        Actived = chkActived.Checked,
                        Notes = txtNotes.Text
                    }; ;
                    roleAccBL.Delete(ra);
                    LoadData();
                    ClearForm();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
            isNew = false;
        }

        private void dgvRoleAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRoleAccount.CurrentRow != null)
            {
                cboAccount.Text = dgvRoleAccount.CurrentRow.Cells["AccountName"].Value.ToString();
                cboRole.Text = dgvRoleAccount.CurrentRow.Cells["RoleName"].Value.ToString();
                chkActived.Checked = Convert.ToBoolean(dgvRoleAccount.CurrentRow.Cells["Actived"].Value);
                txtNotes.Text = dgvRoleAccount.CurrentRow.Cells["Notes"].Value.ToString();
                isNew = false;
            }
        }

        public void LoadForAccount(string accountName)
        {
            cboAccount.SelectedValue = accountName;
            DataTable dt = roleAccBL.GetByAccountName(accountName);
            dgvRoleAccount.DataSource = dt;
            this.Text = $"Phân quyền cho tài khoản: {accountName}";
        }

    }
}
