using System.Collections.Generic;
using Food.Server.Dish;
using Food.Server.Query;

namespace Food.Server.Search
{
    public class SearchQuery : IQuery<IEnumerable<DishLightResult>>
    {
        public string Parameter { get; set; }
    }
}