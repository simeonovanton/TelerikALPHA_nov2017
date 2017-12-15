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
    public class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private string make;
        private string model;
        private int wheels;
        private decimal price;
        private VehicleType type;
        private IList<IComment> comments;

        // Each of the vehicles has make, model, wheels count and price.
        public Vehicle(VehicleType type, string make, string model, int wheels, decimal price)
        {
            this.Type = type;
            this.Make = make;
            this.Model = model;
            this.Wheels = wheels;
            this.Price = price;
        }

        public VehicleType Type { get; }

        public string Make
        {
            get { return this.make; }
            protected set
            {
                if (value.Length < 3 || value.Length > 15)
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
                if (value.Length < 3 || value.Length > 15)
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
                Guard.WhenArgument(value,"Price").IsGreaterThan(1000000).IsLessThan(0).Throw();
                this.price = value;
            }
        }

        public IList<IComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
