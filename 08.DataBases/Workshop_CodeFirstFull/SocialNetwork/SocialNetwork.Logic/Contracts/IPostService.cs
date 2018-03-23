using SocialNetwork.Logic.Models;
using System.Linq;

namespace SocialNetwork.Logic.Contracts
{
    public interface IPostService
    {
        IQueryable<PostModel> GetAllPosts();

        void AddPost(PostModel post);
    }
}