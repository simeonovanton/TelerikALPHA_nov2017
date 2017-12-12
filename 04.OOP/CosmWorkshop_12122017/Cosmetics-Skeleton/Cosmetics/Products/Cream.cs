using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Text;

namespace Cosmetics.Products
{

    public class Cream : Product, IProduct, ICream
    {
        //Class shampoo inherits class Product and extends fields milliliters and usage;
        //Cream (name, brand, price, gender, scent)


        private ScentType scent;

        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent)
            : base(name, brand, price, gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public ScentType Scent
        {
            get
            {
                return this.scent;
            }
            set
            {
                Guard.WhenArgument((int)value, "Scent").IsLessThan(0).IsGreaterThan(2)
                    .Throw();
                this.scent = value;
            }
        }

      

        public override string Print()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine($" #Scent: {this.Scent}");
            sb.AppendLine($" ===");


            return sb.ToString();
        }
    }


}
