using System.Collections.Generic;
using System.Threading.Tasks;
using Food.Server.Tag;

namespace Food.Server.DishTag
{
    public interface IDishTagService
    {
         Task<IEnumerable<TagResult>> FindTagsForDish(int dishId);
         Task AddTagsToDish(int dishId, int[]TagIds);
         Task RemoveTagsFromDish(int[]dishTagIds);
    }
}
