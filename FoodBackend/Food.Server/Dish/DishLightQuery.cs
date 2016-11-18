using System.Collections.Generic;
using Food.Server.Query;

namespace Food.Server.Dish
{
    public class DishLightQuery : IQuery<IEnumerable<DishLightResult>>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
