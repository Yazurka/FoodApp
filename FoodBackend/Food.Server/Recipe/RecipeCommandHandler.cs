using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Food.Server.Command;

namespace Food.Server.Recipe
{
    public class RecipeCommandHandler: ICommandHandler<RecipeCommand>
    {
        private readonly IDbConnection m_dbConnection;

        public RecipeCommandHandler(IDbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public async Task HandleAsync(RecipeCommand command)
        {
            try
            {
                await m_dbConnection.ExecuteAsync(Sql.InsertRecipe, command);
            }
            catch (Exception exception)
            {
                
            }
           
        }
    }
}
