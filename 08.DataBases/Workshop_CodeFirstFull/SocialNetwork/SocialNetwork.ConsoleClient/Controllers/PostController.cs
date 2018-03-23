using AutoMapper;
using SocialNetwork.Logic.Contracts;
using SocialNetwork.Logic.Models;
using System;
using System.Collections.Generic;

namespace SocialNetwork.ConsoleClient.Controllers
{
    public class PostController
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            this.postService = postService;
            this.mapper = mapper;
        }

        public void CreatePost(string content, DateTime? created = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException();
            }

            var post = new PostModel
            {
                Content = content,
                PostedOn = created == null ? DateTime.Now : created.Value
            };

            this.postService.AddPost(post);
        }

        public IEnumerable<PostModel> GetAll()
        {
            var posts = this.postService.GetAllPosts();

            return posts;
        }
    }
}
