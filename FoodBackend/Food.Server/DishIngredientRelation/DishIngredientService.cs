using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.Query;
using Food.Server.Services;

namespace Food.Server.DishIngredientRelation
{
    public class DishIngredientService : IDishIngredientService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;
        private readonly IIdGenerator m_idGenerator;

        public DishIngredientService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
        }

        public async Task<IEnumerable<DishIngredientResult>> GetAllDishIngredients()
        {
            var result = await m_queryExecutor.HandleAsync(new DishIngredientQuery());
            return result;
        }

        public async Task<DishIngredientResult> FindIngredientForDish(int dishId)
        {
            var result = (await m_queryExecutor.HandleAsync(new DishIngredientQuery { Id = dishId })).FirstOrDefault();
            return result;
        }

        public async Task DeleteDishIngredient(int id)
        {
            await m_commandExecutor.ExecuteAsync(new DeleteDishIngredientCommand { Id = id });
        }

        public async Task AddIngredientsToDish(int dishId, DishIngredientCreateRequest[] dishIngredients)
        {
            List<DishIngredientCommand> dishIngredientCommands = new List<DishIngredientCommand>();
            foreach (var dishIngredient in dishIngredients)
            {
                dishIngredientCommands.Add(new DishIngredientCommand
                {
                    Id = m_idGenerator.GenerateId(),
                    Dish_id_fk = dishId,
                    Ingredient_id_fk = dishIngredient.IngredientId,
                    Unit = dishIngredient.Unit,
                    Amount = dishIngredient.Amount
                });
            }

            await m_commandExecutor.ExecuteAsync(dishIngredientCommands.AsEnumerable());
            
        }

    }
}
