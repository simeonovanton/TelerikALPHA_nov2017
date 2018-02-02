using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : CreateOlympianCommand, ICommand
    {
        private readonly IDictionary<string, double> records;

        public CreateSprinterCommand(IList<string> commandLine, IOlympicCommittee comitee, IOlympicsFactory factory)
            : base(commandLine,  comitee,  factory)
        {
            this.records = new Dictionary<string, double>();

            foreach (var recordItem in this.CommandParameters)
            {
                var recordValue = recordItem.Split('/');
                this.records.Add(recordValue[0], double.Parse(recordValue[1]));
            }
        }

        protected override IOlympian CreatePerson()
        {
            return this.Factory.CreateSprinter(this.FirstName, this.LastName, this.Country, this.records);
        }
    }
}
