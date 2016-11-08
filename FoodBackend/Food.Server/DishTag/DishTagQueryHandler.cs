using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Query;
using Food.Server.Tag;

namespace Food.Server.DishTag
{
    public class DishTagQueryHandler : IQueryHandler<DishTagQuery, IEnumerable<TagResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public DishTagQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TagResult>> HandleAsync(DishTagQuery query)
        {
            var result = await m_dbConnection.QueryAsync<TagResult>(Sql.FindTagsForDish, query);
            return result;                                  
        }
    }
}
