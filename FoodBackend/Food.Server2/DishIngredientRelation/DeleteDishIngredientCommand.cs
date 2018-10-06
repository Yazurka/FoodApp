using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.DishIngredientRelation
{
    public class DeleteDishIngredientCommand
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        
    }
}
