using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            this.Posts = new HashSet<Post>();
            this.Messages = new HashSet<Message>();
            this.Images = new HashSet<Image>();
        }
        public int UserProfileId { get; set; }
        [MinLength(4)]
        public string Username { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
