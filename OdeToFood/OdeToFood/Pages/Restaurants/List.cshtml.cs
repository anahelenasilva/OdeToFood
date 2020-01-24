using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public string Message { get; set; }

        public IRestaurantData RestaurantData { get; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            RestaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}