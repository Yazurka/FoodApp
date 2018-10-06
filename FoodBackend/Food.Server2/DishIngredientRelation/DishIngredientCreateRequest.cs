using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.DishIngredientRelation
{
    public class DishIngredientCreateRequest
    {
        public double Amount { get; set; }
        public string Unit { get; set; }
        public int IngredientId { get; set; }
        public string Comment { get; set; }
    }
}
