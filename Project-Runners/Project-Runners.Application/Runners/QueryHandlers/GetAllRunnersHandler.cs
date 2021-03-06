using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Runners.Models.Dto;
using ProjectRunners.Application.Runners.Models.Queries;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runners.QueryHandlers
{
    /// <summary>
    /// Обрабочик запроса спска всех раннеров
    /// </summary>
    public class GetAllRunnersHandler : IRequestHandler<GetAllRunnersQuery, IEnumerable<RunnerDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public GetAllRunnersHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список всех раннеров
        /// </summary>
        public async Task<IEnumerable<RunnerDto>> Handle(GetAllRunnersQuery request, CancellationToken cancellationToken)
        {
            var runners = await _context.Runners
                .Where(request.Filter)
                .ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<IEnumerable<RunnerDto>>(runners);
        }
    }
}