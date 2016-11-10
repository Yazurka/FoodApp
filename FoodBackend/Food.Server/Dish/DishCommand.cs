using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Dish
{
    public class DishCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Difficulty { get; set; }
        public string Duration { get; set; }
        public string Author { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
