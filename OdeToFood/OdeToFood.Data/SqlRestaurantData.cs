using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly Context context;

        public SqlRestaurantData(Context context)
        {
            this.context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            context.Add(newRestaurant);
            Commit();
            return newRestaurant;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                context.Restaurant.Remove(restaurant);
            }

            return Commit();
        }

        public Restaurant GetById(int id)
        {
            return context.Restaurant.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return context.Restaurant.AsNoTracking().Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in context.Restaurant
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = context.Restaurant.Attach(restaurant);
            entity.State = EntityState.Modified;
            Commit();

            return restaurant;
        }
    }
}