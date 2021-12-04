using Microsoft.EntityFrameworkCore;
using Project_Runners.Data.Models;

namespace Project_Runners.Data
{
    /// <summary>
    /// Класс контекста БД
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Runner>().HasIndex(r => r.Name).IsUnique();
        }

        /// <summary> Раннеры </summary>
        public DbSet<Runner> Runners { get; set; }
        
        /// <summary> Результаты прохождения кейсов </summary>
        public DbSet<CaseResult> CaseResults { get; set; }

        /// <summary> Прогоны/кейсы </summary>
        public DbSet<RunCase> RunCases { get; set; }

        /// <summary> Прогоны </summary>
        public DbSet<Run> Runs { get; set; }

        /// <summary> Кейсы </summary>
        public DbSet<Case> Cases { get; set; }
    }
}