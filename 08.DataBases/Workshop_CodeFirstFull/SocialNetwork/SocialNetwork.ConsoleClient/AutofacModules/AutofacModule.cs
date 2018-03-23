using Autofac;
using AutoMapper;
using SocialNetwork.ConsoleClient.Controllers;
using SocialNetwork.Data;
using SocialNetwork.Data.Contracts;
using SocialNetwork.Logic;
using SocialNetwork.Logic.Contracts;

namespace SocialNetwork.ConsoleClient.AutofacModules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SocialNetworkDbContext>().As<ISocialNetworkDbContext>().InstancePerDependency();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerDependency();
            builder.RegisterType<PostController>().AsSelf().InstancePerDependency();
            builder.Register(x => Mapper.Instance);
        }
    }
}
