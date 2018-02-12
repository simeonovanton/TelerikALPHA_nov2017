using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateAirplaneCommand : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IDataBase data;
        private readonly Constants constants;
            
        public CreateAirplaneCommand(IDataBase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants;
        }
        public string Execute(IList<string> parameters)
        {
            int passengerCapacity = int.Parse(parameters[0]);
            decimal pricePerKilometer = decimal.Parse(parameters[1]);
            bool hasFreeFood = bool.Parse(parameters[2]);

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = this.factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            //Engine.Instance.Vehicles.Add(airplane);
            this.data.AddVehicle(airplane);
            return $"Vehicle with ID {this.data.Vehicles.Count - 1} was created.";
        }
    }
}
