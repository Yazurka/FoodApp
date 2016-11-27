namespace Food.Server.Ingredient
{
    public class UpdateIngredientCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}