using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Query;

namespace Food.Server.Recipe
{
    public class RecipeQuery : IQuery<IEnumerable<RecipeResult>>
    {
        public int Id { get; set; }
    }
}
