﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.DishIngredientRelation
{
    public interface IDishIngredientService
    {
        Task<IEnumerable<DishIngredientResult>> GetAllDishIngredients();
        Task<DishIngredientResult> FindDishIngredient(int id);
        Task<DishIngredientResult> PostDishIngredient(DishIngredientCreateRequest dishIngredient);
        Task DeleteDishIngredient(int id);
    }
}
