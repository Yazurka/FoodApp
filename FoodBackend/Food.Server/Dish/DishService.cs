using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.DishTag;
using Food.Server.Query;
using Food.Server.Services;
using Food.Server.Tag;

namespace Food.Server.Dish
{
    public class DishService : IDishService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;
        private readonly IIdGenerator m_idGenerator;
        private readonly IDishTagService m_dishTagService;

        public DishService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator, IDishTagService dishTagService)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
            m_dishTagService = dishTagService;
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            var dishResults = await m_queryExecutor.HandleAsync(new DishQuery());
            var dishes = new List<Dish>();
            foreach (var dishResult in dishResults)
            {
                //TODO: Finn bedre løsning på sql spørring
                IEnumerable<TagResult> tags = await m_dishTagService.FindTagsForDish(dishResult.Id);
                dishes.Add(new Dish
                {
                    Id = dishResult.Id,
                    Name = dishResult.Name,
                    Description = dishResult.Description,
                    Recipe = dishResult.Recipe,
                    Difficulty = dishResult.Difficulty,
                    Duration = dishResult.Duration,
                    Tags = tags

                });
            }
            
            return dishes;
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
        private DishCommand CreateDishCommand(DishCreateRequest dishRequest)
        {
            var dishCommand = new DishCommand {
                Id = m_idGenerator.GenerateId(),
                Name = dishRequest.Name,
                Description = dishRequest.Description,
                Recipe = dishRequest.Recipe,
                Difficulty = dishRequest.Difficulty,
                Duration = dishRequest.Duration
            };
            return dishCommand;
        }
    }
}
