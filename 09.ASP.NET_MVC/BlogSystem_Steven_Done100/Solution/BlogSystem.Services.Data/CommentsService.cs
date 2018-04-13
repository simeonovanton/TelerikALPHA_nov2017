using BlogSystem.Data.Models;
using BlogSystem.Data.Repository;
using BlogSystem.Data.Saver;
using BlogSystem.DTO;
using BlogSystem.Infrastructure.Mapping;
using BlogSystem.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSystem.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Comment> comments;
        private readonly ISaver saver;

        public CommentsService(IMappingProvider mapper, IRepository<Comment> comments, ISaver saver)
        {
            this.mapper = mapper;
            this.comments = comments;
            this.saver = saver;
        }

        public IEnumerable<CommentDto> GetByPostId(int id)
        {
            var comments = this.comments.All
                .Include(x => x.Author)
                .Where(x => x.PostId == id);

            return this.mapper.ProjectTo<CommentDto>(comments);
        }

        public void Publish(CommentDto dto)
        {
            var model = this.mapper.MapTo<Comment>(dto);
            this.comments.Add(model);
            this.saver.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = this.comments.All.FirstOrDefault(x => x.Id == id);

            if (comment == null)
            {
                throw new ArgumentException("Comment with such ID is not found!");
            }

            this.comments.Delete(comment);
            this.saver.SaveChanges();
        }
    }
}
