using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Application.Runs.Models.Commands;
using Project_Runners.Data;
using Project_Runners.Data.Enums;

namespace Project_Runners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Start run handler
    /// </summary>
    public class StartRunCommandHandler : IRequestHandler<StartRunCommand>
    {
        private readonly DataContext _context;

        public StartRunCommandHandler(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Start run
        /// </summary>
        public async Task<Unit> Handle(StartRunCommand request, CancellationToken cancellationToken)
        {
            var notStartedRuns = await _context.Runs
                .Where(r => r.Status == RunStatus.NotStarted)
                .ToListAsync(cancellationToken);
            
            notStartedRuns.ForEach(run =>
            {
                run.Status = RunStatus.InProgress;
                Console.WriteLine($" -----> Run: \"{run.Name}\" has just started");
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}