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
        private IEqualityComparer<DishLightResult> m_equalityComparer;
        public SearchQueryHander(IDbConnection dbConnection, IEqualityComparer<DishLightResult> equalityComparer)
        {
            m_dbConnection = dbConnection;
            m_equalityComparer = equalityComparer;
        }

        public async Task<IEnumerable<DishLightResult>> HandleAsync(SearchQuery query)
        {
            var dishesWithTagsFitting = await m_dbConnection.QueryAsync<DishLightResult>(Sql.SearchInTags, query);
            var dishesFitting = await m_dbConnection.QueryAsync<DishLightResult>(Sql.SearchInDishes, query);

            var result = Combine(dishesWithTagsFitting, dishesFitting);
           
            return result;
        }

        private IEnumerable<DishLightResult> Combine(IEnumerable<DishLightResult> first, IEnumerable<DishLightResult> second)
        {
            if (second == null)
            {
                return first;
            }
            if (first == null)
            {
                return second;
            }
            IEnumerable<DishLightResult> union = first.Union(second, m_equalityComparer);
            return union;
        } 
    }
}
