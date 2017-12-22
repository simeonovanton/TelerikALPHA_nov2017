using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    class Train : Vehicle, ITrain
    {
        private int carts;

        public Train(int passengerCapacity, decimal pricePerKilometer, int carts)
            : base(passengerCapacity, pricePerKilometer, VehicleType.Land)
        {
            this.Carts = carts;
        }

        public override int PassangerCapacity
        {
            get { return base.PassangerCapacity; }
            set
            {
                if (value < 30 || value > 150)
                {
                    throw new ArgumentException("A train cannot have less than 30 passengers or more than 150 passengers.");
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

        public int Carts
        {
            get { return this.carts; }
            set
            {
                if (value <= 1 || value >= 15)
                {
                    throw new ArgumentException("A train cannot have less than 1 cart or more than 15 carts.");
                }
                this.carts = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\nTrain ----");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Carts amount: {this.carts}");
            return sb.ToString();
        }

    }
}
