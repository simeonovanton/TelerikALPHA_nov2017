using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Factories
{
    public class JourneyFactory : IJourneyFactory
    {
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            return new Journey( startLocation,  destination,  distance,  vehicle);
        }
    }
}
