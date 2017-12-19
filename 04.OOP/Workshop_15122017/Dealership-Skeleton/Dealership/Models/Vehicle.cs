using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private string make;
        private string model;
        private int wheels;
        private decimal price;
        private VehicleType type;
        private IList<IComment> comments;
        private const string NoCommentsHeader = " --NO COMMENTS--";
        private const string CommentsHeader = "--COMMENTS--";

        // Each of the vehicles has make, model, wheels count and price.
        public Vehicle(VehicleType type, string make, string model, int wheels, decimal price)
        {
            this.Type = type;
            this.Make = make;
            this.Model = model;
            this.Wheels = wheels;
            this.Price = price;
            this.Comments = new List<IComment>();
        }

        public VehicleType Type { get; }

        public string Make
        {
            get { return this.make; }
            protected set
            {
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException("Make must be between 2 and 15 characters long!");
                }
                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            protected set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Model must be between 2 and 15 characters long!");
                }
                this.model = value;
            }
        }

        public int Wheels
        {
            get { return this.wheels; }
            protected set { this.wheels = value; }
        }
      
        public decimal Price
        {
            get { return this.price; }
            protected set
            {
                if (value < 0 || value > 1000000)
                {
                    throw new ArgumentException("Price must be between 0.0 and 1000000.0!");
                }
                this.price = value;
            }
        }

        public IList<IComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"  Make: {this.Make}");
            sb.AppendLine($"  Model: {this.Model}");
            sb.AppendLine($"  Wheels: {this.Wheels}");
            sb.AppendLine($"  Price: {this.Price}");
            sb.AppendLine(this.PrintAdditionalInfo());
            sb.AppendLine(this.PrintComments());
            return sb.ToString();
        }

        protected abstract string PrintAdditionalInfo();

        private string PrintComments()
        {
            var builder = new StringBuilder();

            if (this.Comments.Count <= 0)
            {
                builder.AppendLine(string.Format("{0}", NoCommentsHeader));
            }
            else
            {
                builder.AppendLine(string.Format("{0}", CommentsHeader));

                foreach (var comment in this.Comments)
                {
                    builder.AppendLine(comment.ToString());
                }

                builder.AppendLine(string.Format("{0}", CommentsHeader));
            }

            return builder.ToString().TrimEnd();
        }
    }

    
}
