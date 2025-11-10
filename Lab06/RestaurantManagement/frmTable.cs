using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmTable : Form
    {
        private List<Table> listTable;
        private List<Hall> listHall;

        public frmTable()
        {
            InitializeComponent();
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            LoadHall();
            LoadTableDataToListView();
        }

        private void LoadHall()
        {
            HallBL hallBL = new HallBL();
            listHall = hallBL.GetAll();
            cbbHall.DataSource = listHall;
            cbbHall.DisplayMember = "Name";
            cbbHall.ValueMember = "ID";
        }

        private void LoadTableDataToListView()
        {
            TableBL tableBL = new TableBL();
            listTable = tableBL.GetAll();

            lsvTable.Items.Clear();
            int count = 1;

            foreach (Table table in listTable)
            {
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(table.ID.ToString());
                item.SubItems.Add(table.TableCode);
                item.SubItems.Add(table.Name);
                item.SubItems.Add(table.Status.ToString());
                item.SubItems.Add(table.Seats.ToString());

                string hallName = listHall.Find(x => x.ID == table.HallID).Name;
                item.SubItems.Add(hallName);

                lsvTable.Items.Add(item);
                count++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Table table = new Table
            {
                TableCode = txtTableCode.Text,
                Name = txtName.Text,
                Status = int.Parse(txtStatus.Text),
                Seats = int.Parse(txtSeats.Text),
                HallID = (int)cbbHall.SelectedValue
            };

            TableBL tableBL = new TableBL();
            tableBL.Insert(table);
            LoadTableDataToListView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvTable.SelectedItems.Count == 0)
                return;

            Table table = new Table
            {
                ID = Convert.ToInt32(txtID.Text),
                TableCode = txtTableCode.Text,
                Name = txtName.Text,
                Status = int.Parse(txtStatus.Text),
                Seats = int.Parse(txtSeats.Text),
                HallID = (int)cbbHall.SelectedValue
            };

            TableBL tableBL = new TableBL();
            tableBL.Update(table);
            LoadTableDataToListView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvTable.SelectedItems.Count == 0)
                return;

            Table table = new Table
            {
                ID = Convert.ToInt32(txtID.Text),
                TableCode = txtTableCode.Text,
                Name = txtName.Text,
                Status = int.Parse(txtStatus.Text),
                Seats = int.Parse(txtSeats.Text),
                HallID = (int)cbbHall.SelectedValue
            };

            TableBL tableBL = new TableBL();
            tableBL.Delete(table);
            LoadTableDataToListView();
        }

        private void lsvTable_Click(object sender, EventArgs e)
        {
            if (lsvTable.SelectedItems.Count == 0)
                return;

            ListViewItem item = lsvTable.SelectedItems[0];
            txtID.Text = item.SubItems[1].Text;
            txtTableCode.Text = item.SubItems[2].Text;
            txtName.Text = item.SubItems[3].Text;
            txtStatus.Text = item.SubItems[4].Text;
            txtSeats.Text = item.SubItems[5].Text;
            cbbHall.Text = item.SubItems[6].Text;
        }
    }
}
