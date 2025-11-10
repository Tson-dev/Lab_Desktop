using BusinessLogic;
using DataAccess;
using System;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmRole : Form
    {
        private RoleBL bl = new RoleBL();
        private bool isNew = false;

        public frmRole()
        {
            InitializeComponent();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvRole.DataSource = bl.GetAll();
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtRoleName.Clear();
            txtPath.Clear();
            txtNotes.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isNew = true;
            ClearForm();
            txtRoleName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Role role = new Role()
            {
                ID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : int.Parse(txtID.Text),
                RoleName = txtRoleName.Text,
                Path = txtPath.Text,
                Notes = txtNotes.Text
            };

            if (isNew)
                bl.Insert(role);
            else
                bl.Update(role);

            LoadData();
            ClearForm();
            isNew = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRole.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvRole.CurrentRow.Cells["ID"].Value);
                if (MessageBox.Show("Bạn có chắc muốn xóa quyền này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Role role = new Role()
                    {
                        ID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : int.Parse(txtID.Text),
                        RoleName = txtRoleName.Text,
                        Path = txtPath.Text,
                        Notes = txtNotes.Text
                    };
                    bl.Delete(role);
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

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRole.CurrentRow != null)
            {
                txtID.Text = dgvRole.CurrentRow.Cells["ID"].Value.ToString();
                txtRoleName.Text = dgvRole.CurrentRow.Cells["RoleName"].Value.ToString();
                txtPath.Text = dgvRole.CurrentRow.Cells["Path"].Value.ToString();
                txtNotes.Text = dgvRole.CurrentRow.Cells["Notes"].Value.ToString();
                isNew = false;
            }
        }
    }
}
