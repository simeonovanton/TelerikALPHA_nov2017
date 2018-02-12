using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateJourneyCommand : ICommand
    {
        private readonly IDataBase data;
        private readonly ITravellerFactory factory;
        private readonly Constants constants;

        public CreateJourneyCommand(IDataBase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = this.data.Vehicles[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            var journey = this.factory.CreateJourney(startLocation, destination, distance, vehicle);
            //Engine.Instance.Journeys.Add(journey);
            this.data.Journeys.Add(journey);

            return $"Journey with ID {this.data.Journeys.Count - 1} was created.";
        }
    }
}
