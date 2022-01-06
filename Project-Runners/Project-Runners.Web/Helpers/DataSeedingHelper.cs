using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Common.Enums;
using ProjectRunners.Data;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Web.Helpers
{
    /// <summary>
    /// Класс для сидирования БД
    /// </summary>
    public static class DataSeedingHelper
    {
        public static void SeedDataBase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
            SeedData(context);
            SeedByRunners(context);

            context.SaveChanges();
        }

        private static void SeedByRunners(DataContext context)
        {
            if (context.Runners.Any())
                return;

            Console.WriteLine("--> Seeding by runners...");

            context.Runners.Add(new Runner
                {Id = 1, Name = "1", State = RunnerState.Disconnected, ChangeDate = DateTimeOffset.Now});
            context.Runners.Add(new Runner
                {Id = 2, Name = "2", State = RunnerState.Disconnected, ChangeDate = DateTimeOffset.Now});
            context.Runners.Add(new Runner
                {Id = 3, Name = "3", State = RunnerState.Disconnected, ChangeDate = DateTimeOffset.Now});
        }

        private static void SeedData(DataContext context)
        {
            if (!context.Runs.Any())
            {
                Console.WriteLine("--> Seeding by runs...");
                context.Runs.Add(new Run {Id = 1, Name = "SuperStar", Status = RunStatus.Successed});
                context.Runs.Add(new Run {Id = 2, Name = "Onion", Status = RunStatus.Failed});
                context.Runs.Add(new Run {Id = 3, Name = "Beautiful", Status = RunStatus.InProgress});
            }

            if (!context.Cases.Any())
            {
                Console.WriteLine("--> Seeding by cases...");

                context.Cases.Add(new Case {Id = 1, Name = "AC/DC", Description = "австралийская рок-группа, сформированная в Сиднее в ноябре 1973 года выходцами из Шотландии, братьями Малькольмом и Ангусом Янгами."});
                context.Cases.Add(new Case {Id = 2, Name = "Guns N` Roses", Description = "американская хард-рок-группа, сформировавшаяся в 1985 году в Лос-Анджелесе, штат Калифорния. В первоначальный состав участников, которые в 1986 году заключили контракт со звукозаписывающей компанией Geffen Records, входили: вокалист Эксл Роуз, соло-гитарист Слэш, ритм-гитарист Иззи Стрэдлин, басист Дафф Маккаган и барабанщик Стивен Адлер. Состав участников Guns N’ Roses менялся неоднократно, неизменным солистом в коллективе оставался только Роуз. Текущий состав включает: Роуза, Слэша, Маккагана, а также клавишников Диззи Рида и Мелиссу Риз, гитариста Ричарда Фортуса и барабанщика Фрэнка Феррера  (англ.)рус.. Дискография Guns N’ Roses, кроме синглов и сборников, насчитывает шесть студийных альбомов, продажи которых к настоящему времени превышают 100 млн копий по всему миру, включая 45 млн только в США, и по праву считается одной из самых востребованных групп в мире."});
                context.Cases.Add(new Case {Id = 3, Name = "Nirvana", Description = "американская рок-группа, созданная вокалистом и гитаристом Куртом Кобейном и басистом Кристом Новоселичем в Абердине, штат Вашингтон, в 1987 году. В составе коллектива сменились несколько барабанщиков; дольше всех с группой играл ударник Дэйв Грол, присоединившийся к Кобейну и Новоселичу в 1990 году."});
                context.Cases.Add(new Case {Id = 4, Name = "Metallica", Description = "американская метал-группа[1], образованная в 1981 году, в Лос-Анджелесе. Metallica оказала большое влияние на развитие метала и входит (вместе с такими группами как Slayer, Megadeth и Anthrax) в «большую четвёрку трэш-метала»[2]. Альбомы Metallica были проданы в общей сложности в количестве более 110 миллионов экземпляров по всему миру[3], что делает её одним из самых коммерчески успешных металлических коллективов. В 2011 году один из крупнейших журналов о метал-музыке Kerrang! в июньском номере признал Metallica лучшей метал-группой последних 30 лет[4]."});
                context.Cases.Add(new Case {Id = 5, Name = "The Who",Description = "британская рок-группа, сформированная в 1964 году. Первоначальный состав состоял из Пита Таунсенда, Роджера Долтри, Джона Энтвистла и Кита Муна. Группа приобрела огромный успех за счёт неординарных концертных выступлений и считается одной из самых влиятельных групп 60-х и 70-х годов[2], так и одной из величайших рок-групп всех времён.[3]"});
                context.Cases.Add(new Case {Id = 6, Name = "The Rolling Stones", Description = "британская рок-группа, образовавшаяся 12 июля 1962 года и многие годы соперничавшая по популярности с The Beatles. The Rolling Stones, ставшие важной частью Британского вторжения, считаются одной из самых влиятельных и успешных групп в истории рока[4]. The Rolling Stones, которые по замыслу менеджера Эндрю Луга Олдэма должны были стать «бунтарской» альтернативой The Beatles, уже в 1969 году в ходе американского турне рекламировались как «величайшая рок-н-ролльная группа в мире» и (согласно Allmusic) сумели сохранить этот статус по сей день[1]."});
                context.Cases.Add(new Case {Id = 7, Name = "The Rolling Stones_1"});
                context.Cases.Add(new Case {Id = 8, Name = "The Rolling Stone_2"});
                context.Cases.Add(new Case {Id = 9, Name = "The Rolling Stones_3"});
                context.Cases.Add(new Case {Id = 10, Name = "The Rolling Stones_4"});
                context.Cases.Add(new Case {Id = 11, Name = "The Rolling Stones_5"});
                context.Cases.Add(new Case {Id = 12, Name = "The Rolling Stones_6"});
                context.Cases.Add(new Case {Id = 13, Name = "The Rolling Stones_7"});
                context.Cases.Add(new Case {Id = 14, Name = "The Rolling Stones_8"});
                context.Cases.Add(new Case {Id = 15, Name = "The Rolling Stones_9"});
            }


            if (!context.RunCases.Any())
            {
                Console.WriteLine("--> Seeding by runCases...");
                context.RunCases.Add(new RunCase {RunId = 1, CaseId = 1});
                context.RunCases.Add(new RunCase {RunId = 1, CaseId = 2});
                context.RunCases.Add(new RunCase {RunId = 1, CaseId = 3});
                context.RunCases.Add(new RunCase {RunId = 2, CaseId = 4});
                context.RunCases.Add(new RunCase {RunId = 2, CaseId = 5});
                context.RunCases.Add(new RunCase {RunId = 2, CaseId = 6});

                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 1});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 2});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 3});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 4});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 5});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 6});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 7});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 8});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 9});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 10});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 11});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 12});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 13});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 14});
                context.RunCases.Add(new RunCase {RunId = 3, CaseId = 15});
            }
        }
    }
}