using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.DishIngredientRelation;

namespace Food.Server.Dish
{
    public class DishCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Difficulty { get; set; } 
        public string Duration { get; set; }
        public int[] TagIds { get; set; }
        public DishIngredientCreateRequest[] DishIngredients { get; set; }
    }
}
