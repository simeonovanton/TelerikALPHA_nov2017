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
    public class InjectionConfigModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CommandParser>().As<ICommandParser>();
            //builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
            //builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>();
            //builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>();
            //builder.RegisterType<IOWrapper>().As<IIOWrapper>();
            //builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>();
            //builder.RegisterType<ConsoleReader>().As<IConsoleReader>();
            //builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
            .Where(t => t.Name.EndsWith("Engine"))
            .AsImplementedInterfaces();


        }
    }
}
