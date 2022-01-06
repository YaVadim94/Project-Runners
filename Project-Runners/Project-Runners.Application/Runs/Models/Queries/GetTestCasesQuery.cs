using System.Collections.Generic;
using MediatR;
using ProjectRunners.Application.Runs.Models.Dto;

namespace ProjectRunners.Application.Runs.Models.Queries
{
    /// <summary>
    /// Запрос на получение тестов
    /// </summary>
    public record GetTestCasesQuery(long RunId, int PageSize, int PageNumber)
        : IRequest<IEnumerable<CaseDto>>;
}