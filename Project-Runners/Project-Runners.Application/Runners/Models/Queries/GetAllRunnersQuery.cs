using System.Collections.Generic;
using MediatR;
using Project_Runners.Application.Runners.Models.Dto;

namespace Project_Runners.Application.Runners.Models.Queries
{
    /// <summary>
    /// Запрос списка всех раннеров
    /// </summary>
    public class GetAllRunnersQuery : IRequest<IEnumerable<RunnerDto>>
    {
        
    }
}