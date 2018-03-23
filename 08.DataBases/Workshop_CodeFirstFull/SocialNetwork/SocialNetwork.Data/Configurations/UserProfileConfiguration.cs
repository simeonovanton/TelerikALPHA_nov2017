using SocialNetwork.Data.Configurations.Contracts;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Configurations
{
    public class UserProfileConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasMany(x => x.Posts).WithMany(x => x.TaggedUsers);
        }
    }
}
