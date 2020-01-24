using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        public IRestaurantData RestaurantData { get; }

        public DetailModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = RestaurantData.GetById(id);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }
    }
}