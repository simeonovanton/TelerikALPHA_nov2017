using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Encapsulation
{
    class Person
    {
        private string firstName;
        private string lastName;

        public Person(string firstName)
        {
            this.FirstName = firstName;
        }

        public Person(string firstName, string lastName)
            :this(firstName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "The name can't be null or empty!");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "The name can't be null or empty!");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"{this.FirstName} {this.LastName}");
        }

        class Program
        {
            static void Main()
            {
                Person p1 = new Person("Petar");
                p1.Print();
                p1.LastName = "Petrov";
                p1.Print();
                p1.FirstName = Console.ReadLine();
                p1.LastName = Console.ReadLine();
                p1.Print();
            }
        }
    }
}
