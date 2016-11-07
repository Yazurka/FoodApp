using System.Collections.Generic;
using System.Data;
using Food.Server.Command;
using Food.Server.Dish;
using Food.Server.DishIngredientRelation;
using Food.Server.Ingredient;
using Food.Server.Query;
using Food.Server.Services;
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
            serviceRegistry.Register<IQueryHandler<DishQuery, IEnumerable<DishResult>>, DishQueryHandler>();
            serviceRegistry.Register<IQueryHandler<DishIngredientQuery, IEnumerable<DishIngredientResult>>, DishIngredientQueryHandler>();

            serviceRegistry.Register<ICommandHandler<IngredientCommand>, IngredientCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DishCommand>, DishCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DishIngredientCommand>, DishIngredientCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DeleteIngredientCommand>, DeleteIngredientCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DeleteDishCommand>, DeleteDishCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DeleteDishIngredientCommand>, DeleteDishIngredientCommandHandler>();

            serviceRegistry.Register<IIngredientService, IngredientService>();
            serviceRegistry.Register<IDishService, DishService>();
            serviceRegistry.Register<IDishIngredientService, DishIngredientService>();
            serviceRegistry.Register<IIdGenerator, IdGenerator>(new PerRequestLifeTime());

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
