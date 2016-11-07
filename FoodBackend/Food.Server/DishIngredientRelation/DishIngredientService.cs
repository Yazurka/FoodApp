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

        public async Task<DishIngredientResult> FindDishIngredient(int id)
        {
            var result = (await m_queryExecutor.HandleAsync(new DishIngredientQuery { Id = id })).FirstOrDefault();
            return result;
        }

        public async Task<DishIngredientResult> PostDishIngredient(DishIngredientCreateRequest dishIngredient)
        {
            var dishIngredientCommand = CreateIngredientCommand(dishIngredient);
            await m_commandExecutor.ExecuteAsync(dishIngredientCommand);
            var postedDishIngredient = await FindDishIngredient(dishIngredientCommand.Id);
            return postedDishIngredient;
        }

        public async Task DeleteDishIngredient(int id)
        {
            await m_commandExecutor.ExecuteAsync(new DeleteDishIngredientCommand { Id = id });
        }

        private DishIngredientCommand CreateIngredientCommand(DishIngredientCreateRequest dishIngredientRequest)
        {
            var dishIngredientCommand = new DishIngredientCommand
            {
                Id = m_idGenerator.GenerateId(),
                Amount = dishIngredientRequest.Amount,
                Unit = dishIngredientRequest.Unit,
                Dish_id_fk = dishIngredientRequest.Dish_id_fk,
                Ingredient_id_fk = dishIngredientRequest.Ingredient_id_fk
                    
            };
            return dishIngredientCommand;
        }
    }
}
