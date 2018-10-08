using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Server.Dish;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food.Server.WebApi.Pages.Dish
{
    public class DetailsModel : PageModel
    {
        private readonly IDishService _dishService;

        public Server.Dish.Dish Dish { get; set; }

        public DetailsModel(IDishService dishService)
        {
            _dishService = dishService;
        }

        public async Task OnGet(int id)
        {
            Dish = await _dishService.FindDish(id);
        }
    }
}