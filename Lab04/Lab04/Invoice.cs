using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Invoice : Form
    {
        DateTime from = new DateTime(2000, 1, 1);
        DateTime to = DateTime.Now;
        public Invoice()
        {
            InitializeComponent();
        }
        private void LoadForm(int loadAction)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                conn.Open();
                if (loadAction != 3)
                {
                    SqlCommand cmd = new SqlCommand(Ultilities.Invoice_GetByDate, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@From", SqlDbType.SmallDateTime).Value = this.from;
                    cmd.Parameters.Add("@To", SqlDbType.SmallDateTime).Value = this.to;
                    cmd.Parameters.Add("@Action", SqlDbType.Int).Value = loadAction;
                    DisplayListView(cmd.ExecuteReader());
                    cmd.Dispose();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(Ultilities.Invoice_GetAll, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DisplayListView(cmd.ExecuteReader());
                    cmd.Dispose();
                }
                conn.Close();
            }
        }
        private int Cal_Subtotal(int invoiceID)
        {
            SqlConnection conn = Ultilities.CreateConnection();
            SqlCommand cmd = new SqlCommand($"Select [dbo].[Cal_Subtotal]({invoiceID})", conn);
            conn.Open();
            int result = (int)cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
        private void DisplayListView(SqlDataReader reader)
        {
            lvInvoice.Items.Clear();
            while (reader.Read())
            {
                int subtotal = Cal_Subtotal((int)reader["ID"]);
                
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["TableID"].ToString());
                item.SubItems.Add(reader["Discount"].ToString());
                item.SubItems.Add(reader["Tax"].ToString());
                int discountAmout = (int)((subtotal + subtotal / 100f * Convert.ToSingle(item.SubItems[4].Text)) / 100f * Convert.ToSingle(item.SubItems[3].Text));
                item.SubItems.Add(discountAmout.ToString());
                item.SubItems.Add(subtotal.ToString());
                item.SubItems.Add(reader["Total"].ToString());
                item.SubItems.Add(reader["Status"].ToString());
                item.SubItems.Add(reader["Account"].ToString());
                item.SubItems.Add(reader["CheckoutDate"].ToString());


                lvInvoice.Items.Add(item);
            }
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            LoadForm(3);
            dtpFrom.Value = this.from;
            dtpTo.Value = this.to;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (this.from < dtpTo.Value)
            {
                this.to = dtpTo.Value;
                LoadForm(0);
            }
            else
            {
                MessageBox.Show("Date in box \"To\" can't be small than box \"From\"");
                dtpTo.Value = this.to;
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value < this.to)
            {
                this.from = dtpFrom.Value;
                LoadForm(0);
            }
            else
            {
                MessageBox.Show("Date in box \"From\" can't be small than box \"To\"");
                dtpFrom.Value = this.from;
            }
        }

        private void lvInvoice_DoubleClick(object sender, EventArgs e)
        {
            if(lvInvoice.SelectedItems.Count > 0)
            {
                InvoiceDetail frm = new InvoiceDetail();
                frm.LoadFrom(Convert.ToInt32(lvInvoice.SelectedItems[0].SubItems[0].Text));
                frm.Show(this);
            }
        }
    }
}