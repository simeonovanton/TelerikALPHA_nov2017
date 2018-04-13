using BlogSystem.Data.Models;
using BlogSystem.Data.Models.Abstracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext<User>
    {
        public BlogSystemDbContext(DbContextOptions<BlogSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.Author)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Author)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Restrict);
            
            base.OnModelCreating(builder);
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable) entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
