using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Triangle : Shape
    {
        public override double CalculateSurface()
        {
            return height * width / 2;
        }
    }
}
