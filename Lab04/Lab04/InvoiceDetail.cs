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

namespace Lab04
{
    public partial class InvoiceDetail : Form
    {
        public InvoiceDetail()
        {
            InitializeComponent();
        }
        public void LoadFrom(int invoiceID)
        {
            this.Text = "Detail from " + invoiceID;
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Ultilities.InvoiceDetail_GetByInvoiceID, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceID",SqlDbType.Int).Value = invoiceID;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                dgvDetail.DataSource = dataTable;
                conn.Close();
                da.Dispose();
                cmd.Dispose();
            }
        }
    }
}
