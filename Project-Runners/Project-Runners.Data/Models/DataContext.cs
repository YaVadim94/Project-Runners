using Microsoft.EntityFrameworkCore;

namespace Project_Runners.Data.Models
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
        public DbSet<Run> Runs { get; set; }

        /// <summary> Кейсы </summary>
        public DbSet<Case> Cases { get; set; }
    }
}