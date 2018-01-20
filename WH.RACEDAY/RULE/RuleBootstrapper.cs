using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.DAL.REPOSITORIES;

namespace WH.RACEDAY.RULE
{
    public class RuleBootstrapper
    {
        public static void Bootstrap(Container container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            container.Register(typeof(ICommandHandler<>), new[] { Assembly.GetExecutingAssembly() });

            container.Register(typeof(IQueryHandler<,>), new[] { Assembly.GetExecutingAssembly() });


            Assembly repositoryAssembly = typeof(RaceRepository).Assembly;

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace == "WH.RACEDAY.DAL.REPOSITORIES"
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation);
            }

        }
    }
}
