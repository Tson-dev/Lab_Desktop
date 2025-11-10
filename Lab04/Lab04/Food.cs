using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Food : Form
    {
        int action = -1;
        int category;

        public Food()
        {
            InitializeComponent();
            this.Height = 280;
            SetEnableControl(false);
        }
        public void LoadDishes(int categoryID)
        {
            this.category = categoryID;
            using( SqlConnection sqlConn  = Ultilities.CreateConnection())
            {
                SqlCommand sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = "Select Name from Category where ID = " + categoryID;
                sqlConn.Open();
                string name = sqlComm.ExecuteScalar().ToString();
                this.Text = "Dishes from " + name;
                sqlComm.CommandText = "Select * from Food where FoodCategoryID = " + categoryID;
                SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable("Food");
                da.Fill(dt);
                dgvFood.DataSource = dt;
                sqlConn.Close();
                sqlConn.Dispose();
                da.Dispose();
            }
        }

        private void tsiSave_Click(object sender, EventArgs e)
        {
            FormResize(1);
            SetEnableControl(true);
            dgvFood.Enabled = false;
            if (dgvFood.CurrentRow == null)
            {
                this.action = 0;
                txtCategoryID.Text = this.category.ToString();
            }
            else
            {
                GetData();
                this.action = 1;
            }
            txtName.Focus();
        }
        private void tsiDelete_Click(object sender, EventArgs e)
        {
            if(dgvFood.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure to reomve the object?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    GetData();
                    this.action = 2;
                    if (Insert_Update_Delete(this.action) == 0)
                        MessageBox.Show("Something went wrong", "Error", 0, MessageBoxIcon.Error);
                    this.action = -1;
                    ClearText();
                    LoadDishes(this.category);
                }
            }
        }
        private void tsiDeselect_Click(object sender, EventArgs e)
        {
            if (dgvFood.CurrentRow != null)
            {
                dgvFood.ClearSelection();
                dgvFood.CurrentCell = null;
                tsiSave.Text = "Add";
            }
        }
        private int Insert_Update_Delete(int action)
        {
            try
            {
                using (SqlConnection conn = Ultilities.CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand(Ultilities.Food_InsertUpdateDelete, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
                    IDPara.Direction = ParameterDirection.InputOutput;
                    //IDPara.Value = action == 0 ? 0 : Convert.ToInt32(txtID.Text);
                    try
                    {
                        //cmd.Parameters.Add(IDPara);
                        cmd.Parameters.Add(IDPara).Value = (action == 0 ? 0 : Convert.ToInt32(txtID.Text));
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = txtName.Text;
                        cmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 100).Value = txtUnit.Text;
                        cmd.Parameters.Add("@FoodCategoryID", SqlDbType.Int).Value = Convert.ToInt32(txtCategoryID.Text);
                        cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Convert.ToInt32(txtPrice.Text);
                        cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000).Value = txtNotes.Text;
                        cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while collect data.\n\n" + ex, "Error", 0, MessageBoxIcon.Error);
                        return 0;
                    }
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result > 0)
                        return (int)cmd.Parameters["@ID"].Value;
                    else return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error while trying contact to database.\n\n"+ex, "Error", 0, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error\n\n" + ex, "Error", 0, MessageBoxIcon.Error);
            }
            return 0;
        }
        private void btnConfrim_Click(object sender, EventArgs e)
        {
            if (IsTextCorrected())
            {
                if (Insert_Update_Delete(this.action) != 0)
                {
                    btnCancel.PerformClick();
                    LoadDishes(this.category);
                }
                else
                    MessageBox.Show("Something gone wrong.\nAction: " + action, "Error", 0, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Incorrect text in textbox.", "Warning", 0, MessageBoxIcon.Warning);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.action = -1;
            FormResize(2);
            ClearText();
            SetEnableControl(false);
            txtID.Enabled = false;
            dgvFood.Enabled = true;
        }
        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsiSave.Text = "Update";
        }

        private void FormResize(int mode)
        {
            if(mode == 1)
            {
                while (this.Height < 430)
                {
                    this.Height+=2;
                }
            }
            else if(mode == 2)
            {
                while (this.Height > 280)
                {
                    this.Height-=2;
                }
            }
        }
        private void GetData()
        {
            DataGridViewRow row = dgvFood.CurrentRow;
            txtID.Text = row.Cells["colID"].Value.ToString();
            txtName.Text = row.Cells["colName"].Value.ToString();
            txtUnit.Text = row.Cells["colUnit"].Value.ToString();
            txtCategoryID.Text = row.Cells["colCategoryID"].Value.ToString();
            txtPrice.Text = row.Cells["colPrice"].Value.ToString();
            txtNotes.Text = row.Cells["colNote"].Value.ToString();
        }
        private void SetEnableControl(bool status)
        {
            lblID.Visible = status;
            txtID.Visible = status;

            lblName.Visible = status;
            txtName.Visible = status;
            txtName.Enabled = status;

            lblUnit.Visible = status;
            txtUnit.Visible = status;
            txtUnit.Enabled = status;

            lblCategoryID.Visible = status;
            txtCategoryID.Visible = status;

            lblPrice.Visible = status;
            txtPrice.Visible = status;
            txtPrice.Enabled = status;

            lblNotes.Visible = status;
            txtNotes.Visible = status;
            txtNotes.Enabled = status;

            btnConfrim.Visible = status;
            btnConfrim.Enabled = status;

            btnCancel.Visible = status;
            btnCancel.Enabled = status;
        }
        private void ClearText()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtNotes.Text= string.Empty;
        }
        private bool IsTextCorrected()
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
                if (!string.IsNullOrWhiteSpace(txtUnit.Text))
                    if (!string.IsNullOrWhiteSpace(txtCategoryID.Text) && txtCategoryID.Text.All(char.IsDigit))
                        if (!string.IsNullOrWhiteSpace(txtPrice.Text) && txtPrice.Text.All(char.IsDigit))
                            return true;
            return false;
        }
    }
}