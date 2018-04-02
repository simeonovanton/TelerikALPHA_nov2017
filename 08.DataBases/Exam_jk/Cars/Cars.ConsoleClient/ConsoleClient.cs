namespace Cars.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Newtonsoft.Json;

    using JsonModels;
    using Data;
    using Models;


    class ConsoleClient
    {
        private const string JSON_FOLDER = @"..\..\..\Data.Json.Files";
        private const string FILE_MASK = @"data.*.json";
        private const string QUERY_PATH = @"..\..\..\Queries.xml";

        static void Main()
        {
            Console.WriteLine("I use SQL Server 2012 Developer edition. Plese, adjust connection string if You use other version.\n\n\n");

            CarsContext dbContext = new CarsContext();

            string[] files = GetFileNames(JSON_FOLDER);
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            AddJsonDataToCarsDb(dbContext, files);
            dbContext.Configuration.AutoDetectChangesEnabled = true;

            ExecuteQuery(dbContext, QUERY_PATH);
        }

        private static string[] GetFileNames(string path)
        {
            string[] files = Directory.GetFiles(path, FILE_MASK);
            return files;
        }

        private static void AddJsonDataToCarsDb(CarsContext dbContext, string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                string jsonContent;
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    jsonContent = reader.ReadToEnd();
                }

                //Console.WriteLine(jsonContent);
                //Console.WriteLine();

                var jsonCars = JsonConvert.DeserializeObject<List<JsonCar>>(jsonContent);
                foreach (var car in jsonCars)
                {
                    Car currentCar = new Car
                    {
                        Model = car.Model,
                        Transmission = (Transmission)car.TransmissionType,
                        Year = car.Year,
                        Price = car.Price
                    };

                    string manufacturerName = car.ManufacturerName;
                    Manufacturer manufacturer = dbContext.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
                    if (manufacturer == null)
                    {
                        manufacturer = new Manufacturer
                        {
                            Name = manufacturerName
                        };

                        //dbContext.Manufacturers.Add(manufacturer);
                    }

                    currentCar.Manufacturer = manufacturer;

                    string cityName = car.Dealer.City;
                    City city = dbContext.Cities.FirstOrDefault(c => c.Name == cityName);
                    if (city == null)
                    {
                        city = new City
                        {
                            Name = cityName
                        };

                        //dbContext.Cities.Add(city);
                    }

                    string dealerName = car.Dealer.Name;
                    Dealer dealer = new Dealer
                    {
                        Name = dealerName
                    };

                    dealer.Cities.Add(city);
                    dbContext.Dealers.Add(dealer);
                    currentCar.Dealer = dealer;
                    dbContext.Cars.Add(currentCar);

                    dbContext.SaveChanges();
                }
            }

            dbContext.SaveChanges();
        }

        private static void ExecuteQuery(CarsContext dbContext, string xmlQueryPath)
        {
            XElement element = XElement.Load(xmlQueryPath);
            foreach (var query in element.Elements("Query"))
            {
                string outputFile = query.Attribute("OutputFileName").Value;
                string orderBy = query.Element("OrderBy").Value;
                
                // Console.WriteLine(orderBy);

                var carsMatching = dbContext.Cars.AsQueryable();
                string queryString;

                foreach (var whereCondition in query.Element("WhereClauses").Elements("WhereClause"))
                {
                    string propertyName = whereCondition.Attribute("PropertyName").Value;
                    string typeName = whereCondition.Attribute("Type").Value;
                    
                    // Console.WriteLine(propertyName + " " + typeName);
;
                    string condition = whereCondition.Value;
                    // Console.WriteLine(condition);


                }

            }
        }
    }
}