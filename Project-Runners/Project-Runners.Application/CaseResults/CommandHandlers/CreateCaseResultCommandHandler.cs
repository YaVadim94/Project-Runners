using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project_Runners.Application.CaseResults.Models.Commands;

namespace Project_Runners.Application.CaseResults.CommandHandlers
{
    /// <summary>
    /// Обработчик события создания результата теста
    /// </summary>
    public class CreateCaseResultCommandHandler : IRequestHandler<CreateCaseResultCommand>
    {
        /// <summary>
        /// Создать результат прогона теста
        /// </summary>
        public Task<Unit> Handle(CreateCaseResultCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}