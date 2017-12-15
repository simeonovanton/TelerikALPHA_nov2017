using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Comment: IComment
    {
        private string content;
        private string author;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get { return this.content; }
            set
            {
                Guard.WhenArgument(value, "CommetnContetnt").IsNull().IsEmpty().Throw();
                this.content = value;
            }
        }
        public string Username { get; set; }
    }
}
