using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core
{
    public class DataBase : IDataBase
    {
        private IList<IVehicle> vehicles;
        private IList<IJourney> journeys;
        private IList<ITicket> tickets;

        public DataBase()
        {
            this.vehicles = new List<IVehicle>();
            this.journeys = new List<IJourney>();
            this.tickets = new List<ITicket>();
        }
        public IList<IVehicle> Vehicles
        {
            get { return new List<IVehicle> (this.vehicles); }
        }

        public IList<IJourney> Journeys
        {
            get { return new List<IJourney>(this.journeys); }
        }

        public IList<ITicket> Tickets
        {
            get
            {
                return new List<ITicket>(this.tickets);
            }
        }

        public void AddJorney(IJourney journey)
        {
            //TODO Verify
            this.journeys.Add(journey);
        }

        public void AddTicket(ITicket ticket)
        {
            //TODO Verify
            this.tickets.Add(ticket);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            //TODO Verify
            this.vehicles.Add(vehicle);
        }
    }
}
