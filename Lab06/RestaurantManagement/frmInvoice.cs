using BusinessLogic;
using DataAccess;
using System;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmInvoice : Form
    {
        InvoiceBL invoiceBL = new InvoiceBL();
        int isNew = -1;

        public frmInvoice()
        {
            InitializeComponent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            LoadInvoice();
        }

        private void LoadInvoice()
        {
            dgvInvoice.DataSource = invoiceBL.GetAll();
            dgvInvoice.ClearSelection();
        }

        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoice.CurrentRow != null)
            {
                txtID.Text = dgvInvoice.CurrentRow.Cells["ID"].Value.ToString();
                txtName.Text = dgvInvoice.CurrentRow.Cells["Name"].Value.ToString();
                txtTableID.Text = dgvInvoice.CurrentRow.Cells["TableID"].Value.ToString();
                txtTotal.Text = dgvInvoice.CurrentRow.Cells["Total"].Value.ToString();
                txtDiscount.Text = dgvInvoice.CurrentRow.Cells["Discount"].Value.ToString();
                txtTax.Text = dgvInvoice.CurrentRow.Cells["Tax"].Value.ToString();
                txtAccountID.Text = dgvInvoice.CurrentRow.Cells["AccountID"].Value.ToString();
                chkPaid.Checked = (int)dgvInvoice.CurrentRow.Cells["Status"].Value == 1;
                dtpDate.Value = Convert.ToDateTime(dgvInvoice.CurrentRow.Cells["CheckoutDate"].Value);
            }
        }

        private void dgvInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoice.CurrentRow != null)
            {
                int invoiceID = Convert.ToInt32(dgvInvoice.CurrentRow.Cells["ID"].Value);
                frmInvoiceDetail f = new frmInvoiceDetail();
                f.InvoiceID = invoiceID; // truyền ID sang form chi tiết
                f.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isNew = 0;
            ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Invoice inv = new Invoice()
                {
                    Name = txtName.Text,
                    TableID = int.Parse(txtTableID.Text),
                    Total = double.Parse(txtTotal.Text),
                    Discount = double.Parse(txtDiscount.Text),
                    Tax = double.Parse(txtTax.Text),
                    Status = chkPaid.Checked ? 1 : 0,
                    AccountID = txtAccountID.Text,
                    CheckoutDate = dtpDate.Value
                };

                invoiceBL.Update(inv);
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoice();
                ClearForm();
                isNew = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa.");
                return;
            }

            int id = int.Parse(txtID.Text);
            if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Invoice inv = new Invoice()
                {
                    Name = txtName.Text,
                    TableID = int.Parse(txtTableID.Text),
                    Total = double.Parse(txtTotal.Text),
                    Discount = double.Parse(txtDiscount.Text),
                    Tax = double.Parse(txtTax.Text),
                    Status = chkPaid.Checked ? 1 : 0,
                    AccountID = txtAccountID.Text,
                    CheckoutDate = dtpDate.Value
                };
                invoiceBL.Delete(inv);
                LoadInvoice();
                ClearForm();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoice();
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtName.Clear();
            txtTableID.Clear();
            txtTotal.Clear();
            txtDiscount.Clear();
            txtTax.Clear();
            txtAccountID.Clear();
            chkPaid.Checked = false;
            dtpDate.Value = DateTime.Now;
        }
    }
}
