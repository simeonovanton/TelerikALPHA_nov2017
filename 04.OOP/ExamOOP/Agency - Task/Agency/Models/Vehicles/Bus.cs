using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    class Bus : Vehicle, IBus
    {
        public Bus(int passengerCapacity, decimal pricePerKilometer)
            : base(passengerCapacity, pricePerKilometer, VehicleType.Land)
        {

        }

        public override int PassangerCapacity
        {
            get { return base.PassangerCapacity; }
            set
            {
                if (value < 10 || value > 50)
                {
                    throw new ArgumentException("A bus cannot have less than 10 passengers or more than 50 passengers.");
                }

                base.PassangerCapacity = value;
            }
        }

        public override decimal PricePerKilometer
        {
            get { return base.PricePerKilometer; }
            set
            {
                base.PricePerKilometer = value;
            }
        }

        public override VehicleType Type => base.Type;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\nBus ----");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
