using MediatR;

namespace ProjectRunners.Application.Runs.Models.Commands
{
    /// <summary>
    /// Команда на запуск прогона
    /// </summary>
    public class StartRunCommand : IRequest
    {
        /// <summary> Идентификатор прогона </summary>
        public long Id { get; set; }
    }
}