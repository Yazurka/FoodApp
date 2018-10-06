using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Dish;
using Food.Server.Query;

namespace Food.Server.Search
{
    public class SearchQueryHander : IQueryHandler<SearchQuery, IEnumerable<DishLightResult>>
    {
        private readonly IDbConnection m_dbConnection;
        private readonly IEqualityComparer<DishLightResult> m_equalityComparer;
        public SearchQueryHander(IDbConnection dbConnection, IEqualityComparer<DishLightResult> equalityComparer)
        {
            m_dbConnection = dbConnection;
            m_equalityComparer = equalityComparer;
        }

        public async Task<IEnumerable<DishLightResult>> HandleAsync(SearchQuery query)
        {
            var searchResult = await m_dbConnection.QueryAsync<DishLightResult>(Sql.SearchInDishesAndTags, query);

            return searchResult;
        }
    }
}
