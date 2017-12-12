using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Text;

namespace Cosmetics.Products
{

    public abstract class Product : IProduct
    {
        //Each Shampoo has name, brand, price, gender, milliliters, usage. 
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;
        

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }
        public string Name
        {
            get
            { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Shampoo name is not in constraints!");
                }
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Shampoo name is not in constraints!");
                }
                this.name = value;
            }
        }
        public string Brand
        {
            get
            { return this.brand; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Shampoo brand name's is not in constraints!");
                }
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Shampoo brand name's is not in constraints!");
                }
                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Shampoo price can't be negative!");
                }
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return (GenderType)this.gender;
            }
            set
            {
                if ((int)value < 0 || ((int)value > 2))
                {
                    throw new ArgumentException("Genderyou enter is invalid!");
                }
                this.gender = value;
            }
        }

       

       

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"#{this.Name} {this.Brand}");
            sb.AppendLine($" #Price: {this.Price:F2}");
            sb.AppendLine($" #Gender: {this.Gender}");

            return sb.ToString();
        }
    }


}
