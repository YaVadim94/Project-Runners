using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectRunners.Application.CaseResults.Models.Commands;
using ProjectRunners.Data;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Application.CaseResults.CommandHandlers
{
    /// <summary>
    /// Обработчик события создания результата теста
    /// </summary>
    public class CreateCaseResultHandler : IRequestHandler<CreateCaseResultCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateCaseResultHandler(DataContext context, IMapper mapper)
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