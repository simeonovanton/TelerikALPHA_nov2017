using OlympicGames.Core;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGames.IO;

namespace OlympicGames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine(
                CommandParser.Instance,
                CommandProcessor.Instance,
                OlympicCommittee.Instance,
                OlympicsFactory.Instance,
                new ConsoleReader(),
                new ConsoleWriter()
                );

            engine.Run();
        }
    }
}
