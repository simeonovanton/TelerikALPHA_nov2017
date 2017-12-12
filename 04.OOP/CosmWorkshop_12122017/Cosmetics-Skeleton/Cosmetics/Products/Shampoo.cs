using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Text;

namespace Cosmetics.Products
{
   
    public class Shampoo : Product, IProduct, IShampoo
    {
        //Class shampoo inherits class Product and extends fields milliliters and usage;
        //Each Shampoo has name, brand, price, gender, milliliters, usage. 
        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters,
                        UsageType usage) : base(name, brand, price, gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            set
            {
                Guard.WhenArgument((int)value, "Milliliters").IsLessThan(0).Throw();
                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            set
            {
                Guard.WhenArgument((int)value, "UsageType").IsLessThan(0).IsGreaterThan(1).Throw();
                this.usage = value;
            }
        }

        public override string Print()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine($" #Milliliters: {this.Milliliters}");
            sb.AppendLine($" #Usage: {this.Usage}");
            sb.AppendLine($" ===");


            return sb.ToString();
        }
    }

   
}
