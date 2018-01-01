using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models
{
    class Journey : IJourney
    {
        private string startLocation;
        private string destination;
        private int distance;
        private IVehicle vehicle;


        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            this.StartLocation = startLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string Destination
        {
            get { return this.destination; }
            set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentException("The Destination's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.destination = value;
            }
        }
    
        public int Distance
        {
            get { return this.distance; }
            set
            {
                if (value< 5 || value > 5000)
                {
                    throw new ArgumentException("The Distance cannot be less than 5 or more than 5000 kilometers.");
                }
                this.distance= value;
            }
        }

        public string StartLocation
        {
            get { return this.startLocation; }
            set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentException("The StartingLocation's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.startLocation = value;
            }
        }

        public IVehicle Vehicle
        {
            get { return this.vehicle; }
            set { this.vehicle = value; }
        }

        public decimal CalculateTravelCosts()
        {
            return (decimal)(this.distance * this.vehicle.PricePerKilometer);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Journey ----");
            sb.AppendLine($"Start location: {this.startLocation}");
            sb.AppendLine($"Destination: {this.destination}");
            sb.AppendLine($"Distance: {this.distance}");
            sb.AppendLine($"Vehicle type: {this.vehicle.Type}");
            sb.Append($"Travel costs: {this.CalculateTravelCosts()}");

            return sb.ToString();
        }
    }
}
