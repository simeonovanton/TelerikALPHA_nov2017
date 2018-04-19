using Newtonsoft.Json;
using System;

namespace JSONtests
{
    class Program
    {
        static void Main()
        {
            Product apple = new Product("Apple", 0.11M, new DateTime(2018,12,31), "Small");
            string outputJSON = JsonConvert.SerializeObject(apple);

            Console.WriteLine(outputJSON);

            // Product newObject = JsonConvert.DeserializeObject<Product>(outputJSON);
            Product newObject = JsonConvert.DeserializeObject<Product>(outputJSON);
            Console.WriteLine(newObject);
        }
    }
}
