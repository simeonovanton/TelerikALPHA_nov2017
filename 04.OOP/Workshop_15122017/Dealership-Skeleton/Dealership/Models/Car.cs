using Dealership.Contracts;
using Dealership.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, IVehicle, ICar
    {
        private int seats;
        public Car(string make, string model, decimal price, int seats)
            : base(VehicleType.Car, make, model, 4, price)
        {
            this.Seats = seats;
        }

        public int Seats
        {

            get => this.seats;
            private set
            {
                Guard.WhenArgument(value, "Value").IsLessThan(0).IsGreaterThan(10).Throw();
                this.seats = value;
            }
        }
    }

  

}
