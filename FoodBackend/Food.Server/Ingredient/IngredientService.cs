using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.Server.Command;
using Food.Server.Query;

namespace Food.Server.Ingredient
{
    public class IngredientService : IIngredientService
    {
        private readonly IQueryExecutor m_queryExecutor;
        private readonly ICommandExecutor m_commandExecutor;

        public IngredientService(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            m_queryExecutor = queryExecutor;
            m_commandExecutor = commandExecutor;
        }

        public async Task<IEnumerable<IngredientResult>> GetAllIngredients()
        {
            IEnumerable<IngredientResult> result = new List<IngredientResult>();
            try
            {
                result = await m_queryExecutor.HandleAsync(new IngredientQuery());
            }
            catch (Exception ecException)
            {
                
            }
            return result;
        }
    }
}
