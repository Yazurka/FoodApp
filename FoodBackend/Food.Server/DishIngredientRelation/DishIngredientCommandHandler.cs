using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.DishIngredientRelation
{
    public class DishIngredientCommandHandler : ICommandHandler<DishIngredientCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public DishIngredientCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DishIngredientCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.InsertDishIngredient, command);
        }
    }
}
