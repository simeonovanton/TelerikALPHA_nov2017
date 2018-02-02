using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
            builder.RegisterType<CommandParser>().As<ICommandParser>();
            builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>();
            builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>();
            builder.RegisterType<Engine>().As<IEngine>();

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Run();
        }
    }
}
