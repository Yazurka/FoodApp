using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.Recipe
{
    public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public DeleteRecipeCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(DeleteRecipeCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.DeleteRecipe, command);
        }
    }
}
