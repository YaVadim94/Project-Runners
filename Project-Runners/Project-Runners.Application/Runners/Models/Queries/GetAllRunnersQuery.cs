using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MediatR;
using ProjectRunners.Application.Runners.Models.Dto;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Application.Runners.Models.Queries
{
    /// <summary>
    /// Запрос списка всех раннеров
    /// </summary>
    public class GetAllRunnersQuery : IRequest<IEnumerable<RunnerDto>>
    {
        public Expression<Func<Runner, bool>> Filter { get; set; }
    }
}