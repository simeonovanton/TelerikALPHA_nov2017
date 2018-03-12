using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace test2
{
    class JSON_Practice
    {
        static void Main()
        {
            var student = new Student()
            {
                FirstName = "Pesho",
                LastName = "Gosho",
            };
            student.Friend = new Student()
            {
                FirstName = "Pesho 2"
            };

            var jsonStudent = JsonConvert.SerializeObject(student, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });


            var json = File.ReadAllText("D:/TelerikAcademy/TelerikALPHA_nov2017/08.DataBases/XML&JSON/movies.json");

            var movies = JsonConvert.DeserializeObject<List<Movie>>(json);
        }
    }

    public class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

        [JsonProperty("cast")]
        public List<string> Actors { get; set; }

    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Student Friend { get; set; }
    }
}
