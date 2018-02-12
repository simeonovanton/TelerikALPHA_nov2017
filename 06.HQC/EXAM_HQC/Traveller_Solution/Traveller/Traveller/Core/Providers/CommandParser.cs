using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Core.Providers
{
   
    public class CommandParser
    {
        protected readonly IComponentContext container;

        public CommandParser(IComponentContext container)
        {
            this.container = container;
        }
        public ICommand ParseCommand(string fullCommand)
        {
            var command = container.Resolve<ICommand>();
            return command;
        }
    }
}
