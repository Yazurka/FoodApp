using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Query;

namespace Food.Server.Dish
{
    public class DishQueryHandler : IQueryHandler<DishQuery, IEnumerable<DishResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public DishQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task<IEnumerable<DishResult>> HandleAsync(DishQuery query)
        {
            if (query.Id == 0)
            {
                var result = await m_dbConnection.QueryAsync<DishResult>(Sql.AllDishes);
                return result;
            }
            else
            {
                var result = await m_dbConnection.QueryAsync<DishResult>(Sql.FindDish, new { query.Id });
                return result;
            }

        }
    }
}
