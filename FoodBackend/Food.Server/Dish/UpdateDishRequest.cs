namespace Food.Server.Dish
{
    public class UpdateDishRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public string Author { get; set; }
    }
}
