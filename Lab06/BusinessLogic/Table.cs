using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class TableBL
    {
        TableDA tableDA = new TableDA();

        public List<Table> GetAll() => tableDA.GetAll();
        public int Insert(Table table) => tableDA.Insert_Update_Delete(table, 0);
        public int Update(Table table) => tableDA.Insert_Update_Delete(table, 1);
        public int Delete(Table table) => tableDA.Insert_Update_Delete(table, 2);
    }
}
