using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmRestaurant : Form
    {
        RestaurantBL restaurantBL = new RestaurantBL();
        List<Restaurant> listRestaurant;

        public frmRestaurant()
        {
            InitializeComponent();
        }

        private void frmRestaurant_Load(object sender, EventArgs e)
        {
            LoadDataToListView();
        }

        private void LoadDataToListView()
        {
            lsvRestaurant.Items.Clear();
            listRestaurant = restaurantBL.GetAll();

            foreach (Restaurant r in listRestaurant)
            {
                ListViewItem item = new ListViewItem(r.ID.ToString());
                item.SubItems.Add(r.Name);
                item.SubItems.Add(r.Address);
                item.SubItems.Add(r.Phone);
                item.SubItems.Add(r.Website);
                lsvRestaurant.Items.Add(item);
            }
        }

        private void lsvRestaurant_Click(object sender, EventArgs e)
        {
            if (lsvRestaurant.SelectedItems.Count == 0) return;
            ListViewItem item = lsvRestaurant.SelectedItems[0];

            txtID.Text = item.SubItems[0].Text;
            txtName.Text = item.SubItems[1].Text;
            txtAddress.Text = item.SubItems[2].Text;
            txtPhone.Text = item.SubItems[3].Text;
            txtWebsite.Text = item.SubItems[4].Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Restaurant r = new Restaurant
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Website = txtWebsite.Text
            };
            restaurantBL.Insert(r);
            LoadDataToListView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Restaurant r = new Restaurant
            {
                ID = int.Parse(txtID.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Website = txtWebsite.Text
            };
            restaurantBL.Update(r);
            LoadDataToListView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Restaurant r = new Restaurant
            {
                ID = int.Parse(txtID.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Website = txtWebsite.Text
            };
            restaurantBL.Delete(r);
            LoadDataToListView();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtWebsite.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
