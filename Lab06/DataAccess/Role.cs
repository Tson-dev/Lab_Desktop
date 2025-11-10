using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public string Path { get; set; }
        public string Notes { get; set; }
    }

    public class RoleDA
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(Ultilities.Role_GetAll, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int InsertUpdateDelete(Role role, int action)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Role_InsertUpdateDelete, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", role.ID);
                cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                cmd.Parameters.AddWithValue("@Path", role.Path);
                cmd.Parameters.AddWithValue("@Notes", role.Notes);
                cmd.Parameters.AddWithValue("@Action", action);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }
    }
}
