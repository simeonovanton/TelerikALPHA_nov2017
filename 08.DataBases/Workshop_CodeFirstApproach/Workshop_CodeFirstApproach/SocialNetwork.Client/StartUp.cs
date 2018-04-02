using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Client
{
    class StartUp
    {
        static void Main()
        {
            var ctx = new SocialNetworkContext();

            ctx.Database.CreateIfNotExists();

            
        }
    }
}
