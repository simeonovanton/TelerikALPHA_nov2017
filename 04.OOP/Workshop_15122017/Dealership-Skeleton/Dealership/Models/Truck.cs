using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using Dealership.Contracts;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : Vehicle,IVehicle, ITruck
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(VehicleType.Truck, make, model, 8, price)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get { return this.weightCapacity; }
            protected set
            {
                if (weightCapacity < 1 || weightCapacity > 100)
                {
                    throw new ArgumentException("Weight capacity must be between 1 and 100!");
                }
                //Guard.WhenArgument(value, "WeigtCapacity").IsLessThan(1).IsGreaterThan(100).Throw();
                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"  Weight Capacity: {this.WeightCapacity}");
            return sb.ToString();
        }
    }
}
