using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Data.Mediator.Commands;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Data
{
    /// <summary>
    /// Класс контекста БД
    /// </summary>
    public class DataContext : DbContext
    {
        private readonly IMediator _mediator;
        
        public DataContext(DbContextOptions<DataContext> opt, IMediator mediator) : base(opt)
        {
            _mediator = mediator;
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Runner>().HasIndex(r => r.Name).IsUnique();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            await _mediator.Send(new SetChangeDateCommand(), cancellationToken);
            
            return await base.SaveChangesAsync(cancellationToken);
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