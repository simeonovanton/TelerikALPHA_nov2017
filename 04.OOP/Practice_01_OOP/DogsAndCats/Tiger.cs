using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAndCats
{
    class Tiger : Animal
    {
        public new void Walk()
        {
            Console.WriteLine($"Tiger is walking");
        }
    }
}
