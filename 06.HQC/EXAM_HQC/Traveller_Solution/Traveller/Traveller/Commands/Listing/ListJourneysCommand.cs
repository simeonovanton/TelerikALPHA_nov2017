using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        private readonly IDataBase data;
        private readonly Constants constants;

        public ListJourneysCommand(IDataBase data, Constants constants)
        {
            this.data = data;
            this.constants = constants;
        }
        public string Execute(IList<string> parameters)
        {
            var journeys = this.data.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
