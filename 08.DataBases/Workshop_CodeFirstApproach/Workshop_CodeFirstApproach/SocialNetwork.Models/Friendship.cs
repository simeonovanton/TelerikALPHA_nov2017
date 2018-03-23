using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Friendship
    {
        public Friendship()
        {
            this.Messages = new HashSet<Message>();
        }
        public int FriendshipId { get; set; }
        //[Required]
        public UserProfile Sender { get; set; }
       // [Required]
        public UserProfile Reciever { get; set; }
        public string ApprovedStatus { get; set; }
        public DateTime FriendsSince { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
