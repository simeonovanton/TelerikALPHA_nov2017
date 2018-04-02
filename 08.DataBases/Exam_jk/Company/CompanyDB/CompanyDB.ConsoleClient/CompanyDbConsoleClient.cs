namespace CompanyDB.ConsoleClient
{
    using System;
    using Models;

    class CompanyDbClient
    {
        static void Main()
        {
            Console.WriteLine("I use SQL Server 2012 Developer edition. Plese, adjust connection string if You use other version.\n\n\n");

            CompanyEntities dbContext = new CompanyEntities();
            dbContext.Configuration.AutoDetectChangesEnabled = false;

            CompanyDbFeeder feeder = new CompanyDbFeeder(dbContext);
            feeder.Feed();
            dbContext.Configuration.AutoDetectChangesEnabled = true;

            Console.WriteLine("Done.");
        }
    }
}
