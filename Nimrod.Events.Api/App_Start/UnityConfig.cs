using AutoMapper;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Nimrod.Events.DataAccess.EF;
using Nimrod.Events.Services.Actions;
using Nimrod.Events.Services.Factories;
using Nimrod.Events.Services.Queries;
using Unity.WebApi;

namespace Nimrod.Events.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterInstance<IMapper>(Mapper.Instance);
            container.RegisterType<EventsDb, EventsDb>();

            container.RegisterType<IEventActionsFactory, EfEventActionsFactory>();
            container.RegisterType<IEventQueriesFactory, EfEventQueriesFactory>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}