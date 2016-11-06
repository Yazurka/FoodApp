using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Food.Server.Ingredient;

namespace Food.Server.WebApi.Ingredient
{
    public class IngredientController : ApiController
    {
        private readonly IIngredientService m_ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            m_ingredientService = ingredientService;
        }

        public async Task<IngredientResult> Get(int id)
        {
            var result = await m_ingredientService.FindIngredient(id);
            return result;
        }
        public async Task<IEnumerable<IngredientResult>> Get()
        {
            var result = await m_ingredientService.GetAllIngredients();
            return result;
        }
        public async Task<IngredientResult> Post(IngredientCreateRequest ingredientCreateRequest)
        {
            var result = await m_ingredientService.PostIngredient(ingredientCreateRequest);
            return result;
        }

        public async Task Delete(int id)
        {
            await m_ingredientService.DeleteIngredient(id);
        }
    }
}
