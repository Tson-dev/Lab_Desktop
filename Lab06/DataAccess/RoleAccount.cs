using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class RoleAccount
    {
        public string AccountName { get; set; }
        public int RoleID { get; set; }
        public bool Actived { get; set; }
        public string Notes { get; set; }
    }

    public class RoleAccountDA
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Ultilities.RoleAccount_GetAll, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetByAccountName(string accountName)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.RoleAccount_GetByAccountName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountName", accountName);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }


        public int InsertUpdateDelete(RoleAccount ra, int action)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.RoleAccount_InsertUpdateDelete, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountName", ra.AccountName);
                cmd.Parameters.AddWithValue("@RoleID", ra.RoleID);
                cmd.Parameters.AddWithValue("@Actived", ra.Actived);
                cmd.Parameters.AddWithValue("@Notes", ra.Notes);
                cmd.Parameters.AddWithValue("@Action", action);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }
    }
}
