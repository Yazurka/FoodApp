using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Tag;

namespace Food.Server.Dish
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Difficulty { get; set; }
        public string Duration { get; set; }
        public IEnumerable<TagResult> Tags { get; set; }
    }
}
