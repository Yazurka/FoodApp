using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.DishIngredientRelation;
using Food.Server.Ingredient;
using Food.Server.Tag;

namespace Food.Server.Dish
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Recipe { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public string Author { get; set; }
        public DateTime TimeAdded { get; set; }
        public IEnumerable<DishIngredientResult> Ingredients { get; set; } 
        public IEnumerable<TagResult> Tags { get; set; }
    }
}
