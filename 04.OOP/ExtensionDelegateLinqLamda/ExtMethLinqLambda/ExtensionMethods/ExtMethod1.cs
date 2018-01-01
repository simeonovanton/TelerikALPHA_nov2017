using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class Extensions
    {
        
        public static void IncreaseWith(this IList<int> list, int amount)
        {
            // anonymous type
            var mycar = new { Color = "Red", Brand = "Tesla", TopSpeed = 270 };

            for (int i = 0; i < list.Count; i++)
            {
                list[i] += amount;
            }
            Console.WriteLine("================");
            Console.WriteLine($"My car is {mycar.Color} {mycar.Brand} and has MaxSpeed of {mycar.TopSpeed}km/h.");
        }
    }
}
