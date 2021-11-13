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

        /// <summary> Прогоны </summary>
        public DbSet<Run> Runs { get; set; } = null!;

        /// <summary> Кейсы </summary>
        public DbSet<Case> Cases { get; set; } = null!;
    }
}