using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class AccountBL
    {
        AccountDA da = new AccountDA();

        public DataTable GetAll() => da.GetAll();
        public int Insert(Account acc) => da.InsertUpdateDelete(acc, 0);
        public int Update(Account acc) => da.InsertUpdateDelete(acc, 1);
        public int Delete(Account acc) => da.InsertUpdateDelete(acc, 2);
    }
}
