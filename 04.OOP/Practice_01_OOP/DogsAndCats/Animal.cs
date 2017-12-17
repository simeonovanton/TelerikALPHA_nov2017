using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAndCats
{
    public class Animal
    {
        public string Name { get; set; }

        public virtual void Walk()
        {
            Console.WriteLine("Animal is walking");
        }
    }
}
