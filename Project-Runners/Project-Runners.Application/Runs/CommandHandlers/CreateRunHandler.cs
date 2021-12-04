using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectRunners.Application.Runs.Models.Commands;
using ProjectRunners.Data;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчик создания прогона
    /// </summary>
    public class CreateRunHandler : IRequestHandler<CreateRunCommand, long>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateRunHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Создать прогон
        /// </summary>
        public async Task<long> Handle(CreateRunCommand request, CancellationToken cancellationToken)
        {
            var run = _mapper.Map<Run>(request);

            await _context.AddAsync(run, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return run.Id;
        }
    }
}