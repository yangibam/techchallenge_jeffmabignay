using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.RULE;
using WH.RACEDAY.WEB.Providers;

namespace WH.RACEDAY.WEB.App_Start
{
    public class SimpleInjectorConfig
    {
        public static Container RegisterSimpleInjector()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RuleBootstrapper.Bootstrap(container);

            container.RegisterSingleton<IQueryProcessor, DynamicQueryProcessor>();
            container.RegisterSingleton<ICommandProcessor, DynamicCommandProcessor>();
            //container.Register<ILogger, NLogLogger>(Lifestyle.Singleton);


            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }
    }
}