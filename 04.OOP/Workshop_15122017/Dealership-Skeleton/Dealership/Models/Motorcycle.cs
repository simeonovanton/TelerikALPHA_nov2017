using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using Dealership.Contracts;
using Dealership.Common.Enums;


namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IVehicle, IMotorcycle
    {
        private string category;
        public Motorcycle(string make, string model, decimal price, string category)
            : base(VehicleType.Motorcycle, make, model, 2, price)
        {
            this.Category = category;
        }

        public string Category
        {
            get { return this.category; }
            protected set
            {
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Category must be between 3 and 10 characters long!");
                }
                //Guard.WhenArgument(value.Length, "Category").IsGreaterThan(10).IsLessThan(3).Throw();
                this.category = value;
            }
        }
    }

}
