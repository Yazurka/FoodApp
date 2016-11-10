using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.DishIngredientRelation;
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
        private readonly IDishIngredientService m_dishIngredientService;

        public DishService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator, IDishTagService dishTagService, IDishIngredientService dishIngredientService)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
            m_dishTagService = dishTagService;
            m_dishIngredientService = dishIngredientService;
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
                    Author = dishResult.Author,
                    TimeAdded = dishResult.TimeAdded,
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
            var dishTagCreateRequest = CreteDishCreateRequest(dishCommand, dish);

            await m_commandExecutor.ExecuteAsync(dishCommand);

            if (dishTagCreateRequest.TagIds != null)
            {
                await m_dishTagService.AddTagsToDish(dishTagCreateRequest);
            }
            if (dish.DishIngredients != null)
            {
                await m_dishIngredientService.AddIngredientsToDish(dishCommand.Id, dish.DishIngredients);
            }
            

            var postedDish = await FindDish(dishCommand.Id);
            return postedDish;
        }

        private static DishTagCreateRequest CreteDishCreateRequest(DishCommand dishCommand, DishCreateRequest dishCreateRequest)
        {
            return new DishTagCreateRequest { DishId = dishCommand.Id, TagIds = dishCreateRequest.TagIds }; 
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
                Duration = dishRequest.Duration,
                Author = dishRequest.Author,
                TimeAdded = DateTime.Today
            };
            return dishCommand;
        }
    }
}
