using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Application.Hangfire.Attributes;
using ProjectRunners.Application.Runners.Models.Commands;

namespace ProjectRunners.Application.Hangfire.JobRunners
{
    /// <summary>
    /// Класс, отвечающий за запопуск задачи на поиск выключенных раннеров
    /// </summary>
    public class IdentifyInactiveJobRunner : JobRunnerBase
    {
        private readonly IMediator _mediator;

        public IdentifyInactiveJobRunner(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Каждую минуту
        /// </summary>
        [Frequency(Crons.EveryMinute)]
        public override async Task Execute()
        {
            var command = new IdentifyInactiveRunnersCommand();

            await _mediator.Send(command);
        }
    }
}