using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.DishIngredientRelation
{
    public interface IDishIngredientService
    {
        Task<IEnumerable<DishIngredientResult>> GetAllDishIngredients();
        Task<IEnumerable<DishIngredientResult>> FindIngredientsForDish(int dishId);
        Task DeleteDishIngredient(int id);
        Task AddIngredientsToDish(int dishId, DishIngredientCreateRequest[] dishIngredients);
    }
}
