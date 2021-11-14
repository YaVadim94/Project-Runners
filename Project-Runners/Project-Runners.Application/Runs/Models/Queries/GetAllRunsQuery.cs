using System.Collections.Generic;
using MediatR;
using Project_Runners.Application.Runs.Models.Dto;

namespace Project_Runners.Application.Runs.Models.Queries
{
    /// <summary>
    /// Запрос на все прогоны
    /// </summary>
    public class GetAllRunsQuery : IRequest<IEnumerable<RunDto>>
    {
        
    }
}