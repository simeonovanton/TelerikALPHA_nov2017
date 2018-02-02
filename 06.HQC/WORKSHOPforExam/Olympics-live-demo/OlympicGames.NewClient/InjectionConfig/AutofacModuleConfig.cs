using Autofac;
using OlympicGames.Core.Contracts;
using System.Reflection;

namespace OlympicGames.NewClient.InjectionConfig
{
    public class AutofacModuleConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                //.Where(x=>x.Namespace.Contains("Factories"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();
        }
    }
}
