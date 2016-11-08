using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Tag;

namespace Food.Server.DishTag
{
    public interface IDishTagService
    {
         Task<IEnumerable<TagResult>> FindTagsForDish(int dishId);
       
    }
}
