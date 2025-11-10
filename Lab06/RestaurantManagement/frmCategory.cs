using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmCategory : Form
    {
        private List<Category> listCategory;

        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            LoadCategoryDataToListView();
        }

        private void LoadCategoryDataToListView()
        {
            lsvCategory.Items.Clear();
            CategoryBL categoryBL = new CategoryBL();
            listCategory = categoryBL.GetAll();

            int count = 1;
            foreach (Category category in listCategory)
            {
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(category.ID.ToString());
                item.SubItems.Add(category.Name);
                item.SubItems.Add(category.Type.ToString());
                item.Tag = category;
                lsvCategory.Items.Add(item);
                count++;
            }

            lblStatistic.Text = $"Tổng số loại thực phẩm: {listCategory.Count}";
        }

        private void lsvCategory_Click(object sender, EventArgs e)
        {
            if (lsvCategory.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvCategory.SelectedItems[0];
                Category category = (Category)item.Tag;

                txtID.Text = category.ID.ToString();
                txtName.Text = category.Name;
                txtType.Text = category.Type.ToString();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = new Category
                {
                    Name = txtName.Text.Trim(),
                    Type = int.Parse(txtType.Text)
                };

                CategoryBL categoryBL = new CategoryBL();
                int result = categoryBL.Insert(category);

                if (result > 0)
                {
                    MessageBox.Show("Thêm loại thực phẩm thành công!", "Thông báo");
                    LoadCategoryDataToListView();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại thực phẩm: " + ex.Message, "Lỗi");
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại cần sửa!", "Thông báo");
                    return;
                }

                Category category = new Category
                {
                    ID = int.Parse(txtID.Text),
                    Name = txtName.Text.Trim(),
                    Type = int.Parse(txtType.Text)
                };

                CategoryBL categoryBL = new CategoryBL();
                int result = categoryBL.Update(category);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật loại thực phẩm thành công!", "Thông báo");
                   
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
                LoadCategoryDataToListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi");
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại cần xóa!", "Thông báo");
                    return;
                }

                DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa loại này không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    Category category = new Category
                    {
                        ID = int.Parse(txtID.Text),
                        Name = txtName.Text.Trim(),
                        Type = int.Parse(txtType.Text)
                    };

                    CategoryBL categoryBL = new CategoryBL();
                    int result = categoryBL.Delete(category);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa loại thực phẩm thành công!", "Thông báo");
                        LoadCategoryDataToListView();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Không thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtType.Clear();
            txtName.Focus();
        }
    }
}
