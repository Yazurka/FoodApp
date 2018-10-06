using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Query;

namespace Food.Server.Tag
{
    public class TagQueryHandler : IQueryHandler<TagQuery, IEnumerable<TagResult>>
    {
        private readonly IDbConnection m_dbConnection;

        public TagQueryHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TagResult>> HandleAsync(TagQuery query)
        {

            if (query.Id == 0)
            {
                var result = await m_dbConnection.QueryAsync<TagResult>(Sql.AllTags);
                return result;
            }
            else
            {
                var result = await m_dbConnection.QueryAsync<TagResult>(Sql.FindTag, new { query.Id });
                return result;
            }

        }
    }
}
