using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.Query;
using Food.Server.Services;

namespace Food.Server.Ingredient
{
    public class IngredientService : IIngredientService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;
        private readonly IIdGenerator m_idGenerator;

        public IngredientService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IIdGenerator idGenerator)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
            m_idGenerator = idGenerator;
        }

        public async Task<IEnumerable<IngredientResult>> GetAllIngredients()
        {
           var result = await m_queryExecutor.HandleAsync(new IngredientQuery());
            
            return result;
        }
        public async Task<IngredientResult> FindIngredient(int id)
        {
            var result = (await m_queryExecutor.HandleAsync(new IngredientQuery {Id = id}))
                .FirstOrDefault();

            return result;
        }

        public async Task<IngredientResult> PostIngredient(IngredientCreateRequest ingredientRequest)
        {
            var ingredientCommand = CreateIngredientCommand(ingredientRequest);

            await m_commandExecutor.ExecuteAsync(ingredientCommand);

            var postedIngredient = await FindIngredient(ingredientCommand.Id);
            return postedIngredient;
        }

        public Task DeleteIngredient(int id)
        {
            throw new NotImplementedException();
        }

        private IngredientCommand CreateIngredientCommand(IngredientCreateRequest ingredientRequest)
        {
            var ingredientCommand = new IngredientCommand { Id = m_idGenerator.GenerateId(), Name = ingredientRequest.Name, Description = ingredientRequest.Description };
            return ingredientCommand;
        }
    }
}
