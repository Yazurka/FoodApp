using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Query;

namespace Food.Server.Recipe
{
    public class RecipeQueryHandler : IQueryHandler<RecipeQuery, IEnumerable<RecipeResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public RecipeQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task<IEnumerable<RecipeResult>> HandleAsync(RecipeQuery query)
        {

            if (query.Id == 0)
            {
                var result = await m_dbConnection.QueryAsync<RecipeResult>(Sql.AllRecipes);
                return result;
            }
            else
            {
                var result = await m_dbConnection.QueryAsync<RecipeResult>(Sql.FindRecipe, new { query.Id });
                return result;
            }

        }
    }
}
