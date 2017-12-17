using System;
namespace ConsoleApp1
{
    public class Mammal : Creature
    {
        public Mammal(string name) : base(name)
        {

        }

        protected virtual void Print()
        {
            Console.WriteLine($"{this.Name} Print's...trought the Mammal class");
        }

        //protected void AnotherPrint()
        //{
        //    this.Print();
        //}

    }
}