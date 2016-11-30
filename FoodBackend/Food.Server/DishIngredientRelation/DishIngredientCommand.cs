using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.DishIngredientRelation
{
    public class DishIngredientCommand
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
        public int Ingredient_id_fk { get; set; }
        public int Dish_id_fk { get; set; }
    }
}
