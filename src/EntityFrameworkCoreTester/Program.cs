
using System;
using System.IO;
using System.Linq;
using Bogus;
using EntityFrameworkCoreTester.DatabaseContext;
using EntityFrameworkCoreTester.DataInitializer;
using EntityFrameworkCoreTester.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCoreTester
{  
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static IConfigurationRoot Config;
        static void Main(string[] args)
        {
            RegisterServices();

            var result = PayeCalculator.SimpleTaxMonthly(300000);
            Console.WriteLine($"Result is =  {result}");
            DataSetPlayground();
           
            DisposeServices();
            Console.WriteLine("Done Seeding Program Table");
            Console.ReadKey();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: false);

            Config = builder.Build();

            collection.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(Config.GetConnectionString("Default")));

            collection.AddScoped<IDatabaseSeeder, DatabaseSeeder>(); 
            _serviceProvider = collection.BuildServiceProvider();
        }


        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
        /// <summary>
        /// Seed 1000 records with Bogus Data Faker Generator
        /// </summary>
        private static void DataSeeder()
        {
            Randomizer.Seed = new Random(1338);
            var programs = Enumerable.Range(1, 1000)
                .Select(FakeDataGenerator.ProgramFaker)
                .ToList();
            var dataSeederService = _serviceProvider.GetService<IDatabaseSeeder>();
            dataSeederService.SeedProgram(programs);
        }

        private static void DataSetPlayground()
        {

            var dbContext = _serviceProvider.GetService<ApplicationDbContext>();

            //Get DataGroup By 

            var dataset = (from p in dbContext.Programs 
                where p.CreationTime >= DateTime.Today
                      && p.CreationTime < DateTime.Now.AddDays(1) 
                           select new{
                               p.Name,
                               p.CreationTime,
                               p.Description
                               }).GroupBy(x => x.CreationTime.AddDays(-1).Hour).Select(e => new
              {
               key = e.Key,
               Name = e.Count()
            }).ToList();

//            var entities = await Table.AsNoTracking()
//                .Include(x => x.ExpenseItemType)
//                .Where(x => x.BusinessIdentityNumber == businessIdentityNumber && x.CreationTime.Month == DateTime.Now.Month)
//                .Select(x => new {
//                    ExpenseGroupName = x.ExpenseItemType.ExpenseGroupName,
//                    TotalCost = x.TotalCost
//                })
//                .GroupBy(x => x.ExpenseGroupName).Select(x => new ExpenseItemPercentageDto()
//                {
//                    ExpenseGroupName = x.Key,
//                    TotalCost = x.Count()
//                }).ToListAsync();

            //            var dataset = dbContext.Programs
            //                .FromSqlInterpolated($"SELECT * CreationTime from dbo.Programs WHERE CreationTime >= {DateTime.Today} AND CreationTime < {DateTime.Now.AddDays(1)} GROUP BY CreationTime").ToList();
            dataset.ForEach(d =>
            {
                Console.WriteLine(d.Name);
            });
        }
    }
}
