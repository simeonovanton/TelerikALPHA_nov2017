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
    public class FriendshipConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>()
                .HasRequired(x => x.FirstUser)
                .WithMany()
                .HasForeignKey(m => m.FirstUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Friendship>()
                .HasRequired(x => x.SecondUser)
                .WithMany()
                .HasForeignKey(m => m.SecondUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
