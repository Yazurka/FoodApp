using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.Dish;

namespace Food.Server.WebApi.Dish
{
    public class DishController : ApiController
    {
        private readonly IDishService m_dishService;

        public DishController(IDishService dishService)
        {
            m_dishService = dishService;
        }

        public async Task<DishResult> Get(int id)
        {
            var result = await m_dishService.FindDish(id);
            return result;
        }
        public async Task<IEnumerable<Server.Dish.Dish>> Get()
        {
            var result = await m_dishService.GetAllDishes();
            return result;
        }
       
        public async Task<DishResult> Post(DishCreateRequest dishCreateRequest)
        {
            var result = await m_dishService.PostDish(dishCreateRequest);
            return result;
        }
        public async Task Delete(int id)
        {
            await m_dishService.DeleteDish(id);
        }

        public async Task Put([FromUri]int id, [FromBody]UpdateDishRequest updateDishRequest)
        {
            await m_dishService.UpdateDish(id, updateDishRequest);
        }
    }
}
