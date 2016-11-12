
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Query;

namespace Food.Server.Dish
{
    public class DishLightQueryHandler : IQueryHandler<DishLightQuery, IEnumerable<DishLightResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public DishLightQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task<IEnumerable<DishLightResult>> HandleAsync(DishLightQuery query)
        {
            var result = await m_dbConnection.QueryAsync<DishLightResult>(Sql.AllDishesLight);

            return result;
        }
    }
}
