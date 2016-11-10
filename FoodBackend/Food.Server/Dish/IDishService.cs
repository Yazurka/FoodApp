using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Dish
{
    public interface IDishService
    {
        Task<IEnumerable<Dish>> GetAllDishes();
        Task<DishResult> FindDish(int id);
        Task<DishResult> PostDish(DishCreateRequest dish);
        Task DeleteDish(int id);
        Task UpdateDish(int id, UpdateDishRequest dishUpdateRequest);
    }
}
