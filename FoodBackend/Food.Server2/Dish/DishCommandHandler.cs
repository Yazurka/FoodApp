using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;
using Food.Server.Ingredient;

namespace Food.Server.Dish
{
    public class DishCommandHandler : ICommandHandler<DishCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public DishCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DishCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.InsertDish, command);
        }
    }
}
