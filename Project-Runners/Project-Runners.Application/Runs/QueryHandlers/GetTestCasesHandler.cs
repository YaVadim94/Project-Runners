using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Runs.Models.Dto;
using ProjectRunners.Application.Runs.Models.Queries;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runs.QueryHandlers
{
    /// <summary>
    /// Обработчик события получения тестов прогона
    /// </summary>
    public class GetTestCasesHandler : IRequestHandler<GetTestCasesQuery, IEnumerable<CaseDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public GetTestCasesHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить тесты
        /// </summary>
        public async Task<IEnumerable<CaseDto>> Handle(GetTestCasesQuery request, CancellationToken cancellationToken)
        {
            var testCases = await _context.Cases
                .Where(c => c.Runs.Select(r => r.RunId).Contains(request.RunId))
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ProjectTo<CaseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return testCases;
        }
    }
}