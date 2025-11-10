using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
    public class CategoryDA
    {
        public List<Category> GetAll()
        {
            SqlConnection conn = Ultilities.CreateConnection();
            SqlCommand cmd = new SqlCommand(Ultilities.Category_GetAll, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Category> list = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    Type = Convert.ToInt32(reader["Type"])
                };
                list.Add(category);
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return list;
        }
        public int Insert_Update_Delete(Category category, int action)
        {
            SqlConnection conn = Ultilities.CreateConnection();
            SqlCommand cmd = new SqlCommand(Ultilities.Category_InsertUpdateDelete, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(IDPara).Value = category.ID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = category.Name;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = category.Type;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;


            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@ID"].Value;
            return 0;
        }
    }
}
