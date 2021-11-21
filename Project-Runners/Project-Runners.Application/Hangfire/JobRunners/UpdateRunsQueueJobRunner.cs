using System;
using System.Reflection;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Common;
using MediatR;
using Project_Runners.Application.Runs.Models.Commands;

namespace Project_Runners.Application.Hangfire.JobRunners
{
    /// <summary>
    /// Класс, отвечающий за запуск задачи на создание прогона
    /// </summary>
    public class UpdateRunsQueueJobRunner : JobRunnerBase
    {
        private readonly IMediator _mediator;

        public UpdateRunsQueueJobRunner(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public override async Task Execute()
        {
            var command = new UpdateRunsQueueCommand();
            
            await _mediator.Send(command);
        }
    }
}