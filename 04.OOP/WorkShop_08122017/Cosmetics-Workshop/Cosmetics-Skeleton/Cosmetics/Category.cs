using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    public class Category
    {
        private readonly string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            Guard.WhenArgument(name.Length, "category name not correct!").IsGreaterThan(15).IsLessThan(2).Throw();
            this.name = name;
        }

        public List<Product> Products
        {
            get
            {
    
                    throw new NotImplementedException(); // TODO
            }
        }

        public virtual void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public virtual void RemoveProduct(Product product)
        {
            Guard.WhenArgument(product, "Null such product!").IsNull().Throw();
            if (!this.products.Any(x => x.Name == product.Name))
            {
                throw new ArgumentException("No such product!");
            }
           this. products.Remove(product);
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();

            foreach (var product in this.products)
            {
                strBuilder.AppendLine(product.Print());
            }

            throw new NotImplementedException();
        }
    }
}
