using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Cart
{
    public class ShoppingCart
    {
        private readonly ICollection<Product> productList;

        public ShoppingCart()
        {
            this.productList = new List<Product>();
        }

        public ICollection<Product> ProductList
        {
            get { return this.productList; }
        }

        public void AddProduct(Product product)
        {
            Guard.WhenArgument(product, "Invalid Product!");
            productList.Add(product);
            
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool ContainsProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public decimal TotalPrice()
        {
            var sum = 0;
            foreach (var item in this.productList)
            {
                sum += this.item.Price;
            }
            // or
            // var priceTotal = this.productList.Sum(x => x.Price);
            //return priceTotal;
        }
    }
}
