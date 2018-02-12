using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        protected readonly IDataBase data;
        protected readonly ITravellerFactory factory;
        protected readonly Constants constants;

        public CreateTicketCommand(IDataBase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants;
        }
        public string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = this.data.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.factory.CreateTicket(journey, administrativeCosts);
            //Engine.Instance.Tickets.Add(ticket);
            this.data.Tickets.Add(ticket);

            return $"Ticket with ID {this.data.Tickets.Count - 1} was created.";
        }
    }
}
