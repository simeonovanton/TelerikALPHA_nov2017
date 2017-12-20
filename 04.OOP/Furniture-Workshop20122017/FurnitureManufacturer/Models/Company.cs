using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FurnitureManufacturer.Models
{
    // Finish the class
    public class Company : ICompany
    {
        private readonly string name;
        private readonly string registrationNumber;
        private  ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            Guard.WhenArgument(name, "Company Name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Company Name").IsLessThan(5).Throw();
            this.name = name;

            if (!Regex.IsMatch(registrationNumber, "[0-9]{10}"))
            {
                throw new ArgumentException("Registration number is not valid");
            }
            this.registrationNumber = registrationNumber;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
        }

        public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
        }

        public string Catalog()
        {
            var strBuilder = new StringBuilder();
            // Finish it

            return strBuilder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            return null;
        }

        public void Remove(IFurniture furniture)
        {
        }
    }
}
