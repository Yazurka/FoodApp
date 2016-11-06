using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Query;

namespace Food.Server.Dish
{
    public class DishQuery :  IQuery<IEnumerable<DishResult>>
    {
        public int Id { get; set; }
    }
}
