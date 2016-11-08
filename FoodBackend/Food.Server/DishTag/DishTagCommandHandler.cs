using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.DishTag
{
    public class DishTagCommandHandler : ICommandHandler<DishTagCommand> 
    {
        private readonly IDbConnection m_dbConnection;

        public DishTagCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DishTagCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.InsertDishTag, command);
        }
    }
}
