using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;
using Food.Server.Tag;

namespace Food.Server.Tag
{
    public class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public DeleteTagCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DeleteTagCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.DeleteTag, command);
        }
    }
}
