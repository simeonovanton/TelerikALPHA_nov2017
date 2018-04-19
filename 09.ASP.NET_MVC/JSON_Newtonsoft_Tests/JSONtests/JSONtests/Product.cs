using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtests
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string name, decimal price, DateTime expiresAt, string size)
        {
            this.Price = price;
            this.ExpiresAt = expiresAt;
            this.Size = size;
            this.Name = name;
        }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "ExpiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty(PropertyName = "Size")]
        public string Size { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Price: {this.Price}");
            sb.AppendLine($"ExpiresAt: {this.ExpiresAt}");
            sb.AppendLine($"Size: {this.Size}");

            return sb.ToString();
        }
    }
}
