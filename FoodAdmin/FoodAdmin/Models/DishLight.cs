using System;
using System.Collections.Generic;

namespace FoodAdmin.Models
{
    public class DishLight
    {
        public DishLight()
        {
            Tags = new List<Tag>();
            Ingredients = new List<Ingredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }
        public string Duration { get; set; }
        public string Author { get; set; }
        public DateTime TimeAdded { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
