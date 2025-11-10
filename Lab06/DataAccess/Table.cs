using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Table
    {
        public int ID { get; set; }
        public string TableCode { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Seats { get; set; }
        public int HallID { get; set; }
    }

    public class TableDA
    {
        public List<Table> GetAll()
        {
            SqlConnection conn = Ultilities.CreateConnection();

            SqlCommand cmd = new SqlCommand(Ultilities.Table_GetAll, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Table> list = new List<Table>();

            while (reader.Read())
            {
                Table table = new Table
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    TableCode = reader["TableCode"].ToString(),
                    Name = reader["Name"].ToString(),
                    Status = Convert.ToInt32(reader["Status"]),
                    Seats = reader["Seats"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Seats"]),
                    HallID = Convert.ToInt32(reader["HallID"])
                };

                list.Add(table);
            }

            conn.Close();
            return list;
        }

        public int Insert_Update_Delete(Table table, int action)
        {
            SqlConnection conn = Ultilities.CreateConnection();

            SqlCommand cmd = new SqlCommand(Ultilities.Table_InsertUpdateDelete, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            cmd.Parameters.Add(IDPara).Value = table.ID;
            cmd.Parameters.Add("@TableCode", SqlDbType.NVarChar, 200).Value = table.TableCode;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = table.Name;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = table.Status;
            cmd.Parameters.Add("@Seats", SqlDbType.Int).Value = table.Seats;
            cmd.Parameters.Add("@HallID", SqlDbType.Int).Value = table.HallID;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            conn.Open();
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
                return (int)cmd.Parameters["@ID"].Value;

            return 0;
        }
    }
}
