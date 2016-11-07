using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food.Server.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeResult>> GetAllRecipes();
        Task<RecipeResult> FindRecipe(int id);
        Task<RecipeResult> PostRecipe(RecipeCreateRequest recipeCreateRequest);
        Task DeleteRecipe(int id);
    }
}   
