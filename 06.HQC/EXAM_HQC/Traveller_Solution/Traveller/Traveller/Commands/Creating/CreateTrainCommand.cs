using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : ICommand
    {
        private readonly IDataBase data;
        private readonly ITravellerFactory factory;
        private readonly Constants constants;

        public CreateTrainCommand(IDataBase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            var train = this.factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            //Engine.Instance.Vehicles.Add(train);
            this.data.AddVehicle(train);

            return $"Vehicle with ID {this.data.Vehicles.Count - 1} was created.";
        }
    }
}
