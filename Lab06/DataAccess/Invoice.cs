using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Invoice
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TableID { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public int Status { get; set; }
        public string AccountID { get; set; }
        public System.DateTime CheckoutDate { get; set; }
    }

    public class InvoiceDA
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Ultilities.Invoice_GetAll, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int InsertUpdateDelete(Invoice inv, int action)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Invoice_InsertUpdateDelete, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", inv.ID);
                cmd.Parameters.AddWithValue("@Name", inv.Name ?? "");
                cmd.Parameters.AddWithValue("@TableID", inv.TableID);
                cmd.Parameters.AddWithValue("@Total", inv.Total);
                cmd.Parameters.AddWithValue("@Discount", inv.Discount);
                cmd.Parameters.AddWithValue("@Tax", inv.Tax);
                cmd.Parameters.AddWithValue("@Status", inv.Status);
                cmd.Parameters.AddWithValue("@AccountID", inv.AccountID ?? "");
                cmd.Parameters.AddWithValue("@CheckoutDate", inv.CheckoutDate);
                cmd.Parameters.AddWithValue("@Action", action);

                conn.Open();
                var res = cmd.ExecuteNonQuery();
                conn.Close();
                return res;
            }
        }

        public int CreateForTable(int tableID, string accountID, out int newInvoiceID)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Invoice_CreateForTable, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableID", tableID);
                cmd.Parameters.AddWithValue("@AccountID", accountID ?? "");
                var p = cmd.Parameters.Add("@NewInvoiceID", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                newInvoiceID = Convert.ToInt32(p.Value);
                conn.Close();
                return 1;
            }
        }

        public int Checkout(int invoiceID, double discount, double tax, double paidAmount, string accountID)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Invoice_Checkout, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.Parameters.AddWithValue("@Discount", discount);
                cmd.Parameters.AddWithValue("@Tax", tax);
                cmd.Parameters.AddWithValue("@PaidAmount", paidAmount);
                cmd.Parameters.AddWithValue("@AccountID", accountID ?? "");

                conn.Open();
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r;
            }
        }
    }
}
