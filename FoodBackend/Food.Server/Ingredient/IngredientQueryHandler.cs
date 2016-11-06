using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Query;

namespace Food.Server.Ingredient
{
    public class IngredientQueryHandler : IQueryHandler<IngredientQuery, IEnumerable<IngredientResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public IngredientQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task<IEnumerable<IngredientResult>> HandleAsync(IngredientQuery query)
        {
            if (query.Id == 0)
            {
                var result = await m_dbConnection.QueryAsync<IngredientResult>(Sql.AllIngredients);
                return result;
            }
            else
            {
                var result = await m_dbConnection.QueryAsync<IngredientResult>(Sql.FindIngredient,new {query.Id});
                return result;
            }
            
        }
    }
}
