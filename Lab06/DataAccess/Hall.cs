using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Hall
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RestaurantID { get; set; }
    }

    public class HallDA
    {
        public List<Hall> GetAll()
        {
            List<Hall> list = new List<Hall>();
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Hall_GetAll, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Hall
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        RestaurantID = Convert.ToInt32(reader["RestaurantID"])
                    });
                }
                reader.Close();
                conn.Close();
                cmd.Dispose();
            }
            return list;
        }

        public int Insert_Update_Delete(Hall hall, int action)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Hall_InsertUpdateDelete, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@ID"].Value = hall.ID;
                cmd.Parameters.AddWithValue("@Name", hall.Name);
                cmd.Parameters.AddWithValue("@RestaurantID", hall.RestaurantID);
                cmd.Parameters.AddWithValue("@Action", action);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                if (action == 0)
                    hall.ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                return result;
            }
        }
    }
}
