using System;
namespace ConsoleApp1
{
    public class Dog : Mammal
    {
        public Dog(string name) : base(name)
        {

        }

        public void NewPrint()
        {

            base.Print();
        }

        public new void Print()
        {
            Console.WriteLine("I'm printing from DOG class");
        }
    }
}