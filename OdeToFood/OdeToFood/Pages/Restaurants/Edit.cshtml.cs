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

        public IActionResult OnGet(int id)
        {
            Restaurant = RestaurantData.GetById(id);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            return Page();
        }

        public IActionResult OnPost()
        {
            Restaurant = RestaurantData.Update(Restaurant);
            RestaurantData.Commit();
            return Page();
        }
    }
}