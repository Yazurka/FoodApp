using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.DishTag;
using Food.Server.Tag;

namespace Food.Server.WebApi.DishTag
{
    public class DishTagController : ApiController
    {
        private readonly IDishTagService m_dishTagService;

        public DishTagController(IDishTagService dishTagService)
        {
            m_dishTagService = dishTagService;
        }

        [Authorize]
        public async Task Post(DishTagCreateRequest dishTagCreateRequest)
        {
            await m_dishTagService.AddTagsToDish(dishTagCreateRequest);
        }
        [Authorize]
        public async Task Delete([FromUri]int dishId, [FromUri]int[] tagIds)
        {
            await m_dishTagService.RemoveTagsFromDish(dishId,tagIds);
        }

        public async Task<IEnumerable<TagResult>> Get(int dishId)
        {
            var result = await m_dishTagService.FindTagsForDish(dishId);
            return result;
        }
    }
}
