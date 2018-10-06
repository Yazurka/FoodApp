using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Food.Server.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food.Server.WebApi.Tag
{
    public class TagController : Controller
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

        [Authorize]
        public async Task<TagResult> Post(TagCreateRequest tagCreateRequest)
        {
            var result = await m_tagService.PostTag(tagCreateRequest);
            return result;
        }

        [Authorize]
        public async Task Delete(int id)
        {
            await m_tagService.DeleteTag(id);
        }

        [Authorize]
        public async Task Put(TagUpdateRequest tagUpdateRequest)
        {
            await m_tagService.UpdateTag(tagUpdateRequest);
        } 
    }
}
