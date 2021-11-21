using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project_Runners.Application.CaseResults.Models.Commands;
using Project_Runners.Data;
using Project_Runners.Data.Models;

namespace Project_Runners.Application.CaseResults.CommandHandlers
{
    /// <summary>
    /// Обработчик события создания результата теста
    /// </summary>
    public class CreateCaseResultCommandHandler : IRequestHandler<CreateCaseResultCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateCaseResultCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Создать результат прогона теста
        /// </summary>
        public async Task<Unit> Handle(CreateCaseResultCommand request, CancellationToken cancellationToken)
        {
            var caseResult = _mapper.Map<CaseResult>(request);
            
            await _context.CaseResults.AddAsync(caseResult, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}