using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class DishLight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public string Author { get; set; }
        public DateTime TimeAdded { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
