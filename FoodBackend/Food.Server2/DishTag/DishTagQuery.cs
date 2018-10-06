using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Query;
using Food.Server.Tag;

namespace Food.Server.DishTag
{
    public class DishTagQuery : IQuery<IEnumerable<TagResult>>
    {
        public int Id { get; set; } //DishId
    }
}
