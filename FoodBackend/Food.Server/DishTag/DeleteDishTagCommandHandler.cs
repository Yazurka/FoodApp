using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.DishTag
{
    public class DeleteDishTagCommandHandler : ICommandHandler<DeleteDishTagCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public DeleteDishTagCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DeleteDishTagCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.DeleteDishTag, command);
        }
    }
}
