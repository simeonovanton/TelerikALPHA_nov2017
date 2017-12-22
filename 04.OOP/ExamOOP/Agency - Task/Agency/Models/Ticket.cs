using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models
{
    class Ticket : ITicket
    {
        private readonly IJourney journey;
        private readonly decimal administrativeCosts;

        public Ticket(IJourney journey, decimal administrativeCosts)
        {
            this.administrativeCosts = administrativeCosts;
            this.journey = journey;
        }


        public decimal AdministrativeCosts => this.administrativeCosts;
       
        public IJourney Journey => this.journey;

        public decimal CalculatePrice()
        {
            return (decimal)(this.administrativeCosts + this.journey.CalculateTravelCosts());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Ticket ----");
            sb.AppendLine($"Destination: {this.journey.Destination}");
            sb.AppendLine($"Price: {this.CalculatePrice()}");

            return sb.ToString();
        }
    }
}
