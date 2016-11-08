using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.Tag;

namespace Food.Server.WebApi.Tag
{
    public class TagController : ApiController
    {
        private readonly ITagService m_tagService;

        public TagController(ITagService tagService)
        {
            m_tagService = tagService;
        }

        public async Task<TagResult> Get(int id)
        {
            var result = await m_tagService.FindTag(id);
            return result;  
        }
        public async Task<IEnumerable<TagResult>> Get()
        {
            var result = await m_tagService.GetAllTags();
            return result;
        }
        public async Task<TagResult> Post(TagCreateRequest tagCreateRequest)
        {
            var result = await m_tagService.PostTag(tagCreateRequest);
            return result;
        }
        public async Task Delete(int id)
        {
            await m_tagService.DeleteTag(id);
        }
    }
}
