using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.Ingredient
{
    public class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public UpdateIngredientCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(UpdateIngredientCommand command)
        {
            await m_dbConnection.ExecuteAsync(Sql.UpdateIngredient, command);
        }
    }
}