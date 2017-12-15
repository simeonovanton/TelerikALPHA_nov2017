using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Rectangle : Shape
    {
        public override double CalculateSurface()
        {
            return width * height;
        }
    }
}
