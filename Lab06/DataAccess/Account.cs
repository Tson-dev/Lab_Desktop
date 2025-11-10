using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Account
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class AccountDA
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Ultilities.Account_GetAll, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int InsertUpdateDelete(Account acc, int action)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Account_InsertUpdateDelete, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountName", acc.AccountName);
                cmd.Parameters.AddWithValue("@Password", acc.Password);
                cmd.Parameters.AddWithValue("@FullName", acc.FullName);
                cmd.Parameters.AddWithValue("@Email", acc.Email);
                cmd.Parameters.AddWithValue("@Phone", acc.Phone);
                cmd.Parameters.AddWithValue("@Action", action);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                return result;
            }
        }
    }
}
