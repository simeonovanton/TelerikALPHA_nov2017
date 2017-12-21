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
        private ICollection<IFurniture> furnitures;

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
            this.furnitures = new List<IFurniture>();
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
            this.furnitures.Add(furniture);
        }

//"{0} - {1} - {2} {3}",
//this.Name,
//this.RegistrationNumber,
//this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
//this.Furnitures.Count != 1 ? "furnitures" : "furniture"

        public string Catalog()
        {
            var strBuilder = new StringBuilder(); 
            strBuilder.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));
            List<IFurniture> orderedFurnitures = this.furnitures.OrderByDescending(x => x.Price).ThenByDescending(x => x.Model).ToList();
            foreach (var item in orderedFurnitures)
            {
                strBuilder.AppendLine(item.ToString());
            }
            return strBuilder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            foreach (var item in this.Furnitures)
            {
                if (item.Model == model)
                {
                    return item;
                }
            }
                return null;
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }
    }
}

