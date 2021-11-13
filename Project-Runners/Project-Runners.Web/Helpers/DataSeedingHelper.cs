using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Data.Models;

namespace Project_Runners.Web.Helpers
{
    /// <summary>
    /// Класс для сидирования БД
    /// </summary>
    public static class DataSeedingHelper
    {
        public static void SeedDataBase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
        }

        private static void SeedData(DataContext context)
        {
            if (!context.Cases.Any())
            {
                Console.WriteLine("--> Seeding by cases...");
                
                context.Cases.Add(new Case{Id = 1});
                context.Cases.Add(new Case{Id = 2});
                context.Cases.Add(new Case{Id = 3});
            }

            if (!context.Runs.Any())
            {
                Console.WriteLine("--> Seeding by runs...");
                context.Runs.Add(new Run{Id = 1});
                context.Runs.Add(new Run{Id = 2});
                context.Runs.Add(new Run{Id = 3});
            }

            context.SaveChanges();
        }
    }
}