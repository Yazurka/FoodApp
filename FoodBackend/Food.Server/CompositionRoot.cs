using System.Collections.Generic;
using System.Data;
using Food.Server.Command;
using Food.Server.Ingredient;
using Food.Server.Query;

using LightInject;
using MySql.Data.MySqlClient;

namespace Food.Server
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
           

            serviceRegistry.Register<IQueryExecutor>(factory => new QueryExecutor((IServiceFactory)serviceRegistry));
            serviceRegistry.Register<ICommandExecutor>(factory => new CommandExecutor((IServiceFactory)serviceRegistry));
            serviceRegistry.Register<IDbConnection>(factory => CreateMySqlConnection(factory), new PerScopeLifetime());

            serviceRegistry.Register<IQueryHandler<IngredientQuery, IEnumerable<IngredientResult>>, IngredientQueryHandler>();
            serviceRegistry.Register<IIngredientService, IngredientService>();


            serviceRegistry.Register<IConfiguration, AppSettingsConfiguration>(new PerContainerLifetime());
        }

        private static MySqlConnection CreateMySqlConnection(IServiceFactory factory)
        {
            var connection = new MySqlConnection(factory.GetInstance<IConfiguration>().ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
