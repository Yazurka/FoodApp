using System.Collections.Generic;

namespace FoodAdmin.Models
{
    public class Dish
    {
        public DishLight DishValue { get; set; }
        public DishImage Image { get; set; }
        public List<DishIngredientResult> Ingredients { get; set; }
    }
}