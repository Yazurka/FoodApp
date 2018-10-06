using System.Collections.Generic;
using Food.Server.Query;

namespace Food.Server.DishIngredientRelation
{
    public class DishIngredientQuery : IQuery<IEnumerable<DishIngredientResult>>
    {
        public int Id { get; set; }
    }
}
