using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food.Server.Tag
{
    public interface ITagService
    {
        Task<IEnumerable<TagResult>> GetAllTags();
        Task<TagResult> FindTag(int id);
        Task<TagResult> PostTag(TagCreateRequest tagCreateRequest);
        Task DeleteTag(int id);
        Task UpdateTag(TagUpdateRequest tagUpdateRequest);
    }
}   
