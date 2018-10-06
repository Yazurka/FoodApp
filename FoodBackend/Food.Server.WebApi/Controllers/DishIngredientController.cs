using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.DishIngredientRelation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food.Server.WebApi.DishIngredient
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishIngredientController : ControllerBase
    {
        private readonly IDishIngredientService m_dishIngredientService;

        public DishIngredientController(IDishIngredientService dishIngredientService)
        {
            m_dishIngredientService = dishIngredientService;
        }

        [HttpGet("id")]
        public async Task<IEnumerable<DishIngredientResult>> Get(int id)
        {
            var result = await m_dishIngredientService.FindIngredientsForDish(id);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<DishIngredientResult>> Get()  
        {
            var result = await m_dishIngredientService.GetAllDishIngredients();
            return result;
        }

        [Authorize]
        [HttpPost]
        public async Task Post([FromRoute]int dishId, [FromBody]DishIngredientCreateRequest[] dishIngredientsCreateRequest)
        {
            await m_dishIngredientService.AddIngredientsToDish(dishId, dishIngredientsCreateRequest);
        }

        [Authorize]
        [HttpDelete]
        public async Task Delete([FromRoute]int dishId, [FromRoute]int []ingredientIds)
        {
            await m_dishIngredientService.DeleteIngredientFromDish(dishId,ingredientIds);
        }
    }
}
