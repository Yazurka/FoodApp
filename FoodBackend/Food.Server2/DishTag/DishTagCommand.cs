﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.DishTag
{
    public class DishTagCommand
    {
        public int Id { get; set; }
        public int Dish_id_fk { get; set; }
        public int Tag_id_fk { get; set; }
    }
}
