using AutoMapper;
using BlogSystem.DTO;
using BlogSystem.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Web.Models.PostViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Content { get; set; }

        public string Author { get; set; }
    }
}
