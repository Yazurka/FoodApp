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

        public async Task<IEnumerable<DishLight>> GetAllDishes(int limit, int offset)
        {

            var dishResults = await m_queryExecutor.HandleAsync(new DishLightQuery {Limit = limit, Offset = offset});
       
            var dishes = new List<DishLight>();
            foreach (var dishResult in dishResults)
            {
                //TODO: Finn bedre løsning på sql spørring
                IEnumerable<TagResult> tags = await m_dishTagService.FindTagsForDish(dishResult.Id);
                dishes.Add(new DishLight
                {
                    Id = dishResult.Id,
                    Name = dishResult.Name,
                    Description = dishResult.Description,
                    Difficulty = dishResult.Difficulty,
                    Duration = dishResult.Duration,
                    Author = dishResult.Author,
                    TimeAdded = dishResult.TimeAdded,
                    Tags = tags

                });
            }
            
            return dishes;
        }

        public async Task<Dish> FindDish(int id)
        {
            
            var result = (await m_queryExecutor.HandleAsync(new DishQuery {Id = id})).FirstOrDefault();
            
            if (result==null)
            {
                return null;
            }
            var ingredients = await m_dishIngredientService.FindIngredientsForDish(id);
            var tags = await m_dishTagService.FindTagsForDish(id);
            var dish = new Dish {
                Author = result.Author,
                Id = result.Id,
                Recipe = result.Recipe,
                Duration = result.Duration,
                Difficulty = result.Difficulty,
                Description = result.Description,
                TimeAdded = result.TimeAdded,
                Name = result.Name,
                Ingredients = ingredients,
                Tags = tags
            };
            return dish;
        }

        public async Task<Dish> PostDish(DishCreateRequest dish)
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
            var dishToBeDeleted = await FindDish(id);
            var ingredientIds = dishToBeDeleted.Ingredients.Select(x => x.Id).ToArray();
            var tagIds = dishToBeDeleted.Tags.Select(x => x.Id).ToArray();

            if (ingredientIds.Count()>0)
            {
                await m_dishIngredientService.DeleteIngredientFromDish(id, ingredientIds);
            }
            if (tagIds.Count()>0)
            {
                 await m_dishTagService.RemoveTagsFromDish(id, tagIds);
            }
            
            await m_commandExecutor.ExecuteAsync(new DeleteDishCommand { Id = id });
        }

        public async Task UpdateDish(int id, UpdateDishRequest dishUpdateRequest)
        {
            var updateDishCommand = new UpdateDishCommand
            {
                Id = id,
                Author = dishUpdateRequest.Author,
                Description = dishUpdateRequest.Description,
                Difficulty = dishUpdateRequest.Difficulty,
                Duration = dishUpdateRequest.Duration,
                Name = dishUpdateRequest.Name,
                Recipe = dishUpdateRequest.Recipe
            };
            await m_commandExecutor.ExecuteAsync(updateDishCommand);
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
