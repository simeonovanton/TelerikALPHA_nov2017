using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba_2
{

    public class Person
    {
        private string name;
        private int age;


        public Person(string name)
        {
            this.name = name;
        }

        public Person(string name, int age)
            : this(name)
        {
            this.age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public void PrintName()
        {
            Console.WriteLine($"Person's name is: {this.name}");
        }

        public void PrintAge()
        {
            Console.WriteLine($"Person's age is:{this.age}");
        }
    }
    public class Program
    {

            public static void Main()
            {
                Person Goshko = new Person("Goshko", 14);
                Person Mitko = new Person("Mitko", 15);

                Goshko.PrintName();
                Goshko.PrintAge();
                Console.WriteLine("==================");
                Mitko.PrintName();
                Mitko.PrintAge();

            Goshko.Name = "Gerganka";
            Goshko.Age = 25;
            Mitko.Name = "Ivanka";
            Mitko.Age = 37;

            Console.WriteLine();

            Goshko.PrintName();
            Goshko.PrintAge();
            Console.WriteLine("==================");
            Mitko.PrintName();
            Mitko.PrintAge();
        }
        
    }
}
