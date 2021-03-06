﻿using System.Collections.Generic;
using System.Data;
using Food.Server.Command;
using Food.Server.Dish;
using Food.Server.DishIngredientRelation;
using Food.Server.DishTag;
using Food.Server.Ingredient;
using Food.Server.Query;
using Food.Server.Search;
using Food.Server.Services;
using Food.Server.Tag;
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
            serviceRegistry.Register<IQueryHandler<TagQuery, IEnumerable<TagResult>>, TagQueryHandler>();
            serviceRegistry.Register<IQueryHandler<DishTagQuery, IEnumerable<TagResult>>, DishTagQueryHandler>();
            serviceRegistry.Register<IQueryHandler<DishLightQuery, IEnumerable<DishLightResult>>, DishLightQueryHandler>();
            serviceRegistry.Register<IQueryHandler<SearchQuery, IEnumerable<DishLightResult>>, SearchQueryHander>();

            serviceRegistry.Register<ICommandHandler<IngredientCommand>, IngredientCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DishCommand>, DishCommandHandler>();
            serviceRegistry.Register<ICommandHandler<IEnumerable<DishIngredientCommand>>, DishIngredientCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DeleteIngredientCommand>, DeleteIngredientCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DeleteDishCommand>, DeleteDishCommandHandler>();
            serviceRegistry.Register<ICommandHandler<UpdateDishCommand>, UpdateDishCommandHandler>();
            serviceRegistry.Register<ICommandHandler<UpdateTagCommand>, UpdateTagCommandHandler>();
            serviceRegistry.Register<ICommandHandler<IEnumerable<DeleteDishIngredientCommand>>, DeleteDishIngredientCommandHandler>();
            serviceRegistry.Register<ICommandHandler<TagCommand>, TagCommandHandler>();
            serviceRegistry.Register<ICommandHandler<DeleteTagCommand>, DeleteTagCommandHandler>();
            serviceRegistry.Register<ICommandHandler<IEnumerable<DeleteDishTagCommand>>, DeleteDishTagCommandHandler>();
            serviceRegistry.Register<ICommandHandler<IEnumerable<DishTagCommand>>, DishTagCommandHandler>();
            serviceRegistry.Register<ICommandHandler<UpdateIngredientCommand>, UpdateIngredientCommandHandler>();

            serviceRegistry.Register<IIngredientService, IngredientService>();
            serviceRegistry.Register<IDishService, DishService>();
            serviceRegistry.Register<IDishTagService, DishTagService>();
            serviceRegistry.Register<IDishIngredientService, DishIngredientService>();
            serviceRegistry.Register<ITagService, TagService>();
            serviceRegistry.Register<ISearchService, SearchService>();
            serviceRegistry.Register<IIdGenerator, IdGenerator>(new PerRequestLifeTime());
            serviceRegistry.Register<IEqualityComparer<DishLightResult>, DishLightResultComparer>(new PerContainerLifetime());

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
