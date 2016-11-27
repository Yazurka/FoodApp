namespace FoodAdmin.Models
{
    public class DishIngredientCreateRequest
    {
        public double Amount { get; set; }
        public string Unit { get; set; }
        public int IngredientId { get; set; }
    }
}