using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ICommand
    {
        private readonly IDataBase data;
        private readonly Constants constants;

        public ListTicketsCommand(IDataBase data, Constants constants)
        {
            this.data = data;
            this.constants = constants;
        }
        public string Execute(IList<string> parameters)
        {
            var tickets = this.data.Tickets;

            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
