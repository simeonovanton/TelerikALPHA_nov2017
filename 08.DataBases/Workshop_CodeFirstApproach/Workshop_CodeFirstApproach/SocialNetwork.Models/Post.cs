using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Post
    {
        public Post()
        {
            this.TaggedUsers = new HashSet<UserProfile>(); 
        }
        public int PostId { get; set; }
        [MinLength(10)]
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }

        public virtual ICollection<UserProfile> TaggedUsers  { get; set; }

    }
}
