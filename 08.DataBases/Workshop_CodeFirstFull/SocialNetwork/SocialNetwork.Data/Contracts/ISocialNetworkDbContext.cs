using SocialNetwork.Models;
using System.Data.Entity;

namespace SocialNetwork.Data.Contracts
{
    public interface ISocialNetworkDbContext
    {
        IDbSet<UserProfile> UserProfiles { get; set; }

        IDbSet<Friendship> Friendships { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Post> Posts { get; set; }
        
        int SaveChanges();
    }
}