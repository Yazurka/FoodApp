namespace FoodAdmin.Models
{
    public class DishTagCreateRequest
    {
        public int DishId { get; set; }
        public int[] TagIds { get; set; }
    }
}