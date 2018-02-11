using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using OlympicGames.Core.Contracts;
  
namespace OlympicGames.Core.Factories
{
    class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext container;

        public CommandFactory(IComponentContext container)
        {
            this.container = container;
        }
        public ICommand Create(string cmdName)
        {
            return this.container.ResolveNamed<ICommand>(cmdName);
        }
    }
}
