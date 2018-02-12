using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Factories
{
    public interface IJourneyFactory
    {
        IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle);
    }
}
