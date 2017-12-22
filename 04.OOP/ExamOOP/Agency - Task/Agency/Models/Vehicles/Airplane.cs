using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    class Airplane : Vehicle, IAirplane
    {
        private bool hasFreeFood = true;

        public Airplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood)
            :base(passengerCapacity, pricePerKilometer, VehicleType.Air)
        {
            this.HasFreeFood = hasFreeFood;
        }

        public override int PassangerCapacity
        {
            get { return base.PassangerCapacity; }
            set
            {
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

        public bool HasFreeFood
        {
            get { return this.hasFreeFood; }
            set
            {
                this.hasFreeFood = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\nAirplane ----");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Has free food: {this.hasFreeFood}");
            return sb.ToString();
        }
    }
}
