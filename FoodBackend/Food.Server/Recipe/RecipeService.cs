using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.Query;
using Food.Server.Services;

namespace Food.Server.Recipe
{
    public class RecipeService : IRecipeService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;
        private readonly IIdGenerator m_idGenerator;

        public RecipeService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
        }

        public async Task<IEnumerable<RecipeResult>> GetAllRecipes()
        {
            var result = await m_queryExecutor.HandleAsync(new RecipeQuery());
            return result;
        }

        public async Task<RecipeResult> FindRecipe(int id)
        {
            var result = (await m_queryExecutor.HandleAsync(new RecipeQuery {Id = id})).FirstOrDefault();
            return result;
        }

        public async Task<RecipeResult> PostRecipe(RecipeCreateRequest recipeCreateRequest)
        {
            var recipeCommand = CreateIngredientCommand(recipeCreateRequest);
            await m_commandExecutor.ExecuteAsync(recipeCommand);
            var postedRecipe = await FindRecipe(recipeCommand.Id);
            return postedRecipe;
        }

        public async Task DeleteRecipe(int id)
        {
            await m_commandExecutor.ExecuteAsync(new DeleteRecipeCommand { Id = id });
        }

        private RecipeCommand CreateIngredientCommand(RecipeCreateRequest recipeRequest)
        {
            var recipeCommand = new RecipeCommand
            {
                Id = m_idGenerator.GenerateId(),
                Description_short = recipeRequest.DescriptionShort,
                Difficulty = recipeRequest.Difficulty,
                Dish_id_fk = recipeRequest.DishId,
                Duration = recipeRequest.Duration,
                Description = recipeRequest.Description
            };
            return recipeCommand;
        }
    }
}
