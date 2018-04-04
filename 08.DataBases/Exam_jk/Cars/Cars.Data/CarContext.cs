namespace Cars.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models;
    using Migrations;

    public class CarsContext : DbContext
    {
        public CarsContext()
            : base("name=CarsDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<City> Cities { get; set; }
    }
}