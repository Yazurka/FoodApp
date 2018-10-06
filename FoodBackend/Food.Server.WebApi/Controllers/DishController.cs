using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.Dish;
using Food.Server.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food.Server.WebApi.Dish
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService m_dishService;
        private readonly ISearchService m_searchService;

        public DishController(IDishService dishService, ISearchService searchService)
        {
            m_dishService = dishService;
            m_searchService = searchService;
        }

        [HttpGet("{id}")]
        public async Task<Server.Dish.Dish> Get(int id)
        {
            var result = await m_dishService.FindDish(id);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<DishLight>> Get(int limit, int offset)
        {
            var result = await m_dishService.GetAllDishes(limit, offset);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<DishLight>> Get(string parameter, int limit, int offset)
        {
            var result = await m_searchService.Search(parameter, limit, offset);
            return result;
        }

        [Authorize]
        [HttpPost]
        public async Task<Server.Dish.Dish> Post(DishCreateRequest dishCreateRequest)
        {
            var result = await m_dishService.PostDish(dishCreateRequest);
            return result;
        }

        [Authorize]
        [HttpDelete]
        public async Task Delete(int id)
        {
            await m_dishService.DeleteDish(id);
        }

        [Authorize]
        [HttpPut]
        public async Task Put([FromRoute]int id, [FromBody]UpdateDishRequest updateDishRequest)
        {
            await m_dishService.UpdateDish(id, updateDishRequest);
        }
    }
}
