
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashAndDictionary
{

    public class City
    {
        public City(string city, int population, string country)
        {
            this.Name = city;
            this.Pupulation = population;
            this.Country = country;
        }
        public string Name { get; set; }
        public int Pupulation { get; set; }
        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is City)
            {
                var city = obj as City;

                return this.Name.Equals(city.Name);

            }
            return false;
        }

    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, City> city = new Dictionary<string, City>();

            //city.Add("Sofia", 3);
            //city.Add("Plovdiv", 5);
            //city.Add("Varna", 7);
            //city.Add("Pazardjik", 7);
            //city.Add("Kyustndil", 2);
            //city.Add("Pernik", 6);

            //Console.WriteLine(city["Sofia"]);
            //Console.WriteLine("Sofia".GetHashCode());
            //Console.WriteLine(city["Pazardjik"].GetHashCode());

            City Sofia = new City("Sofia", 2000000, "Bulgaria");
            City Plovdiv = new City("Plovdiv", 1000000, "Bulgaria");
            City Varna = new City("Varna", 500000, "Bulgaria");
            City Pazardjik = new City("Pazardjik", 40000, "Bulgaria");
            City Kyustendil = new City("Kyustendil", 50000, "Bulgaria");
            City Pernik = new City("Pernik", 100000, "Bulgaria");


            city.Add(Sofia.Name, Sofia);
            city.Add(Plovdiv.Name, Plovdiv);
            city.Add(Varna.Name, Varna);
            city.Add(Pazardjik.Name, Pazardjik);
            city.Add(Kyustendil.Name, Kyustendil);
            city.Add(Pernik.Name, Pernik);

            var keys = city.Keys;
            foreach (var item in keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in city)
            {
                Console.WriteLine(item.Key + " " + item.Value.Pupulation);
            }
        }
    }
}
