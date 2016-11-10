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
    public class UpdateDishCommandHandler : ICommandHandler<UpdateDishCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public UpdateDishCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(UpdateDishCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.UpdateDish, command);
        }
    }
}
