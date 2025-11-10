using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmHall : Form
    {
        private List<Hall> listHall;
        private List<Restaurant> listRestaurant;

        public frmHall()
        {
            InitializeComponent();
        }

        private void frmHall_Load(object sender, EventArgs e)
        {
            LoadRestaurant();
            LoadHallToListView();
        }

        private void LoadRestaurant()
        {
            RestaurantBL restaurantBL = new RestaurantBL();
            listRestaurant = restaurantBL.GetAll();

            cbbRestaurant.DataSource = listRestaurant;
            cbbRestaurant.DisplayMember = "Name";
            cbbRestaurant.ValueMember = "ID";
        }

        private void LoadHallToListView()
        {
            HallBL hallBL = new HallBL();
            listHall = hallBL.GetAll();
            lsvHall.Items.Clear();

            foreach (Hall hall in listHall)
            {
                string restaurantName = listRestaurant.Find(x => x.ID == hall.RestaurantID)?.Name ?? "Không xác định";
                ListViewItem item = new ListViewItem(hall.ID.ToString());
                item.SubItems.Add(hall.Name);
                item.SubItems.Add(restaurantName);
                item.Tag = hall;
                lsvHall.Items.Add(item);
            }
        }

        private void lsvHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHall.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvHall.SelectedItems[0];
                Hall hall = (Hall)item.Tag;
                txtID.Text = hall.ID.ToString();
                txtName.Text = hall.Name;
                cbbRestaurant.SelectedValue = hall.RestaurantID;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HallBL hallBL = new HallBL();
            Hall hall = new Hall
            {
                Name = txtName.Text,
                RestaurantID = (int)cbbRestaurant.SelectedValue
            };
            hallBL.Insert(hall);
            LoadHallToListView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            HallBL hallBL = new HallBL();
            Hall hall = new Hall
            {
                ID = int.Parse(txtID.Text),
                Name = txtName.Text,
                RestaurantID = (int)cbbRestaurant.SelectedValue
            };
            hallBL.Update(hall);
            LoadHallToListView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            HallBL hallBL = new HallBL();
            Hall hall = new Hall
            {
                ID = int.Parse(txtID.Text),
                Name = txtName.Text,
                RestaurantID = (int)cbbRestaurant.SelectedValue
            };
            hallBL.Delete(hall);
            LoadHallToListView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
