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

        public async Task<IEnumerable<DishIngredientResult>> FindIngredientsForDish(int dishId)
        {
            var result = await m_queryExecutor.HandleAsync(new DishIngredientQuery { Id = dishId });
            return result;
        }

        public async Task DeleteIngredientFromDish(int dishId, int[] ingredientIds)
        {
            List<DeleteDishIngredientCommand> deleteDishIngredientCommands = new List<DeleteDishIngredientCommand>();
            foreach (var ingredientid in ingredientIds)
            {
                deleteDishIngredientCommands.Add(new DeleteDishIngredientCommand
                {
                    DishId = dishId,
                    IngredientId = ingredientid

                });
            }

            await m_commandExecutor.ExecuteAsync(deleteDishIngredientCommands.AsEnumerable());
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
                    Amount = dishIngredient.Amount,
                    Comment = dishIngredient.Comment
                });
            }

            await m_commandExecutor.ExecuteAsync(dishIngredientCommands.AsEnumerable());
            
        }

    }
}
