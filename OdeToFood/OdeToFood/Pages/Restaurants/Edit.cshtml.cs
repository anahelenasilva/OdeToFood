using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData RestaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty] //only with post op
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.RestaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                Restaurant = RestaurantData.GetById(id.Value);

                if (Restaurant == null)
                    return RedirectToPage("./NotFound");
            }
            else
            {
                Restaurant = new Restaurant
                {
                    Cuisine = CuisineType.None
                };
            }

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.RestaurantId == 0)
                RestaurantData.Add(Restaurant);
            else
                RestaurantData.Update(Restaurant);

            RestaurantData.Commit();

            TempData["Message"] = "Restaurant saved!";
            //only shows on the next request

            return RedirectToPage("./Detail", new { id = Restaurant.RestaurantId });
        }
    }
}