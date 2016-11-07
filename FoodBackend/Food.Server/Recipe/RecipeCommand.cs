using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Recipe
{
    public class RecipeCommand
    {
        public int Id { get; set; }
        public int Dish_id_fk { get; set; }
        public string Description { get; set; }
        public string Description_short { get; set; }
        public int Difficulty { get; set; }
        public string Duration { get; set; }
    }
}
