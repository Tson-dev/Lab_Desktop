using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class InvoiceDetail
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public int FoodID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class InvoiceDetailDA
    {
        public DataTable GetByInvoiceID(int invoiceID)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Ultilities.InvoiceDetail_GetByInvoiceID, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@InvoiceID", invoiceID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int InsertUpdateDelete(InvoiceDetail detail, int action)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.InvoiceDetail_InsertUpdateDelete, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", detail.ID);
                cmd.Parameters.AddWithValue("@InvoiceID", detail.InvoiceID);
                cmd.Parameters.AddWithValue("@FoodID", detail.FoodID);
                cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
                cmd.Parameters.AddWithValue("@Price", detail.Price);
                cmd.Parameters.AddWithValue("@Action", action);

                conn.Open();
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r;
            }
        }

        public int DeleteByInvoice(int invoiceID)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("InvoiceDetail_DeleteByInvoiceID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r;
            }
        }
    }
}
