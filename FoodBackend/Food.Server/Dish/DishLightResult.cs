using System;

namespace Food.Server.Dish
{
    public class DishLightResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }
        public string Duration { get; set; }
        public string Author { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
