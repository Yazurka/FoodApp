﻿using System.Net.Http.Formatting;
using System.Web.Http;
using LightInject;
using Owin;
using Swashbuckle.Application;
using Food.Server.WebApi.Authorization;

namespace Food.Server.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = new ServiceContainer();

            Configure(container);
            container.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();
            container.RegisterApiControllers(typeof(Startup).Assembly);
            container.EnableWebApi(config);


            ConfigureHttpRoutes(config);
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            //ConfigureSwagger(config);
            //config.EnableSwagger(x => new SwaggerConfig());
            app.Use<AuthorizeTicketMiddleware>();
            app.UseWebApi(config);
        }
        private static void ConfigureSwagger(HttpConfiguration config)
        {
            config.EnableSwagger(
                c => c.SingleApiVersion("v1", "FoodServer").Description("Food Server Web Api"))
                .EnableSwaggerUi(
                    c => c.CustomAsset("index", typeof(Startup).Assembly, "Food.Server.WebApi.Swagger.index.html"));
        }
        public virtual void Configure(IServiceContainer serviceContainer)
        {
            serviceContainer.RegisterFrom<CompositionRoot>();
        }
        private static void ConfigureHttpRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
