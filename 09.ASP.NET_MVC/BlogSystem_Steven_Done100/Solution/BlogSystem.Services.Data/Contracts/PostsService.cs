using BlogSystem.Data.Models;
using BlogSystem.Data.Repository;
using BlogSystem.DTO;
using BlogSystem.Infrastructure.Mapping;
using BlogSystem.Services.Data.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;
using BlogSystem.Data.Saver;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly ISaver saver;
        private readonly IMappingProvider mapper;
        private readonly IRepository<Post> posts;
        private readonly IRepository<Comment> comments;

        public PostsService(ISaver saver, IMappingProvider mapper, IRepository<Post> posts, IRepository<Comment> comments)
        {
            this.saver = saver;
            this.mapper = mapper;
            this.posts = posts;
            this.comments = comments;
        }

        public PostDto GetById(int id)
        {
            var post = this.posts.All
                .Include(x => x.Author)
                .FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                throw new ArgumentException("Post with such ID is not found!");
            }

            return this.mapper.MapTo<PostDto>(post);
        }

        public IEnumerable<PostDto> GetLatestPosts(int count = 10)
        {
            var posts = this.posts.All
                .OrderBy(x => x.CreatedOn)
                .Take(count);

            return mapper.ProjectTo<PostDto>(posts);
        }

        public void Publish(PostDto dto)
        {
            var model = this.mapper.MapTo<Post>(dto);
            this.posts.Add(model);
            this.saver.SaveChanges();
        }

        public void Update(PostDto dto)
        {
            var post = this.posts.All
               .FirstOrDefault(x => x.Id == dto.Id);

            if (post == null)
            {
                throw new ArgumentException("Post with such ID is not found!");
            }

            post.Title = dto.Title;
            post.Content = dto.Content;

            this.posts.Update(post);
            this.saver.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = this.posts.All
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                throw new ArgumentException("Post with such ID is not found!");
            }

            this.posts.Delete(post);

            foreach (var comment in post.Comments)
            {
                this.comments.Delete(comment);
            }

            this.saver.SaveChanges();
        }
    }
}
