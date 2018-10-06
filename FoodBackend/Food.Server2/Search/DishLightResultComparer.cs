using System;
using System.Collections;
using System.Collections.Generic;
using Food.Server.Dish;

namespace Food.Server.Search
{
    public class DishLightResultComparer : IEqualityComparer<DishLightResult>
    {
        public bool Equals(DishLightResult x, DishLightResult y)
        {
            if (ReferenceEquals(x, y)) return true;
            return x.Id == y.Id;
        }

        public int GetHashCode(DishLightResult obj)
        {
            var productIdHash = obj.Id.GetHashCode();
            return productIdHash;
        }
    }
}