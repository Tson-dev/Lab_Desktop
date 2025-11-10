using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace RestaurantManagement
{
    public partial class frmFood : Form
    {
        List<Category> listCategory = new List<Category>();
        List<Food> listFood = new List<Food>();
        Food foodCurrent = new Food();
        public frmFood()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtPrice.Text = "0";
            txtUnit.Text = string.Empty;
            txtNotes.Text = string.Empty;
            if (cbxCategory.Items.Count > 0)
                cbxCategory.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int result = InsertFood();
            if (result > 0)
            {
                MessageBox.Show("Success adding food.");
                LoadFoodDataToListView();
            }
            else
                MessageBox.Show("Adding Failed.");
        }

        private int InsertFood()
        {
            Food food = new Food();
            food.ID = 0;
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Textbox is empty. Pls enter information into textbox");
            else
            {
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                food.Price = int.TryParse(txtPrice.Text, out int price) ? price : 0;
                food.FoodCategoryID = int.Parse(cbxCategory.SelectedValue.ToString());
                FoodBL foodBL = new FoodBL();
                return foodBL.Insert(food);
            }
            return -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int result = UpdateFood();
            if (result > 0)
            {
                MessageBox.Show("Update Success.");
                LoadFoodDataToListView();
            }
            else
                MessageBox.Show("Updating Failed.");
        }

        private int UpdateFood()
        {
            Food food = foodCurrent;
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Textbox is empty. Pls enter information into textbox");
            else
            {
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                food.Price = int.TryParse(txtPrice.Text, out int price) ? price : 0;
                food.FoodCategoryID = int.Parse(cbxCategory.SelectedValue.ToString());
                FoodBL foodBL = new FoodBL();
                return foodBL.Update(food);
            }
            return -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete this item?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                FoodBL foodBL = new FoodBL();
                if (foodBL.Delete(foodCurrent) > 0)
                {
                    MessageBox.Show("Success remove item.");
                    LoadFoodDataToListView();
                }
                else MessageBox.Show("Remove failed.");
            }
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodDataToListView();
        }
        private void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL();

            listCategory = categoryBL.GetAll();

            cbxCategory.DataSource = listCategory;
            cbxCategory.ValueMember = "ID";
            cbxCategory.DisplayMember = "Name";
        }
        private void LoadFoodDataToListView()
        {
            FoodBL foodBL = new FoodBL();

            listFood = foodBL.GetAll();
            int count = 1;

            lsvFood.Items.Clear();

            foreach(var food in listFood)
            {
                ListViewItem item = lsvFood.Items.Add(count.ToString());
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString());

                string foodName = listCategory.Find(x => x.ID == food.FoodCategoryID).Name;
                item.SubItems.Add(foodName);
                item.SubItems.Add(food.Notes);
                count++;
            }

            lbStatistic.Text = $"Statistic: {listFood.Count}";
        }

        private void lsvFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < lsvFood.Items.Count; i++)
            {
                if (lsvFood.Items[i].Selected)
                {
                    foodCurrent = listFood[i];
                    txtName.Text = foodCurrent.Name;
                    txtUnit.Text = foodCurrent.Unit;
                    txtPrice.Text = foodCurrent.Price.ToString();
                    txtNotes.Text = foodCurrent.Notes;

                    cbxCategory.SelectedIndex = listCategory.FindIndex(x => x.ID == foodCurrent.FoodCategoryID);
                }
            }
        }
    }
}
