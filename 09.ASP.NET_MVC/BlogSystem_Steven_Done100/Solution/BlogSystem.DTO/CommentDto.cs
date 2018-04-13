using BlogSystem.Data.Models;
using BlogSystem.Infrastructure.Mapping;

namespace BlogSystem.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public string AuthorId { get; set; }

        public UserDto Author { get; set; }

        public int PostId { get; set; }
    }
}