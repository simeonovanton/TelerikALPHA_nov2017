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
                Guard.WhenArgument(value, "WeigtCapacity").IsLessThan(1).IsGreaterThan(100).Throw();
                this.weightCapacity = value;
            }
        }
    }
}
