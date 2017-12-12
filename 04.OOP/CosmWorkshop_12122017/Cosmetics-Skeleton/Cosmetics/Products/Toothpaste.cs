using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients): base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                Guard.WhenArgument(value, "Ingredients").IsNull().Throw();
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine($" #Ingredients: {this.Ingredients}");

            return sb.ToString();
            
        }
    }
}