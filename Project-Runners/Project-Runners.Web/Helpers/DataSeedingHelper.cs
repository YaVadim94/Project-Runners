using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project_runners.Common;
using Project_runners.Common.Enums;
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
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                SeedData(context);
                SeedByRunners(context);
            
                context.SaveChanges();
            }
        }

        private static void SeedByRunners(DataContext context)
        {
            if (context.Runners.Any())
                return;
            
            Console.WriteLine("--> Seeding by runners...");

            context.Runners.Add(new Runner {Id = 1, Name = "1", State = RunnerState.Waiting});
            context.Runners.Add(new Runner {Id = 2, Name = "2", State = RunnerState.Waiting});
            context.Runners.Add(new Runner {Id = 3, Name = "3", State = RunnerState.Waiting});
        }
        
        private static void SeedData(DataContext context)
        {
            if (!context.Runs.Any())
            {
                Console.WriteLine("--> Seeding by runs...");
                context.Runs.Add(new Run{Id = 1, Name = "SuperStar", Status = RunStatus.Successed});
                context.Runs.Add(new Run{Id = 2, Name = "Onion", Status = RunStatus.Failed});
                context.Runs.Add(new Run{Id = 3, Name = "Beautiful", Status = RunStatus.InProgress});
            }
            
            if (!context.Cases.Any())
            {
                Console.WriteLine("--> Seeding by cases...");
                
                context.Cases.Add(new Case{Id = 1, Name = "The Who"});
                context.Cases.Add(new Case{Id = 2, Name = "Guns N` Roses"});
                context.Cases.Add(new Case{Id = 3, Name = "Nirvana"});
                context.Cases.Add(new Case{Id = 4, Name = "Metallica"});
                context.Cases.Add(new Case{Id = 5, Name = "AC/DC"});
                context.Cases.Add(new Case{Id = 6, Name = "The Rolling Stones"});
                context.Cases.Add(new Case{Id = 7, Name = "The Rolling Stones_1"});
                context.Cases.Add(new Case{Id = 8, Name = "The Rolling Stone_2"});
                context.Cases.Add(new Case{Id = 9, Name = "The Rolling Stones_3"});
                context.Cases.Add(new Case{Id = 10, Name = "The Rolling Stones_4"});
                context.Cases.Add(new Case{Id = 11, Name = "The Rolling Stones_5"});
                context.Cases.Add(new Case{Id = 12, Name = "The Rolling Stones_6"});
                context.Cases.Add(new Case{Id = 13, Name = "The Rolling Stones_7"});
                context.Cases.Add(new Case{Id = 14, Name = "The Rolling Stones_8"});
                context.Cases.Add(new Case{Id = 15, Name = "The Rolling Stones_9"});
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
                
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 1});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 2});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 3});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 4});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 5});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 6});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 7});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 8});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 9});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 10});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 11});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 12});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 13});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 14});
                context.RunCases.Add(new RunCase{RunId = 3, CaseId = 15});
            }
        }
    }
}