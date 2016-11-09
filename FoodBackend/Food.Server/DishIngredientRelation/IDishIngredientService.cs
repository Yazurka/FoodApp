using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food.Server.DishIngredientRelation
{
    public interface IDishIngredientService
    {
        Task<IEnumerable<DishIngredientResult>> GetAllDishIngredients();
        Task<IEnumerable<DishIngredientResult>> FindIngredientsForDish(int dishId);
        Task DeleteIngredientFromDish(int dishId, int[] ingredientIds);
        Task AddIngredientsToDish(int dishId, DishIngredientCreateRequest[] dishIngredients);
    }
}
