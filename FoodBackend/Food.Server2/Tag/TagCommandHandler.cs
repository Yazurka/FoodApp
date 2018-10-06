using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.Tag
{
    public class TagCommandHandler: ICommandHandler<TagCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public TagCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(TagCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.InsertTag, command);

        }
    }
}
