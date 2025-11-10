using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    public partial class FoodForm : Form
    {
        private DataTable foodTable;
        public FoodForm()
        {
            InitializeComponent();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            FoodLoad();
        }
        private void FoodLoad()
        {
            SqlConnection conn = Ultilities.CreateConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select ID, Name From Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();

            cbxCategory.DataSource = dt;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "ID";
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategory.SelectedIndex == -1) return;
            SqlConnection conn = Ultilities.CreateConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Food where FoodCategoryID = @categoryId";

            cmd.Parameters.Add("@categoryId",SqlDbType.Int);
            if (cbxCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbxCategory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryId"].Value = rowView["ID"];
            }
            else
                cmd.Parameters["@categoryId"].Value = cbxCategory.SelectedValue;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foodTable = new DataTable();

            conn.Open();
            adapter.Fill(foodTable);
            conn.Close();
            conn.Dispose();

            dgvFoodList.DataSource = foodTable;

            lbQuantity.Text = foodTable.Rows.Count.ToString();
            lbName.Text = cbxCategory.Text;
        }

        private void tsmTotalSold_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Ultilities.CreateConnection();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select @numSaleFood = sum(Quantity) from InvoiceDetails where FoodID = @foodId";

            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                cmd.Parameters.Add("@foodId", SqlDbType.Int);
                cmd.Parameters["@foodId"].Value = rowView["ID"];

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
                cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                if (result == "") result = "0";
                MessageBox.Show($"Total: {result} {rowView["Unit"]} {rowView["Name"]} has sold.");
                conn.Close();
            }
            cmd.Dispose();
            conn.Dispose();
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.Show(this);
        }
        void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int i = cbxCategory.SelectedIndex;
            cbxCategory.SelectedIndex = -1;
            cbxCategory.SelectedIndex = i;
        }

        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            if(dgvFoodList.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);

                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;

            string filter = $"Name like '%{txtFind.Text}%'";
            string sort = "Price desc";

            DataView foodView = new DataView(foodTable, filter, sort, DataViewRowState.OriginalRows);

            dgvFoodList.DataSource = foodView;
        }
    }
}
