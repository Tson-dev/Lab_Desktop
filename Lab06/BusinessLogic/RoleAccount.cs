using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class RoleAccountBL
    {
        RoleAccountDA da = new RoleAccountDA();

        public DataTable GetAll() => da.GetAll();
        public int Insert(RoleAccount ra) => da.InsertUpdateDelete(ra, 0);
        public int Update(RoleAccount ra) => da.InsertUpdateDelete(ra, 1);
        public int Delete(RoleAccount ra) => da.InsertUpdateDelete(ra, 2);
        public DataTable GetByAccountName(string accountName)
        {
            RoleAccountDA da = new RoleAccountDA();
            return da.GetByAccountName(accountName);
        }

    }
}
