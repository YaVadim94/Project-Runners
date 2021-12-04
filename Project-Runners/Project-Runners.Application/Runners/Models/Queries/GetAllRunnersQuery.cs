using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MediatR;
using Project_Runners.Application.Runners.Models.Dto;
using Project_Runners.Data.Models;

namespace Project_Runners.Application.Runners.Models.Queries
{
    /// <summary>
    /// Запрос списка всех раннеров
    /// </summary>
    public class GetAllRunnersQuery : IRequest<IEnumerable<RunnerDto>>
    {
        public Expression<Func<Runner, bool>> Filter { get; set; }
    }
}