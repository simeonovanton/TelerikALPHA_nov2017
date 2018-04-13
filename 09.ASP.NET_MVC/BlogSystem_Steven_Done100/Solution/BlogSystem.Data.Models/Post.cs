using BlogSystem.Data.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Data.Models
{
    public class Post : DataModel
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
