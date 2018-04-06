using BlogSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext<User>
    {
        public BlogSystemDbContext(DbContextOptions<BlogSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
