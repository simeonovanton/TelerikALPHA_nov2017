using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.Configuration;
using OlympicGames.Core;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGames.Core.Commands.Decorators;

namespace OlympicGames.NewClient
{
    public class InjectionConfigModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        //    builder.RegisterType<CommandParser>().As<ICommandParser>();
        //    builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
        //    builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>();
        //    builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>();
        //    builder.RegisterType<IOWrapper>().As<IIOWrapper>();
        //    builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>();
        //    builder.RegisterType<ConsoleReader>().As<IConsoleReader>();
        //    builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
            //.Where(x => x.Namespace.Contains("Factories") || x.Namespace.Contains("Providers") || x.Name.EndsWith("Engine"))
            .AsImplementedInterfaces().SingleInstance();

        var isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            if (isTest)
            {
                builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("internalList");
                builder.RegisterType<LoggerListCommand>().Named<ICommand>("listolympians")
                    .WithParameter((pi, ctx) => pi.Name == "command", 
                    (pi, ctx) => ctx.ResolveNamed<ICommand>("internalList"));
            }
            else
            {
                builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("listolympians");
            }

            builder.RegisterType<CreateBoxerCommand>().Named<ICommand>("createboxer");

            //builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();



        }
    }
}
