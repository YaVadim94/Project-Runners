using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Application.Hangfire.Attributes;
using ProjectRunners.Application.Runs.Models.Commands;

namespace ProjectRunners.Application.Hangfire.JobRunners
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
        
        /// <summary>
        /// Каждую минуту
        /// </summary>
        [Frequency("* * * * *")]
        public override async Task Execute()
        {
            var command = new UpdateRunsQueueCommand();
            
            await _mediator.Send(command);
        }
    }
}