using System.Collections.Generic;
using MediatR;
using ProjectRunners.Application.Runs.Models.Dto;

namespace ProjectRunners.Application.Runs.Models.Queries
{
    /// <summary>
    /// Запрос на все прогоны
    /// </summary>
    public class GetAllRunsQuery : IRequest<IEnumerable<RunDto>>
    {
        
    }
}