using BlogSystem.Web.Models.PostViewModels;
using System.Collections.Generic;

namespace BlogSystem.Web.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
