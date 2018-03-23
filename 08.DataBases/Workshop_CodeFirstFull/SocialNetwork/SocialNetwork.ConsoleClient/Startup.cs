using Autofac;
using SocialNetwork.Common;
using SocialNetwork.ConsoleClient.Controllers;
using SocialNetwork.Data;
using SocialNetwork.Data.Migrations;
using System;
using System.Data.Entity;
using System.Reflection;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Init();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            var controller = container.Resolve<PostController>();

            //controller.CreatePost("Added new post", DateTime.Now);
            var posts = controller.GetAll();

            foreach (var item in posts)
            {
                Console.WriteLine(item.ContentPlusDate);
            }
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
