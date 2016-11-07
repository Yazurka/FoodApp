using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.Recipe;

namespace Food.Server.WebApi.Recipe
{
    public class RecipeController : ApiController
    {
        private readonly IRecipeService m_recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            m_recipeService = recipeService;
        }

        public async Task<RecipeResult> Get(int id)
        {
            var result = await m_recipeService.FindRecipe(id);
            return result;  
        }
        public async Task<IEnumerable<RecipeResult>> Get()
        {
            var result = await m_recipeService.GetAllRecipes();
            return result;
        }
        public async Task<RecipeResult> Post(RecipeCreateRequest recipeCreateRequest)
        {
            var result = await m_recipeService.PostRecipe(recipeCreateRequest);
            return result;
        }
        public async Task Delete(int id)
        {
            await m_recipeService.DeleteRecipe(id);
        }
    }
}
