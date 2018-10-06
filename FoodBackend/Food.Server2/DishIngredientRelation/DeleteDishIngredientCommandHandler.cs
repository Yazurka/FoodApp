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
    public class DeleteDishIngredientCommandHandler : ICommandHandler<IEnumerable<DeleteDishIngredientCommand>>
    {
        private readonly IDbConnection m_dbConnection;

        public DeleteDishIngredientCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(IEnumerable<DeleteDishIngredientCommand> commands)
        {
            await m_dbConnection.ExecuteAsync(Sql.DeleteDishIngredient, commands);
        }
    }
}
