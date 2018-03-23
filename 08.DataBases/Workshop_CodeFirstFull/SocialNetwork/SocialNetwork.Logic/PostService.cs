using AutoMapper;
using AutoMapper.QueryableExtensions;
using SocialNetwork.Data.Contracts;
using SocialNetwork.Logic.Contracts;
using SocialNetwork.Logic.Models;
using SocialNetwork.Models;
using System;
using System.Linq;

namespace SocialNetwork.Logic
{
    public class PostService : IPostService
    {
        private readonly ISocialNetworkDbContext dbContext;
        private readonly IMapper mapper;

        public PostService(ISocialNetworkDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddPost(PostModel post)
        {
            if(post == null)
            {
                throw new ArgumentException();
            }

            var postToAdd = this.mapper.Map<Post>(post);

            this.dbContext.Posts.Add(postToAdd);
            this.dbContext.SaveChanges();
        }

        public IQueryable<PostModel> GetAllPosts()
        {
            return this.dbContext.Posts.ProjectTo<PostModel>();
        }
    }
}
