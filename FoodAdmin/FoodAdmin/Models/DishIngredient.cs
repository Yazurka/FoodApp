using Newtonsoft.Json;

namespace FoodAdmin.Models
{
    public class DishIngredientResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
    }
}