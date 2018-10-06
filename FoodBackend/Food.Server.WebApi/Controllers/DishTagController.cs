using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.DishTag;
using Food.Server.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food.Server.WebApi.DishTag
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishTagController : ControllerBase
    {
        private readonly IDishTagService m_dishTagService;

        public DishTagController(IDishTagService dishTagService)
        {
            m_dishTagService = dishTagService;
        }

        [Authorize]
        [HttpPost]
        public async Task Post(DishTagCreateRequest dishTagCreateRequest)
        {
            await m_dishTagService.AddTagsToDish(dishTagCreateRequest);
        }

        [Authorize]
        [HttpDelete]
        public async Task Delete([FromRoute]int dishId, [FromRoute]int[] tagIds)
        {
            await m_dishTagService.RemoveTagsFromDish(dishId,tagIds);
        }

        [HttpGet]
        public async Task<IEnumerable<TagResult>> Get(int dishId)
        {
            var result = await m_dishTagService.FindTagsForDish(dishId);
            return result;
        }
    }
}
