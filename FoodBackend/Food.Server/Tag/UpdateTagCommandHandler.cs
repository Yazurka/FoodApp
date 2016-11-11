using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.Tag
{
    public class UpdateTagCommandHandler : ICommandHandler<UpdateTagCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public UpdateTagCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(UpdateTagCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.UpdateTag, command);
        }
    }
}
