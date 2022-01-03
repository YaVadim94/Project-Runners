using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Application.Services.Publishing;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик события обновления состояния раннера
    /// </summary>
    public class SetStateHandler : IRequestHandler<SetStateCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHubPublishingService _hubPublishingService;
        
        public SetStateHandler(DataContext context, IHubPublishingService hubPublishingService, IMapper mapper)
        {
            _context = context;
            _hubPublishingService = hubPublishingService;
            _mapper = mapper;
        }

        /// <summary>
        /// Обновить состоние раннера
        /// </summary>
        public async Task<Unit> Handle(SetStateCommand request, CancellationToken cancellationToken)
        {
            var runner = await _context.Runners.GetById(request.RunnerId);

            runner.State = request.State;

            var stateChanged = _context.Entry(runner).State == EntityState.Modified; 
            
            await _context.SaveChangesAsync(cancellationToken);

            if (stateChanged)
            {
                var publishDto = _mapper.Map<RunnerPublishDto>(runner);
                _hubPublishingService.Publish(publishDto);
            }
            
            return Unit.Value;
        }
    }
}