using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Server.Dish;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food.Server.WebApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDishService _dishService;

        public IEnumerable<DishLight> Dishes;

        public IndexModel(IDishService dishService)
        {
            _dishService = dishService;
        }

        public async Task OnGet()
        {
            Dishes = await _dishService.GetAllDishes(20, 0);
        }
    }
}