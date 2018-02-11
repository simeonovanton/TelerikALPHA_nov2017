using OlympicGames.Core.Providers;

namespace OlympicGames
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}