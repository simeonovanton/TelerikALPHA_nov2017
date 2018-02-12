using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Models.Abstractions
{   
    public interface IDataBase
    {     
        IList<IVehicle> Vehicles { get; }

        IList<IJourney> Journeys { get; }

        IList<ITicket> Tickets { get; }


        void AddVehicle(IVehicle vehicle);

        void AddJorney(IJourney journey);

        void AddTicket(ITicket ticket);
    }
}
