using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class HallBL
    {
        HallDA hallDA = new HallDA();

        public List<Hall> GetAll() => hallDA.GetAll();

        public int Insert(Hall hall) => hallDA.Insert_Update_Delete(hall, 0);

        public int Update(Hall hall) => hallDA.Insert_Update_Delete(hall, 1);

        public int Delete(Hall hall) => hallDA.Insert_Update_Delete(hall, 2);
    }
}
