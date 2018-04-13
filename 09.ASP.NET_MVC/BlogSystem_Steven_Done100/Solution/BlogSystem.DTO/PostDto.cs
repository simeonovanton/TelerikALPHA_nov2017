using BlogSystem.Data.Models;
using BlogSystem.Infrastructure.Mapping;
using System.Collections.Generic;

namespace BlogSystem.DTO
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public UserDto Author { get; set; }

        public ICollection<CommentDto> Comments { get; set; }
    }
}
