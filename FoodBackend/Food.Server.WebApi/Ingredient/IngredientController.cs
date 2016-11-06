using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<IngredientResult>> Get(int id)
        {

            var result = await m_ingredientService.GetAllIngredients();
            return result;
        }
    }
}
