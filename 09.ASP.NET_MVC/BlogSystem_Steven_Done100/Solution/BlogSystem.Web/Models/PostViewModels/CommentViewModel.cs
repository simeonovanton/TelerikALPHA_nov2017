using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Web.Models.PostViewModels
{
    public class CommentViewModel
    {
        [Required]
        public string Content { get; set; }

        public int Likes { get; set; }
        
        public string Author { get; set; }
    }
}