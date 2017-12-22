using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;

namespace Agency.Commands.Creating
{
    // TODO
    public class CreateTicketCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public CreateTicketCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;
            

            try
            {
                journey = this.engine.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
  
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }
            //(IJourney journey, decimal administrativeCosts)
            var ticket = this.factory.CreateTicket(journey, administrativeCosts);
            this.engine.Tickets.Add(ticket);

            return $"Ticket with ID {engine.Journeys.Count - 1} was created.";
        }
    }
}
