using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Ultilities
    {
        private static string Strname = "KetNoiDB";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[Strname].ConnectionString;

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static string Food_GetAll = "Food_GetAll";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";

        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";

        public static string Table_GetAll = "Table_GetAll";
        public static string Table_InsertUpdateDelete = "Table_InsertUpdateDelete";

        public static string Hall_GetAll = "Hall_GetAll";
        public static string Hall_InsertUpdateDelete = "Hall_InsertUpdateDelete";

        public static string Restaurant_GetAll = "Restaurant_GetAll";
        public static string Restaurant_InsertUpdateDelete = "Restaurant_InsertUpdateDelete";

        public static string Invoice_GetAll = "Invoice_GetAll";
        public static string Invoice_InsertUpdateDelete = "Invoice_InsertUpdateDelete";
        public static string Invoice_CreateForTable = "Invoice_CreateForTable";
        public static string Invoice_Checkout = "Invoice_Checkout";

        public static string InvoiceDetail_GetByInvoiceID = "InvoiceDetail_GetByInvoiceID";
        public static string InvoiceDetail_InsertUpdateDelete = "InvoiceDetail_InsertUpdateDelete";

        public static string Account_GetAll = "Account_GetAll";
        public static string Account_InsertUpdateDelete = "Account_InsertUpdateDelete";

        public static string Role_GetAll = "Role_GetAll";
        public static string Role_InsertUpdateDelete = "Role_InsertUpdateDelete";

        public static string RoleAccount_GetAll = "RoleAccount_GetAll";
        public static string RoleAccount_InsertUpdateDelete = "RoleAccount_InsertUpdateDelete";
        public static string RoleAccount_GetByAccountName = "RoleAccount_GetByAccountName";
    }
}
