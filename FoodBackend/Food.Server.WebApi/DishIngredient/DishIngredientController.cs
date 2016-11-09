using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.DishIngredientRelation;

namespace Food.Server.WebApi.DishIngredient
{
    public class DishIngredientController : ApiController
    {
        private readonly IDishIngredientService m_dishIngredientService;

        public DishIngredientController(IDishIngredientService dishIngredientService)
        {
            m_dishIngredientService = dishIngredientService;
        }

        public async Task<IEnumerable<DishIngredientResult>> Get(int id)
        {
            var result = await m_dishIngredientService.FindIngredientsForDish(id);
            return result;
        }
        public async Task<IEnumerable<DishIngredientResult>> Get()  
        {
            var result = await m_dishIngredientService.GetAllDishIngredients();
            return result;
        }
        public async Task Post([FromUri]int dishId, [FromBody]DishIngredientCreateRequest[] dishIngredientsCreateRequest)
        {
            await m_dishIngredientService.AddIngredientsToDish(dishId, dishIngredientsCreateRequest);
        }

        public async Task Delete([FromUri]int dishId, [FromUri]int []ingredientIds)
        {
            await m_dishIngredientService.DeleteIngredientFromDish(dishId,ingredientIds);
        }
    }
}
