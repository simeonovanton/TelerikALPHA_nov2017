using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public abstract class Shape
    {
        private long width;
        private long height;

        public Shape(long width, long height)
        {
            this.width = width;
            this.height = height;
        }


        public abstract double CalculateSurface();

    }
}


