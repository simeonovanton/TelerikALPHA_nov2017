using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Data.Migrations;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkContext : DbContext

    {
        public SocialNetworkContext()
            : base("name=SocialNetwork")
        {
            var strategy = new MigrateDatabaseToLatestVersion<SocialNetworkContext, Configuration>();
            Database.SetInitializer(strategy);
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasMany(x => x.Posts)
                .WithMany(p => p.TaggedUsers);

            modelBuilder.Entity<UserProfile>()
                .Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));
            //UserProfile
            modelBuilder.Entity<UserProfile>()
               .Property(p => p.FirstName)
               .HasMaxLength(50);

            modelBuilder.Entity<UserProfile>()
             .Property(p => p.LastName)
             .HasMaxLength(50);

            modelBuilder.Entity<UserProfile>()
                .Property(p => p.RegisteredOn)
                .IsRequired();
            //Post
            modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired();

            modelBuilder.Entity<Post>()
               .Property(p => p.PostedOn)
               .IsRequired();
            //Image
            modelBuilder.Entity<Image>()
               .Property(p => p.ImageUrl)
               .IsRequired();

            modelBuilder.Entity<Image>()
               .Property(p => p.FileExtension)
               .IsRequired()
               .HasMaxLength(4);
            //Message
            modelBuilder.Entity<Message>()
                .Property(m => m.Content)
                .IsRequired();

            modelBuilder.Entity<Message>()
              .Property(m => m.SeenOn)
              .IsRequired();

            modelBuilder.Entity<Message>()
              .Property(m => m.SeenOn)
              .IsOptional();
            //Friendship
            modelBuilder.Entity<Friendship>()
                .Property(f => f.FriendsSince)
                .IsOptional();

            base.OnModelCreating(modelBuilder);
        }
    }
}
