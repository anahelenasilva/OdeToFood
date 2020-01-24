using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;

namespace OdeToFood
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }

        public void OnGet(int id)
        {
            Restaurant = new Restaurant();
        }
    }
}