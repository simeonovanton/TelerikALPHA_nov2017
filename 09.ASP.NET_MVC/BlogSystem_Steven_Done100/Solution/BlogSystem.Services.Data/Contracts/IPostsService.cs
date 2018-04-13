using BlogSystem.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BlogSystem.Services.Data.Contracts
{
    public interface IPostsService
    {
        IEnumerable<PostDto> GetLatestPosts(int count = 10);

        PostDto GetById(int id);

        void Publish(PostDto dto);

        void Update(PostDto dto);

        void Delete(int id);
    }
}
