using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Application.Runs.Models.Dto;
using Project_Runners.Application.Runs.Models.Queries;
using Project_Runners.Data;

namespace Project_Runners.Application.Runs.QueryHandlers
{
    /// <summary>
    /// Обработчик запроса на все прогоны
    /// </summary>
    public class GetAllRunsHandler : IRequestHandler<GetAllRunsQuery, IEnumerable<RunDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public GetAllRunsHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все прогоны
        /// </summary>
        public async Task<IEnumerable<RunDto>> Handle(GetAllRunsQuery request, CancellationToken cancellationToken)
        {
            var runs = await _context.Runs
                .ProjectTo<RunDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return runs;
        }
    }
}