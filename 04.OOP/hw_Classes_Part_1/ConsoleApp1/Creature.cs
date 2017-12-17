using System;
namespace ConsoleApp1
{
    public class Creature
    {
        private int gold = 100;
        public Creature(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        protected void Walk()
        {
            Console.WriteLine($"{this.Name} is Walking.......");
        }

        private void Talk()
        {
            Console.WriteLine("Talking........");
        }

        private static void SetCreatureClassFieldGold(int quantity)
        {

        }
    }
}