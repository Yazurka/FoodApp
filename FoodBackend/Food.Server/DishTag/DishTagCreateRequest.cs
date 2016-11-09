using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.DishTag
{
    public class DishTagCreateRequest
    {
        public int DishId { get; set; }
        public int[] TagIds { get; set; }
    }
}
