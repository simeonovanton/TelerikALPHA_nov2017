using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            Creature cre = new Creature("CREATURE");
            Mammal mammal = new Mammal("Goshko");
            Dog doggy = new Dog("Doggy");

            doggy.Print();
 
        }
    }
}
