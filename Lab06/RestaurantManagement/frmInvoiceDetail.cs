using BusinessLogic;
using DataAccess;
using System;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmInvoiceDetail : Form
    {
        InvoiceDetailBL detailBL = new InvoiceDetailBL();

        public frmInvoiceDetail()
        {
            InitializeComponent();
        }

        public int InvoiceID { get; set; }

        private void frmInvoiceDetail_Load(object sender, EventArgs e)
        {
            if (InvoiceID > 0)
            {
                txtInvoiceID.Text = InvoiceID.ToString();
                LoadDetails();
            }
        }

        private void LoadDetails()
        {
            if (!string.IsNullOrWhiteSpace(txtInvoiceID.Text))
            {
                int invoiceID = int.Parse(txtInvoiceID.Text);
                dgvDetails.DataSource = detailBL.GetByInvoiceID(invoiceID);
            }
            else
            {
                dgvDetails.DataSource = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInvoiceID.Text) || string.IsNullOrWhiteSpace(txtFoodID.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã hóa đơn và Mã món ăn!");
                    return;
                }

                InvoiceDetail detail = new InvoiceDetail()
                {
                    InvoiceID = int.Parse(txtInvoiceID.Text),
                    FoodID = int.Parse(txtFoodID.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Price = double.Parse(txtPrice.Text)
                };

                detailBL.Insert(detail);
                MessageBox.Show("Lưu chi tiết hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDetails();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceID.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã hóa đơn để xóa chi tiết!");
                return;
            }

            int invoiceID = int.Parse(txtInvoiceID.Text);
            if (MessageBox.Show("Bạn có chắc muốn xóa tất cả chi tiết của hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                detailBL.DeleteByInvoice(invoiceID);
                LoadDetails();
                ClearForm();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.CurrentRow != null)
            {
                txtID.Text = dgvDetails.CurrentRow.Cells["ID"].Value.ToString();
                txtInvoiceID.Text = dgvDetails.CurrentRow.Cells["InvoiceID"].Value.ToString();
                txtFoodID.Text = dgvDetails.CurrentRow.Cells["FoodID"].Value.ToString();
                txtFoodName.Text = dgvDetails.CurrentRow.Cells["FoodName"].Value.ToString();
                txtQuantity.Text = dgvDetails.CurrentRow.Cells["Quantity"].Value.ToString();
                txtPrice.Text = dgvDetails.CurrentRow.Cells["Price"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtInvoiceID.Clear();
            txtFoodID.Clear();
            txtFoodName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }
    }
}
