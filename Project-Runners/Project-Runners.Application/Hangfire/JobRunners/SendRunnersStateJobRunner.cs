using System.Threading.Tasks;
using MediatR;
using Project_Runners.Application.Hangfire.Attributes;
using Project_Runners.Application.Runners.Models.Commands;
using Project_runners.Common.Hangfire;

namespace Project_Runners.Application.Hangfire.JobRunners
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