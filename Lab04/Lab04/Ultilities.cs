using System.Configuration;
using System.Data.SqlClient;

namespace Lab04
{
    public class Ultilities
    {
        private static string Strname = "DBConnection";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[Strname].ConnectionString;

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static string Account_GetAll = "Account_GetAll";
        public static string Account_InsertUpdateDelete = "Account_InsertUpdateDelete";

        public static string Food_GetAll = "Food_GetAll";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";

        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";

        public static string Invoice_GetAll = "Invoice_GetAll";
        public static string Invoice_GetByDate = "Invoice_GetByDate";
        public static string Invoice_InsertUpdateDelete = "Invoice_InsertUpdateDelete";
        public static string Invoice_CreateForTable = "Invoice_CreateForTable";

        public static string InvoiceDetail_GetByInvoiceID = "InvoiceDetail_GetByInvoiceID";

        public static string Table_GetAll = "Table_GetAll";
        public static string Table_InsertUpdateDelete = "Table_InsertUpdateDelete";
    }
}
