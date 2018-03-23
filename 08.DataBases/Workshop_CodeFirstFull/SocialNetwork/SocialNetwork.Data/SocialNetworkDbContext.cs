using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SocialNetwork.Models;
using System.Data.Common;
using System.Reflection;
using SocialNetwork.Data.Configurations;
using System.Linq;
using System;
using SocialNetwork.Data.Configurations.Contracts;
using SocialNetwork.Data.Contracts;

namespace SocialNetwork.Data
{
    public class SocialNetworkDbContext : DbContext, ISocialNetworkDbContext
    {
        public SocialNetworkDbContext()
            : base("SocialNetwork")
        {
        }

        public SocialNetworkDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public virtual IDbSet<UserProfile> UserProfiles { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            this.RegisterConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterConfigurations(DbModelBuilder modelBuilder)
        {
            var type = typeof(IFluentConfiguration);

            var configs = Assembly.GetAssembly(type)
                .GetTypes()
                .Where(x => type.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

            foreach (var config in configs)
            {
                var instance = Activator.CreateInstance(config);
                (instance as IFluentConfiguration)?.Register(modelBuilder);
            }
        }
    }
}
