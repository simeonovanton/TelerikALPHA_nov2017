using Autofac;
using OlympicGames.Core.Contracts;
using System.Reflection;

namespace OlympicGames.NewClient
{
    public class StartUp
    {
        static void Main()
        {
            // Engine resolve using Autofac
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();
            engine.Run();

            //// Using scopes
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var engine = scope.Resolve<IEngine>();
            //    using (var scope1 = container.BeginLifetimeScope())
            //    {
            //        var engine1 = scope1.Resolve<IEngine>();

            //        Console.WriteLine(engine == engine1);
            //    }
            //}

            //// Parser using Ninject
            //var kernel = new StandardKernel(new NinjectModuleConfig());

            //var parser = kernel.Get<ICommandParser>();

            //// Parser using Autofac
            //var builder = new ContainerBuilder();
            //builder.RegisterModule(new AutofacModuleConfig());

            //var container = builder.Build();

            //var parserAutofac = container.Resolve<ICommandParser>();

            //Console.WriteLine(parser == parserAutofac);
        }
    }
}
