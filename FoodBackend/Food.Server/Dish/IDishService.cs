﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Dish
{
    public interface IDishService
    {
        Task<IEnumerable<DishLight>> GetAllDishes(int limit, int offset);
        Task<Dish> FindDish(int id);
        Task<Dish> PostDish(DishCreateRequest dish);
        Task DeleteDish(int id);
        Task UpdateDish(int id, UpdateDishRequest dishUpdateRequest);
    }
}
