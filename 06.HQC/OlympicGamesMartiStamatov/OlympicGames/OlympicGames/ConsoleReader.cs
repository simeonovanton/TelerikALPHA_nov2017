using System;
using OlympicGames.Core.Providers;

namespace OlympicGames
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}