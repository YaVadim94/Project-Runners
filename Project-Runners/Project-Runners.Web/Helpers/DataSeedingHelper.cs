using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Data;
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
                
                context.Cases.Add(new Case{Id = 1, Name = "The Who"});
                context.Cases.Add(new Case{Id = 2, Name = "Guns N` Roses"});
                context.Cases.Add(new Case{Id = 3, Name = "Nirvana"});
                context.Cases.Add(new Case{Id = 4, Name = "Metallica"});
                context.Cases.Add(new Case{Id = 5, Name = "AC/DC"});
                context.Cases.Add(new Case{Id = 6, Name = "The Rolling Stones"});
            }

            if (!context.Runs.Any())
            {
                Console.WriteLine("--> Seeding by runs...");
                context.Runs.Add(new Run{Id = 1, Name = "SuperStar"});
                context.Runs.Add(new Run{Id = 2, Name = "Onion"});
            }

            if (!context.RunCases.Any())
            {
                Console.WriteLine("--> Seeding by runCases...");
                context.RunCases.Add(new RunCase{RunId = 1, CaseId = 1});
                context.RunCases.Add(new RunCase{RunId = 1, CaseId = 2});
                context.RunCases.Add(new RunCase{RunId = 1, CaseId = 3});
                context.RunCases.Add(new RunCase{RunId = 2, CaseId = 4});
                context.RunCases.Add(new RunCase{RunId = 2, CaseId = 5});
                context.RunCases.Add(new RunCase{RunId = 2, CaseId = 6});
            }
            
            context.SaveChanges();
        }
    }
}