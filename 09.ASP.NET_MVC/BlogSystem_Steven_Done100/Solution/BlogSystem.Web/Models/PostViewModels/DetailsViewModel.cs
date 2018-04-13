using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Web.Models.PostViewModels
{
    public class DetailsViewModel
    {
        public PostViewModel Post { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
