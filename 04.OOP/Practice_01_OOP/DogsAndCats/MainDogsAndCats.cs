using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAndCats
{
    class MainDogsAndCats
    {
        static void Main()
        {
            Cat katty = new Cat();
            Console.WriteLine($"Cat katty = new Cat();");
            katty.Walk();
            Console.WriteLine(new string('=', 20));
            Dog doggy = new Dog();
            Console.WriteLine($"Dog doggy = new Dog();");
            doggy.Walk();
            Console.WriteLine(new string('=', 20));
            Animal catAnimal = new Cat();
            Console.WriteLine($"Animal catAnimal = new Cat();");
            catAnimal.Walk();
            Console.WriteLine(new string('=', 20));
            Tiger tigaro = new Tiger();
            Console.WriteLine($"Tiger tigaro = new Tiger();");
            tigaro.Walk();
            Console.WriteLine(new string('=', 20));
            Animal animalTigaro = new Tiger();
            Console.WriteLine($"Animal animalTigaro = new Tiger();");
            animalTigaro.Walk();
            Console.WriteLine(new string('=', 20));

        }
    }
}
