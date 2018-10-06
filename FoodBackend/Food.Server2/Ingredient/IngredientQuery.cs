using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Query;

namespace Food.Server.Ingredient
{
    public class IngredientQuery : IQuery<IEnumerable<IngredientResult>>
    {
        public int Id { get; set; }
    }
}
