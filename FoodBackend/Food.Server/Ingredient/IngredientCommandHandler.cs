using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;
using Food.Server.Services;

namespace Food.Server.Ingredient
{
    public class IngredientCommandHandler : ICommandHandler<IngredientCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public IngredientCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(IngredientCommand command)
        {
           
            await m_dbConnection.ExecuteAsync(Sql.InsertIngredient, command);
        }

    }
}
