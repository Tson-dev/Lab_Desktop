using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Role : Form
    {
        string accountName = string.Empty;
        public Role()
        {
            InitializeComponent();
        }
        public void LoadRole(string aName)
        {
            this.accountName = aName;
            using (SqlConnection conn = Ultilities.CreateConnection())
            {
                SqlCommand cmd = conn.CreateCommand();
                this.Text = "Role from " + aName;
                cmd.CommandText =
                    "SELECT\n" +
                    "   r.ID AS RoleID,\n" +
                    "   RoleName,\n" +
                    "   Path,\n" +
                    "   Actived,\n" +
                    "   r.Notes AS Notes\n" +
                    "FROM dbo.Account a\n" +
                    "INNER JOIN dbo.RoleAccount ra ON a.AccountName = ra.AccountName\n" +
                    "INNER JOIN dbo.Role r ON ra.RoleID = r.ID\n" +
                    $"WHERE a.AccountName = N'{aName}';";

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Food");
                da.Fill(dt);
                dgvRole.DataSource = dt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
            }
        }
    }
}
