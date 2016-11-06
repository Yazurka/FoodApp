using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.Ingredient
{
    public class DeleteIngredientCommandHandler : ICommandHandler<DeleteIngredientCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public DeleteIngredientCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DeleteIngredientCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.DeleteIngredient, command);
        }
    }
}
