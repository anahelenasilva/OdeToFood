using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican },
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(f => f.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return (from r in restaurants
                    where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                    orderby r.Name
                    select r).ToList();
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(m => m.Id) + 1;

            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(f => f.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit() //will be used later with a real database
        {
            return 0;
        }

        public int Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(f => f.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return 1;
        }
    }
}