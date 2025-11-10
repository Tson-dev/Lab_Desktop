using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
    }

    public class RestaurantDA
    {
        public List<Restaurant> GetAll()
        {
            List<Restaurant> list = new List<Restaurant>();

            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Restaurant_GetAll, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Restaurant r = new Restaurant
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Website = reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                    };
                    list.Add(r);
                }

                reader.Close();
            }

            return list;
        }

        public int Insert_Update_Delete(Restaurant restaurant, int action)
        {
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(Ultilities.Restaurant_InsertUpdateDelete, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parID = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.InputOutput,
                    Value = restaurant.ID
                };
                cmd.Parameters.Add(parID);
                cmd.Parameters.AddWithValue("@Name", restaurant.Name);
                cmd.Parameters.AddWithValue("@Address", restaurant.Address);
                cmd.Parameters.AddWithValue("@Phone", restaurant.Phone);
                cmd.Parameters.AddWithValue("@Website", restaurant.Website ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Action", action);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (action == 0)
                    restaurant.ID = Convert.ToInt32(parID.Value);

                return result;
            }
        }
    }
}
