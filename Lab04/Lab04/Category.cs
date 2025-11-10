using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lab04
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("SqlClient.log"));
            Trace.AutoFlush = true;
            using (SqlConnection sqlConn = Ultilities.CreateConnection())
            {
                SqlCommand sqlcmd = sqlConn.CreateCommand();
                string query = "select ID, Name, Type from Category";
                sqlcmd.CommandText = query;
                sqlConn.Open();
                SqlDataReader sqldata = sqlcmd.ExecuteReader();
                DisplayCategory(sqldata);
                sqlConn.Close();
            }

        }

        private void DisplayCategory(SqlDataReader sqldata)
        {
            lvCategory.Items.Clear();
            while (sqldata.Read())
            {
                ListViewItem lvi = new ListViewItem(sqldata["ID"].ToString());

                lvCategory.Items.Add(lvi);

                lvi.SubItems.Add(sqldata["Name"].ToString());
                lvi.SubItems.Add(sqldata["Type"].ToString());
            }
        }

        private void CleanTXT()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtType.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int numOfRowEffected = 0;
            using (SqlConnection sqlConn = Ultilities.CreateConnection())
            {
                SqlCommand sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = $"Insert Into Category(Name, [Type]) Values (N'{txtName.Text}', {txtType.Text})";
                try
                {
                    sqlConn.Open();
                    numOfRowEffected = sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't open connection to database.\n" + ex.Message);
                }
                if (numOfRowEffected == 1)
                {
                    MessageBox.Show("Success add a category");
                    btnLoad.PerformClick();
                    CleanTXT();
                }
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int numOfRowEffected = 0;
            using (SqlConnection sqlConn = Ultilities.CreateConnection())
            {
                SqlCommand sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = $"Update Category set Name = N'{txtName.Text}', [Type] = {txtType.Text} Where ID = {txtID.Text}";
                try
                {
                    sqlConn.Open();
                    numOfRowEffected = sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't connect to database.\n" + ex.ToString());
                }
                if (numOfRowEffected == 1)
                {
                    ListViewItem item = lvCategory.SelectedItems[0];
                    item.SubItems[1].Text = txtName.Text;
                    item.SubItems[2].Text = txtType.Text;

                    CleanTXT();

                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;

                    MessageBox.Show("Update Completed");
                }
            }
        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCategory.SelectedItems[0];
            txtID.Text = item.SubItems[0].Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[2].Text == "0" ? "Beverages" : "Dishes";

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int numOfRowEffected = 0;
            using(SqlConnection sqlConn = Ultilities.CreateConnection())
            {
                SqlCommand sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = $"Delete from Category where ID = {txtID.Text}";
                try
                {
                    sqlConn.Open();
                    numOfRowEffected = sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't connect to database.\n" + ex.ToString());
                }
                if(numOfRowEffected == 1 )
                {
                    lvCategory.Items.Remove(lvCategory.SelectedItems[0]);

                    CleanTXT();

                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;

                    MessageBox.Show("Deleted");
                }
            }
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
                btnDelete.PerformClick();
        }

        private void tsmViewDishes_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                Food dishes = new Food();
                dishes.Show(this);
                dishes.LoadDishes(Convert.ToInt32(txtID.Text));
            }
        }
    }
}
