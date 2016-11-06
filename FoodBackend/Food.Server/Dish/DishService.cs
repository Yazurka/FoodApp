using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.Query;
using Food.Server.Services;

namespace Food.Server.Dish
{
    public class DishService : IDishService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;
        private readonly IIdGenerator m_idGenerator;

        public DishService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
        }

        public async Task<IEnumerable<DishResult>> GetAllDishes()
        {
            var result = await m_queryExecutor.HandleAsync(new DishQuery());
            return result;
        }

        public async Task<DishResult> FindDish(int id)
        {
            var result = (await m_queryExecutor.HandleAsync(new DishQuery {Id = id})).FirstOrDefault();
            return result;
        }

        public async Task<DishResult> PostDish(DishCreateRequest dish)
        {
            var dishCommand = CreateDishCommand(dish);

            await m_commandExecutor.ExecuteAsync(dishCommand);

            var postedDish = await FindDish(dishCommand.Id);
            return postedDish;
        }

        public async Task DeleteDish(int id)
        {
            await m_commandExecutor.ExecuteAsync(new DeleteDishCommand { Id = id });
        }
        private DishCommand CreateDishCommand(DishCreateRequest ingredientRequest)
        {
            var dishCommand = new DishCommand { Id = m_idGenerator.GenerateId(), Name = ingredientRequest.Name, Description = ingredientRequest.Description };
            return dishCommand;
        }
    }
}
