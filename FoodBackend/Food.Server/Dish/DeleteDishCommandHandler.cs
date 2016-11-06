using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.Dish
{
    public class DeleteDishCommandHandler : ICommandHandler<DeleteDishCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public DeleteDishCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DeleteDishCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.DeleteDish, command);
        }
    }
}
