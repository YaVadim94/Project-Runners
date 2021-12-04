using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Application.Hangfire.Attributes;
using ProjectRunners.Application.Runners.Models.Commands;

namespace ProjectRunners.Application.Hangfire.JobRunners
{
    /// <summary>
    /// Класс, отвечающий за запуск задачи на обновление статусов всех раннеров
    /// </summary>
    public class SendRunnersStateJobRunner : JobRunnerBase
    {
        private readonly IMediator _mediator;

        public SendRunnersStateJobRunner(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Каждые 10 сек
        /// </summary>
        [Frequency("*/10 * * * * *")]
        public override async Task Execute()
        {
            var command = new SendRequestForStateUpdatingCommand();

            await _mediator.Send(command);
        }
    }
}