using BusinessLogic;
using DataAccess;
using System;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmAccount : Form
    {
        private AccountBL bl = new AccountBL();
        private bool isNew = false;
        public frmAccount()
        {
            InitializeComponent();
        }

        private void dgvAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAccount.CurrentRow != null)
            {
                string accName = dgvAccount.CurrentRow.Cells["AccountName"].Value.ToString();

                frmRoleAccount frm = new frmRoleAccount();
                frm.LoadForAccount(accName);
                frm.ShowDialog();
            }
        }


        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadData();
            btnSave.Enabled = false;
        }

        private void LoadData()
        {
            dgvAccount.DataSource = bl.GetAll();
        }

        private void ClearForm()
        {
            txtAccountName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isNew = true;
            ClearForm();
            txtAccountName.Focus();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Account acc = new Account()
            {
                AccountName = txtAccountName.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            if (isNew)
                bl.Insert(acc);
            else
                bl.Update(acc);

            LoadData();
            ClearForm();
            isNew = false;
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow != null)
            {
                string accName = dgvAccount.CurrentRow.Cells["AccountName"].Value.ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Account acc = new Account()
                    {
                        AccountName = txtAccountName.Text,
                        Password = txtPassword.Text,
                        FullName = txtFullName.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text
                    };
                    bl.Delete(acc);
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
            btnSave.Enabled = false;
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAccount.CurrentRow != null)
            {
                txtAccountName.Text = dgvAccount.CurrentRow.Cells["AccountName"].Value.ToString();
                txtPassword.Text = dgvAccount.CurrentRow.Cells["Password"].Value.ToString();
                txtFullName.Text = dgvAccount.CurrentRow.Cells["FullName"].Value.ToString();
                txtEmail.Text = dgvAccount.CurrentRow.Cells["Email"].Value.ToString();
                txtPhone.Text = dgvAccount.CurrentRow.Cells["Phone"].Value.ToString();
                isNew = false;
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;
        }
    }
}
