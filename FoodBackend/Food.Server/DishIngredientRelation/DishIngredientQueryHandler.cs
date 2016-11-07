using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Query;

namespace Food.Server.DishIngredientRelation
{
    public class DishIngredientQueryHandler : IQueryHandler<DishIngredientQuery, IEnumerable<DishIngredientResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public DishIngredientQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task<IEnumerable<DishIngredientResult>> HandleAsync(DishIngredientQuery query)
        {
            if (query.Id == 0)
            {
                var result = await m_dbConnection.QueryAsync<DishIngredientResult>(Sql.AllDishIngredients);
                return result;
            }
            else
            {
                var result = await m_dbConnection.QueryAsync<DishIngredientResult>(Sql.FindDishIngredient, new { query.Id });
                return result;
            }
        }
    }
}
