using MediatR;
using Project_runners.Common.Enums;

namespace Project_Runners.Application.CaseResults.Models.Commands
{
    /// <summary>
    /// Команда на создание результата теста
    /// </summary>
    public class CreateCaseResultCommand : IRequest
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
        
        /// <summary> Идентификатор прогона </summary>
        public long RunId { get; set; }

        /// <summary> Статус прогона </summary>
        public RunStatus Status { get; set; }
    }
}