using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food.Server.Ingredient
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientResult>> GetAllIngredients();
        Task<IngredientResult> FindIngredient(int id);
        Task<IngredientResult> PostIngredient(IngredientCreateRequest ingredient);
        Task UpdateIngredient(int id, UpdateIngredientRequest updateIngredientRequest);
        Task DeleteIngredient(int id);

    }
}
