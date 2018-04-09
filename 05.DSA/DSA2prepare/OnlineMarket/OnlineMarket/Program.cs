using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket
{
    class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{this.Name}({this.Price})";
        }

        public int CompareTo(Product other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    result = this.Type.CompareTo(other.Type);
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            HashSet<string> listProducts = new HashSet<string>();
            Dictionary<string, SortedSet<Product>> productsByType = new Dictionary<string, SortedSet<Product>>();
            SortedSet<Product> productsByPrice = new SortedSet<Product>();
            string input = "";
            const string add = "add";
            const string end = "end";
            const string filter = "filter";
            const string type = "type";
            const string price = "price";
            const string from = "from";
            const string to = "to";
            string nameValue = "";
            double priceValue = 0;
            string typeValue = "";

            while (input != end)
            {
                input = Console.ReadLine();
                if (input == end)
                {
                    break;
                }
                string command = input.Substring(0, input.IndexOf(' '));
                switch (command)
                {
                    case add:
                        // Add structure ------
                        string[] inputAdd = input.Substring(command.Length + 1).Split(' ').ToArray();
                        nameValue = inputAdd[0];
                        priceValue = double.Parse(inputAdd[1]);
                        typeValue = inputAdd[2];
                        Product productToAdd = new Product(nameValue, priceValue, typeValue);
                        //Add to dict by KEY: Name and to HashSet
                        if (!listProducts.Contains(nameValue))
                        {
                            listProducts.Add(nameValue);// add to listProducts
                            if (!productsByType.ContainsKey(typeValue))
                            {
                                productsByType.Add(typeValue, new SortedSet<Product>());
                                productsByType[typeValue].Add(productToAdd);
                            }
                            if (productsByType[typeValue].Count < 10)
                            {
                                productsByType[typeValue].Add(productToAdd);
                            }
                            else
                            {
                                var lastInTypes = productsByType[typeValue].Last();
                                if (lastInTypes.CompareTo(productToAdd) > 0)
                                {
                                    productsByType[typeValue].Remove(lastInTypes);
                                    productsByType[typeValue].Add(productToAdd);
                                }
                            }
                            //add to typeDictionary
                          //------------------------------------
                            productsByPrice.Add(productToAdd);// add to priceSet

                            sb.AppendLine($"Ok: Product {nameValue} added successfully");
                        }
                        else
                        {
                            sb.AppendLine($"Error: Product {nameValue} already exists");
                        }
                        break;
                    case filter:
                        //Filter structure
                        string[] inputFilter = input.Substring(command.Length + 1).Split(' ').ToArray();
                        switch (inputFilter[1])
                        {
                            case type: // Fiter by type
                                string filterType = inputFilter[2];
                                
                                if (productsByType.ContainsKey(filterType))
                                {
                                    List<Product> outputType = new List<Product>();
                                    outputType = productsByType[filterType]
                                        .Take(10)
                                        .ToList();
                                    sb.AppendLine("Ok: " + string.Join(", ", outputType));
                                }
                                else
                                {
                                    sb.AppendLine($"Error: Type {filterType} does not exists");
                                }
                                break;
                            case price: //Filter by price
                                string[] priceCommand = input.Substring(input.IndexOf(price) + 6)
                                    .Split(' ').ToArray();
                                List<Product> outputPrice = new List<Product>();
                                if (priceCommand.Contains(from) && priceCommand.Contains(to))
                                {
                                    double fromPrice= double.Parse(priceCommand[1]);
                                    double toPrice = double.Parse(priceCommand[3]);
                                    outputPrice = productsByPrice
                                    .Where(x => x.Price >= fromPrice && x.Price <= toPrice)
                                    .Take(10)
                                    .ToList();
                                    if (outputPrice.Count != 0)
                                    {
                                        sb.AppendLine("Ok: " + string.Join(", ", outputPrice));
                                    }
                                    else
                                    {
                                        sb.AppendLine($"Ok: ");
                                    }
                                }
                                else if (priceCommand.Contains(from) && !priceCommand.Contains(to))
                                {
                                    double fromPrice = double.Parse(priceCommand[1]);
                                    outputPrice = productsByPrice
                                    .Where(x => x.Price >= fromPrice)
                                    .Take(10)
                                    .ToList();
                                    if (outputPrice.Count != 0)
                                    {
                                        sb.AppendLine("Ok: " + string.Join(", ", outputPrice));
                                    }
                                    else
                                    {
                                        sb.AppendLine($"Ok: ");
                                    }
                                }
                                else if (!priceCommand.Contains(from) && priceCommand.Contains(to))
                                {
                                    double toPrice = double.Parse(priceCommand[1]);
                                    outputPrice = productsByPrice
                                    .Where(x => x.Price <= toPrice)
                                    .Take(10)
                                    .ToList();
                                    if (outputPrice.Count != 0)
                                    {
                                        sb.AppendLine("Ok: " + string.Join(", ", outputPrice));
                                    }
                                    else
                                    {
                                        sb.AppendLine($"Ok: ");
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
