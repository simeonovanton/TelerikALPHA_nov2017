using BlogSystem.Data.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Data.Models
{
    public class Comment : DataModel
    {
        [Required]
        public string Content { get; set; }

        public int Likes { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public User Author { get; set; }

        public int PostId { get; set; }

        [Required]
        public Post Post { get; set; }
    }
}