using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.Dish;
using Food.Server.Search;

namespace Food.Server.WebApi.Dish
{
    public class DishController : ApiController
    {
        private readonly IDishService m_dishService;
        private readonly ISearchService m_searchService;

        public DishController(IDishService dishService, ISearchService searchService)
        {
            m_dishService = dishService;
            m_searchService = searchService;
        }

        public async Task<Server.Dish.Dish> Get(int id)
        {
            var result = await m_dishService.FindDish(id);
            return result;
        }
        public async Task<IEnumerable<DishLight>> Get(int limit, int offset)
        {
            var result = await m_dishService.GetAllDishes(limit, offset);
            return result;
        }

        public async Task<IEnumerable<DishLight>> Get(string parameter)
        {
            var result = await m_searchService.Search(parameter);
            return result;
        } 
       
        public async Task<Server.Dish.Dish> Post(DishCreateRequest dishCreateRequest)
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
