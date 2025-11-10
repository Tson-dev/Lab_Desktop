using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class RestaurantBL
    {
        RestaurantDA restaurantDA = new RestaurantDA();

        public List<Restaurant> GetAll() => restaurantDA.GetAll();

        public int Insert(Restaurant restaurant) => restaurantDA.Insert_Update_Delete(restaurant, 0);

        public int Update(Restaurant restaurant) => restaurantDA.Insert_Update_Delete(restaurant, 1);

        public int Delete(Restaurant restaurant) => restaurantDA.Insert_Update_Delete(restaurant, 2);
    }
}
