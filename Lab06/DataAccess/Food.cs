using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int FoodCategoryID { get; set; }
        public int Price { get; set; }
        public string Notes { get; set; }
    }
    public class FoodDA
    {
        public List<Food> GetAll()
        {
            SqlConnection conn = Ultilities.CreateConnection();
            SqlCommand cmd = new SqlCommand(Ultilities.Food_GetAll, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Food> list = new List<Food>();
            while (reader.Read())
            {
                Food food = new Food
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    Unit = reader["Unit"].ToString(),
                    FoodCategoryID = Convert.ToInt32(reader["FoodCategoryID"].ToString()),
                    Price = Convert.ToInt32(reader["Price"]),
                    Notes = reader["Notes"].ToString()
                };
                list.Add(food);
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return list;
        }
        public int Insert_Update_Delete(Food food, int action)
        {
            SqlConnection conn = Ultilities.CreateConnection();
            SqlCommand cmd = new SqlCommand(Ultilities.Food_InsertUpdateDelete, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(IDPara).Value = food.ID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = food.Name;
            cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = food.Unit;
            cmd.Parameters.Add("@FoodCategoryID", SqlDbType.Int).Value = food.FoodCategoryID;
            cmd.Parameters.Add("@Price", SqlDbType.Int).Value = food.Price;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000).Value = food.Notes;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@ID"].Value;
            return 0;
        }
    }
}
