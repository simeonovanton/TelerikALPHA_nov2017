using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.NewClient
{
    class NewStartUp
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var engine = scope.Resolve<IEngine>();
                using (var scope1 = container.BeginLifetimeScope())
                {
                    var engine1 = scope1.Resolve<IEngine>(); ;
                    Console.WriteLine(engine == engine1);
                }
            }
            
            //var engine = container.Resolve<IEngine>();
            //var engine1 = container.Resolve<IEngine>();
            //Console.WriteLine(engine == engine1);
            //engine.Run();

            //  ICommandParser commandParser,
            //ICommandProcessor commandProcessor,
            //  IOlympicCommittee committee,
            //  IOlympicsFactory factory,
            //  IIOWrapper ioWrapper
        }
    }
}
