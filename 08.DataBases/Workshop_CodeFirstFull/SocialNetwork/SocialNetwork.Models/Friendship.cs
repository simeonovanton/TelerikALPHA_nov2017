using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public int FirstUserId { get; set; }

        public virtual UserProfile FirstUser { get; set; }

        public int SecondUserId { get; set; }

        public virtual UserProfile SecondUser { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
