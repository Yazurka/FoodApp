using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

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
