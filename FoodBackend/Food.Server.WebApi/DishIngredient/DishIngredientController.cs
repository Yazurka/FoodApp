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

        public async Task<DishIngredientResult> Get(int id)
        {
            var result = await m_dishIngredientService.FindDishIngredient(id);
            return result;
        }
        public async Task<IEnumerable<DishIngredientResult>> Get()
        {
            var result = await m_dishIngredientService.GetAllDishIngredients();
            return result;
        }
        public async Task<DishIngredientResult> Post(DishIngredientCreateRequest dishCreateRequest)
        {
            var result = await m_dishIngredientService.PostDishIngredient(dishCreateRequest);
            return result;
        }
        public async Task Delete(int id)
        {
            await m_dishIngredientService.DeleteDishIngredient(id);
        }
    }
}
