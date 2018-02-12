using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Client.InjectionConfig;
using Traveller.Core;

namespace Traveller.Client
{
    class Traveller_StartUp
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new InjectionAutofacConfig());
            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
