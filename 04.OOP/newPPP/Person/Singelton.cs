using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Singelton

    {
        private static Singelton instance;
        private Singelton()
        {

        }

        public static  Singelton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singelton();
                }
                return instance;
            }
        }
    }

    
}
