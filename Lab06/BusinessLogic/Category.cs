using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CategoryBL
    {
        CategoryDA categoryDA = new CategoryDA();

        public List<Category> GetAll() => categoryDA.GetAll();
        public int Insert(Category category) => categoryDA.Insert_Update_Delete(category, 0);
        public int Update(Category category) => categoryDA.Insert_Update_Delete(category, 1);
        public int Delete(Category category) => categoryDA.Insert_Update_Delete(category, 2);
    }
}
