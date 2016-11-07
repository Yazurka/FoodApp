using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Recipe
{
    public class RecipeCreateRequest
    {
       
        public int DishId { get; set; }
        public string Description { get; set; }
        public string DescriptionShort { get; set; }
        public int Difficulty { get; set; }
        public string Duration { get; set; }
    }
}
