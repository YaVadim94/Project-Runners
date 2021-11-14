using System;
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
    /// Обработчик запроса на получение прогона по идентификатору
    /// </summary>
    public class GetRunByIdHandler : IRequestHandler<GetRunByIdQuery, RunDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetRunByIdHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить прогон по id
        /// </summary>
        public async Task<RunDto> Handle(GetRunByIdQuery request, CancellationToken cancellationToken)
        {
            var run = await _context.Runs
                          .ProjectTo<RunDto>(_mapper.ConfigurationProvider)
                          .SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken)
                      ?? throw new Exception($"Прогона с идентификатором {request.Id} не существует");

            return run;
        }
    }
}