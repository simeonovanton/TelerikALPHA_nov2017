using OlympicGames.Core;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var ioWrapper = new IOWrapper(writer, reader);

            var engine = new Engine(
                new CommandParser(),
                new CommandProcessor(),
                new OlympicCommittee(),
                new OlympicsFactory(),
                new IOWrapper(new ConsoleWriter(), new ConsoleReader())
                );

            engine.Run();
        }
    }
}
