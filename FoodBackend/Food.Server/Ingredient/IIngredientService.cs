using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Ingredient
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientResult>> GetAllIngredients();

    }
}
