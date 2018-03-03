using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main()
        {
            var json = File.ReadAllText("D:/TelerikAcademy/TelerikALPHA_nov2017/08.DataBases/XML&JSON/movies.json");
        }
    }

    public class Movie
    {
        [JsonProperty("cast")]

        public int Actors { get; set; }

    }
}
