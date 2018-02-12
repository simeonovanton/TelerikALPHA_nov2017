using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ICommand
    {
        private readonly IDataBase data;
        private readonly Constants constants;

        public ListVehiclesCommand(IDataBase data, Constants constants)
        {
            this.data = data;
            this.constants = constants;
        }
        public string Execute(IList<string> parameters)
        {
            var vehicles = this.data.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
