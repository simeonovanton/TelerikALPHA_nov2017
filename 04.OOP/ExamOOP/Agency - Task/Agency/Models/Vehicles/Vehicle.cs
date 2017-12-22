using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    public class Vehicle : IVehicle
    {
        private int passengerCapacity;
        private decimal pricePerKilometer;
        private VehicleType type;

        public Vehicle(int passengerCapacity, decimal pricePerKilometer, VehicleType type)
        {
            this.PassangerCapacity = passengerCapacity;
            this.PricePerKilometer = pricePerKilometer;
            this.Type = type;
        }

        public virtual int PassangerCapacity
        {
            get { return this.passengerCapacity; }
            set
            {
                if (value < 1 || value > 800)
                {
                    throw new ArgumentException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
                }
                this.passengerCapacity = value;
            }
        }

        public virtual decimal PricePerKilometer
        {
            get { return this.pricePerKilometer; }
            set
            {
                if (value < 0.10m || value > 2.50m)
                {
                    throw new ArgumentException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");
                }
                this.pricePerKilometer = value;
            }
        }

        public virtual VehicleType Type
        { get { return this.type; }
          set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Passenger capacity: {this.passengerCapacity}");
            sb.AppendLine($"Price per kilometer: {this.pricePerKilometer}");
            sb.AppendLine($"Vehicle type: {this.type}");
            return sb.ToString();
        }
    }
}
