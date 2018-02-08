using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        private readonly IOlympicCommittee committee;
        private readonly IOlympicsFactory factory;

        public Command(IOlympicCommittee committee, IOlympicsFactory factory, IList<string> commandLine)
        {
            this.committee = committee;
            this.factory = factory;
            this.CommandParameters = commandLine;
        }

        public IList<string> CommandParameters { get; protected set; }

        public OlympicCommittee Committee { get; }

        public IOlympicsFactory Factory { get; }

        public abstract string Execute();
    }
}
