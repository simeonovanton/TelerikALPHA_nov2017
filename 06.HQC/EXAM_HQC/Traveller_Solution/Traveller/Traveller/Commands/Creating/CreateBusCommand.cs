using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
   
    public class CreateBusCommand : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IDataBase data;
        private readonly Constants constants;

        public CreateBusCommand(IDataBase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = this.factory.CreateBus(passengerCapacity, pricePerKilometer);
            //Engine.Instance.Vehicles.Add(bus);
            this.data.AddVehicle(bus);

            return $"Vehicle with ID {this.data.Vehicles.Count - 1} was created.";
        }
    }
}
