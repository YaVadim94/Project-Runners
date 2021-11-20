using MediatR;

namespace Project_Runners.Application.Runs.Models.Commands
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