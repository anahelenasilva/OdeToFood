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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetById(id);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var restaurant = restaurantData.Delete(id);

            if (restaurant == 0)
                return RedirectToPage("./NotFound");

            TempData["Message"] = "Restaurant deleted";
            return RedirectToPage("./List");
        }
    }
}