using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class RoleBL
    {
        RoleDA da = new RoleDA();

        public DataTable GetAll() => da.GetAll();
        public int Insert(Role role) => da.InsertUpdateDelete(role, 0);
        public int Update(Role role) => da.InsertUpdateDelete(role, 1);
        public int Delete(Role role) => da.InsertUpdateDelete(role, 2);
    }
}
