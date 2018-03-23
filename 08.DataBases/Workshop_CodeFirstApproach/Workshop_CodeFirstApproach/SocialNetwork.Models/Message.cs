using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        [Required]
        public  UserProfile Author { get; set; }
        public string Content { get; set; }
        public DateTime SentOn { get; set; }    
        public DateTime SeenOn { get; set; }
    }
}
